using Crypto;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toolbelt.Drawing;

namespace DotNetPacker
{
    public partial class MainForm : Form
    {
        private const string ICON_TEMP_FILE = "Icon.ico";
        private const string PACKAGE_ENCRYPT_FILE = "Data.ew";

        private readonly Version version;
        private readonly Compiler compiler;
        private readonly IDictionary<string, string> mergeDLL;

        public MainForm()
        {
            InitializeComponent();
            cbEnvironment.SelectedIndex = 1;
            cbPlatform.SelectedIndex = 2;

            version = new Version();
            compiler = new Compiler();
            mergeDLL = new Dictionary<string, string>();
        }

        private static void openInputFile(TextBox target)
        {
            using (OpenFileDialog open = new OpenFileDialog()
            {
                Filter = ".Net 應用程式 (*.exe)|*.exe",
                Title = "請選擇輸入檔案"
            })
            {
                if (open.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                target.Text = open.FileName;
            }
        }

        private static void saveOutputFile(TextBox target)
        {
            using (SaveFileDialog save = new SaveFileDialog()
            {
                Filter = ".Net 應用程式 (*.exe)|*.exe",
                Title = "請指定輸出檔案"
            })
            {
                if (save.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                target.Text = save.FileName;
            }
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            openInputFile(txtInput);
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            saveOutputFile(txtOutput);
        }

        private static void writeZIPEntry(ZipArchiveEntry entry, byte[] data)
        {
            using (Stream stream = entry.Open())
            {
                using (BinaryWriter bw = new BinaryWriter(stream))
                {
                    bw.Write(data);
                }
            }
        }

        private static MemoryStream createZIP(string file, IDictionary<string, string> dll)
        {
            MemoryStream ms = new MemoryStream();
            using (ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                ZipArchiveEntry entry = archive.CreateEntry("Main.exe");
                writeZIPEntry(entry, File.ReadAllBytes(file));

                if (dll.Count > 0)
                {
                    foreach (KeyValuePair<string, string> pair in dll)
                    {
                        entry = archive.CreateEntry(pair.Key);
                        writeZIPEntry(entry, File.ReadAllBytes(pair.Value));
                    }
                }
            }
            ms.Position = 0;
            return ms;
        }

        private void cleanUp()
        {
            compiler.reset();
            File.Delete(ICON_TEMP_FILE);
            File.Delete(Version.FILE_NAME);
            File.Delete(PACKAGE_ENCRYPT_FILE);
        }

        private void setLoading(bool loading)
        {
            if (loading)
            {
                updateStatusBar("執行中");
                appendMessage(Color.Green, "開始處理");
            }
            else
            {
                updateStatusBar("就緒");
            }
            pbLoading.Visible = loading;
            enableControl(!loading);
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string output = txtOutput.Text;
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(output))
            {
                MessageBox.Show("請指定輸入與輸出檔案", "檔案", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            setLoading(true);
            appendMessage(Color.Black, "讀取使用者設定");
            string platform = cbPlatform.SelectedItem.ToString().ToLowerInvariant();
            bool console = cbEnvironment.SelectedIndex == 0;
            bool uac = chkUAC.Checked;

            Exception exception = null;
            await Task.Run(() =>
            {
                string icon = ICON_TEMP_FILE;
                appendMessage(Color.Black, "提取程式圖標");
                try
                {
                    using (FileStream fs = File.Create(ICON_TEMP_FILE))
                    {
                        IconExtractor.Extract1stIconTo(input, fs);
                        if (fs.Length <= 0)
                        {
                            icon = null;
                        }
                    }
                }
                catch
                {
                    icon = null;
                }

                compiler.addResourceFile(PACKAGE_ENCRYPT_FILE);
                try
                {
                    appendMessage(Color.Black, "產生版本資訊檔案");
                    version.writeVersion();

                    appendMessage(Color.Black, "壓縮原始程式");
                    using (MemoryStream zip = createZIP(input, mergeDLL))
                    {
                        appendMessage(Color.Black, "編碼壓縮資料");
                        byte[] data = RFC2898AESCrypto.AESEncrypt(zip);

                        appendMessage(Color.Black, "輸出中繼資料");
                        File.WriteAllBytes(PACKAGE_ENCRYPT_FILE, data);
                    }

                    appendMessage(Color.Black, "編譯程式");
                    compiler.compile(output, icon, platform, console, uac);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }

                try
                {
                    appendMessage(Color.Black, "清理中繼資料");
                    cleanUp();
                }
                catch (Exception ex)
                {
                    appendMessage(Color.Orange, $"中繼資料清除時發生例外狀況 : {ex.Message}");
                }
            });

            if (exception == null)
            {
                appendMessage(Color.Green, "執行完成");
                MessageBox.Show("加殼執行完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                appendMessage(Color.Red, $"發生例外狀況 : {exception.Message}");
                MessageBox.Show("加殼過程發生例外狀況", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            setLoading(false);
        }

        private void updateStatusBar(string message)
        {
            tsslStatus.Text = message;
        }

        public static string getCurrentTime()
        {
            return DateTime.Now.ToString("tt hh : mm : ss");
        }

        private void appendMessage(Color color, string message)
        {
            txtMessage.Invoke((MethodInvoker)delegate
            {
                txtMessage.SelectionColor = color;
                txtMessage.AppendText($"[{getCurrentTime()}] {message}{Environment.NewLine}");
            });
        }

        private void enableControl(bool enable)
        {
            btnBrowseInput.Enabled = btnBrowseOutput.Enabled = btnClearDLL.Enabled
                = btnAddDLL.Enabled = cbEnvironment.Enabled = cbPlatform.Enabled
                = btnVersion.Enabled = chkUAC.Enabled = btnProcess.Enabled
                = btnBrowseInputExtract.Enabled = btnBrowseOutputExtract.Enabled = btnProcessExtract.Enabled
                = btnClear.Enabled = enable;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMessage.Text = string.Empty;
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            using (AboutForm form = new AboutForm())
            {
                form.ShowDialog();
            }
        }

        private void tsmiOtherInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("殼可以套疊，但沒有任何意義 (只會愈來愈肥)", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBrowseInputExtract_Click(object sender, EventArgs e)
        {
            openInputFile(txtInputExtract);
        }

        private void btnBrowseOutputExtract_Click(object sender, EventArgs e)
        {
            saveOutputFile(txtOutputExtract);
        }

        private async void btnProcessExtract_Click(object sender, EventArgs e)
        {
            string input = txtInputExtract.Text;
            string output = txtOutputExtract.Text;
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(output))
            {
                MessageBox.Show("請指定輸入與輸出檔案", "檔案", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            setLoading(true);
            Exception exception = null;
            await Task.Run(() =>
            {
                appendMessage(Color.Black, "讀取輸入程式");
                try
                {
                    Assembly assembly = Assembly.LoadFrom(input);
                    appendMessage(Color.Black, "對程式脫殼");
                    IOrderedDictionary data = (IOrderedDictionary)assembly.GetType("DotNetUnpacker.Program").GetMethod("unpack").Invoke(null, null);

                    appendMessage(Color.Black, "輸出程式");
                    File.WriteAllBytes(output, (byte[])data[0]);

                    if (data.Count > 1)
                    {
                        string path = Path.GetDirectoryName(output);
                        string[] key = new string[data.Keys.Count];
                        data.Keys.CopyTo(key, 0);
                        for (int i = 1; i < data.Count; ++i)
                        {
                            File.WriteAllBytes(Path.Combine(path, key[i]), (byte[])data[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            if (exception == null)
            {
                appendMessage(Color.Green, "執行完成");
                MessageBox.Show("脫殼執行完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                appendMessage(Color.Red, $"發生例外狀況 : {exception.Message}");
                MessageBox.Show("脫殼過程發生例外狀況", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            setLoading(false);
        }

        private void tssbHelp_ButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("這是一個對 .Net 可執行檔案進行壓縮的程式", "喵嗚 ฅ^•ω•^ฅ ~", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateDLLFileCount()
        {
            labelDLLFile.Text = $"{mergeDLL.Count} 檔案";
        }

        private void btnClearDLL_Click(object sender, EventArgs e)
        {
            mergeDLL.Clear();
            updateDLLFileCount();
        }

        private void btnAddDLL_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog()
            {
                Filter = ".Net 動態連結程式庫 (*.dll)|*.dll",
                Multiselect = true,
                Title = "請選擇合併檔案"
            })
            {
                if (open.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string[] fileList = open.FileNames;
                IDictionary<string, string> fileAdd = new Dictionary<string, string>();
                foreach (string file in fileList)
                {
                    string name = Path.GetFileName(file);
                    if (mergeDLL.ContainsKey(name))
                    {
                        MessageBox.Show($"包含重複 DLL 檔案 : {name}", "未新增檔案", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    fileAdd.Add(name, file);
                }

                foreach (KeyValuePair<string, string> item in fileAdd)
                {
                    mergeDLL.Add(item);
                }
                updateDLLFileCount();
            }
        }

        private void btnVersion_Click(object sender, EventArgs e)
        {
            using (VersionSetting form = new VersionSetting(version))
            {
                form.ShowDialog();
            }
        }
    }
}