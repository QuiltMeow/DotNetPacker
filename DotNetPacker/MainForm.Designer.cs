namespace DotNetPacker
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.labelOutput = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssbHelp = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiOtherInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.chkUAC = new System.Windows.Forms.CheckBox();
            this.labelEnvironment = new System.Windows.Forms.Label();
            this.cbEnvironment = new System.Windows.Forms.ComboBox();
            this.labelPlatform = new System.Windows.Forms.Label();
            this.cbPlatform = new System.Windows.Forms.ComboBox();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpPack = new System.Windows.Forms.TabPage();
            this.btnVersion = new System.Windows.Forms.Button();
            this.btnAddDLL = new System.Windows.Forms.Button();
            this.btnClearDLL = new System.Windows.Forms.Button();
            this.labelDLLFile = new System.Windows.Forms.Label();
            this.labelEmbedDLL = new System.Windows.Forms.Label();
            this.tpUnpack = new System.Windows.Forms.TabPage();
            this.labelInputExtract = new System.Windows.Forms.Label();
            this.txtInputExtract = new System.Windows.Forms.TextBox();
            this.btnBrowseInputExtract = new System.Windows.Forms.Button();
            this.labelOutputExtract = new System.Windows.Forms.Label();
            this.txtOutputExtract = new System.Windows.Forms.TextBox();
            this.btnBrowseOutputExtract = new System.Windows.Forms.Button();
            this.btnProcessExtract = new System.Windows.Forms.Button();
            this.ssStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpPack.SuspendLayout();
            this.tpUnpack.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(17, 545);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(140, 12);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Dot Net 執行檔案壓縮工具";
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(30, 30);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(53, 12);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text = "輸入檔案";
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.White;
            this.txtInput.Location = new System.Drawing.Point(100, 27);
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.Size = new System.Drawing.Size(300, 22);
            this.txtInput.TabIndex = 1;
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(430, 25);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseInput.TabIndex = 2;
            this.btnBrowseInput.Text = "瀏覽";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(30, 65);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(53, 12);
            this.labelOutput.TabIndex = 3;
            this.labelOutput.Text = "輸出檔案";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(100, 62);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(300, 22);
            this.txtOutput.TabIndex = 4;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(430, 60);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOutput.TabIndex = 5;
            this.btnBrowseOutput.Text = "瀏覽";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(36, 285);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(473, 240);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.Text = "";
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tssbHelp});
            this.ssStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ssStatus.Location = new System.Drawing.Point(0, 579);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(554, 22);
            this.ssStatus.SizingGrip = false;
            this.ssStatus.TabIndex = 5;
            this.ssStatus.Text = "狀態列";
            // 
            // tsslStatus
            // 
            this.tsslStatus.BackColor = System.Drawing.Color.Transparent;
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(31, 17);
            this.tsslStatus.Text = "就緒";
            // 
            // tssbHelp
            // 
            this.tssbHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOtherInfo,
            this.tsmiAbout});
            this.tssbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tssbHelp.Image")));
            this.tssbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbHelp.Name = "tssbHelp";
            this.tssbHelp.Size = new System.Drawing.Size(47, 20);
            this.tssbHelp.Text = "說明";
            this.tssbHelp.ButtonClick += new System.EventHandler(this.tssbHelp_ButtonClick);
            // 
            // tsmiOtherInfo
            // 
            this.tsmiOtherInfo.Name = "tsmiOtherInfo";
            this.tsmiOtherInfo.Size = new System.Drawing.Size(122, 22);
            this.tsmiOtherInfo.Text = "其他資訊";
            this.tsmiOtherInfo.Click += new System.EventHandler(this.tsmiOtherInfo_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(122, 22);
            this.tsmiAbout.Text = "關於";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(430, 165);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 16;
            this.btnProcess.Text = "開始處理";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(434, 540);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMessage.Location = new System.Drawing.Point(15, 250);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(73, 20);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "訊息紀錄";
            // 
            // chkUAC
            // 
            this.chkUAC.AutoSize = true;
            this.chkUAC.Location = new System.Drawing.Point(32, 169);
            this.chkUAC.Name = "chkUAC";
            this.chkUAC.Size = new System.Drawing.Size(108, 16);
            this.chkUAC.TabIndex = 15;
            this.chkUAC.Text = "系統管理員權限";
            this.chkUAC.UseVisualStyleBackColor = true;
            // 
            // labelEnvironment
            // 
            this.labelEnvironment.AutoSize = true;
            this.labelEnvironment.Location = new System.Drawing.Point(30, 135);
            this.labelEnvironment.Name = "labelEnvironment";
            this.labelEnvironment.Size = new System.Drawing.Size(53, 12);
            this.labelEnvironment.TabIndex = 10;
            this.labelEnvironment.Text = "執行環境";
            // 
            // cbEnvironment
            // 
            this.cbEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEnvironment.FormattingEnabled = true;
            this.cbEnvironment.Items.AddRange(new object[] {
            "主控台",
            "視窗程式"});
            this.cbEnvironment.Location = new System.Drawing.Point(100, 132);
            this.cbEnvironment.Name = "cbEnvironment";
            this.cbEnvironment.Size = new System.Drawing.Size(95, 20);
            this.cbEnvironment.TabIndex = 11;
            // 
            // labelPlatform
            // 
            this.labelPlatform.AutoSize = true;
            this.labelPlatform.Location = new System.Drawing.Point(260, 135);
            this.labelPlatform.Name = "labelPlatform";
            this.labelPlatform.Size = new System.Drawing.Size(29, 12);
            this.labelPlatform.TabIndex = 12;
            this.labelPlatform.Text = "平台";
            // 
            // cbPlatform
            // 
            this.cbPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlatform.FormattingEnabled = true;
            this.cbPlatform.Items.AddRange(new object[] {
            "x86",
            "x64",
            "AnyCPU"});
            this.cbPlatform.Location = new System.Drawing.Point(305, 132);
            this.cbPlatform.Name = "cbPlatform";
            this.cbPlatform.Size = new System.Drawing.Size(95, 20);
            this.cbPlatform.TabIndex = 13;
            // 
            // pbLoading
            // 
            this.pbLoading.BackColor = System.Drawing.Color.Transparent;
            this.pbLoading.Image = global::DotNetPacker.Properties.Resources.Spin;
            this.pbLoading.Location = new System.Drawing.Point(105, 245);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(27, 27);
            this.pbLoading.TabIndex = 19;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpPack);
            this.tcMain.Controls.Add(this.tpUnpack);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(554, 235);
            this.tcMain.TabIndex = 0;
            // 
            // tpPack
            // 
            this.tpPack.Controls.Add(this.btnVersion);
            this.tpPack.Controls.Add(this.btnAddDLL);
            this.tpPack.Controls.Add(this.btnClearDLL);
            this.tpPack.Controls.Add(this.labelDLLFile);
            this.tpPack.Controls.Add(this.labelEmbedDLL);
            this.tpPack.Controls.Add(this.labelInput);
            this.tpPack.Controls.Add(this.txtInput);
            this.tpPack.Controls.Add(this.cbPlatform);
            this.tpPack.Controls.Add(this.btnBrowseInput);
            this.tpPack.Controls.Add(this.labelPlatform);
            this.tpPack.Controls.Add(this.labelOutput);
            this.tpPack.Controls.Add(this.cbEnvironment);
            this.tpPack.Controls.Add(this.txtOutput);
            this.tpPack.Controls.Add(this.labelEnvironment);
            this.tpPack.Controls.Add(this.btnBrowseOutput);
            this.tpPack.Controls.Add(this.chkUAC);
            this.tpPack.Controls.Add(this.btnProcess);
            this.tpPack.Location = new System.Drawing.Point(4, 22);
            this.tpPack.Name = "tpPack";
            this.tpPack.Padding = new System.Windows.Forms.Padding(3);
            this.tpPack.Size = new System.Drawing.Size(546, 209);
            this.tpPack.TabIndex = 0;
            this.tpPack.Text = "壓縮";
            this.tpPack.UseVisualStyleBackColor = true;
            // 
            // btnVersion
            // 
            this.btnVersion.Location = new System.Drawing.Point(430, 130);
            this.btnVersion.Name = "btnVersion";
            this.btnVersion.Size = new System.Drawing.Size(75, 23);
            this.btnVersion.TabIndex = 14;
            this.btnVersion.Text = "版本設定";
            this.btnVersion.UseVisualStyleBackColor = true;
            this.btnVersion.Click += new System.EventHandler(this.btnVersion_Click);
            // 
            // btnAddDLL
            // 
            this.btnAddDLL.Location = new System.Drawing.Point(430, 95);
            this.btnAddDLL.Name = "btnAddDLL";
            this.btnAddDLL.Size = new System.Drawing.Size(75, 23);
            this.btnAddDLL.TabIndex = 9;
            this.btnAddDLL.Text = "加入";
            this.btnAddDLL.UseVisualStyleBackColor = true;
            this.btnAddDLL.Click += new System.EventHandler(this.btnAddDLL_Click);
            // 
            // btnClearDLL
            // 
            this.btnClearDLL.Location = new System.Drawing.Point(325, 95);
            this.btnClearDLL.Name = "btnClearDLL";
            this.btnClearDLL.Size = new System.Drawing.Size(75, 23);
            this.btnClearDLL.TabIndex = 8;
            this.btnClearDLL.Text = "清除";
            this.btnClearDLL.UseVisualStyleBackColor = true;
            this.btnClearDLL.Click += new System.EventHandler(this.btnClearDLL_Click);
            // 
            // labelDLLFile
            // 
            this.labelDLLFile.AutoSize = true;
            this.labelDLLFile.Location = new System.Drawing.Point(98, 100);
            this.labelDLLFile.Name = "labelDLLFile";
            this.labelDLLFile.Size = new System.Drawing.Size(38, 12);
            this.labelDLLFile.TabIndex = 7;
            this.labelDLLFile.Text = "0 檔案";
            // 
            // labelEmbedDLL
            // 
            this.labelEmbedDLL.AutoSize = true;
            this.labelEmbedDLL.Location = new System.Drawing.Point(30, 100);
            this.labelEmbedDLL.Name = "labelEmbedDLL";
            this.labelEmbedDLL.Size = new System.Drawing.Size(54, 12);
            this.labelEmbedDLL.TabIndex = 6;
            this.labelEmbedDLL.Text = "內嵌 DLL";
            // 
            // tpUnpack
            // 
            this.tpUnpack.Controls.Add(this.labelInputExtract);
            this.tpUnpack.Controls.Add(this.txtInputExtract);
            this.tpUnpack.Controls.Add(this.btnBrowseInputExtract);
            this.tpUnpack.Controls.Add(this.labelOutputExtract);
            this.tpUnpack.Controls.Add(this.txtOutputExtract);
            this.tpUnpack.Controls.Add(this.btnBrowseOutputExtract);
            this.tpUnpack.Controls.Add(this.btnProcessExtract);
            this.tpUnpack.Location = new System.Drawing.Point(4, 22);
            this.tpUnpack.Name = "tpUnpack";
            this.tpUnpack.Padding = new System.Windows.Forms.Padding(3);
            this.tpUnpack.Size = new System.Drawing.Size(546, 209);
            this.tpUnpack.TabIndex = 1;
            this.tpUnpack.Text = "解壓縮";
            this.tpUnpack.UseVisualStyleBackColor = true;
            // 
            // labelInputExtract
            // 
            this.labelInputExtract.AutoSize = true;
            this.labelInputExtract.Location = new System.Drawing.Point(30, 30);
            this.labelInputExtract.Name = "labelInputExtract";
            this.labelInputExtract.Size = new System.Drawing.Size(53, 12);
            this.labelInputExtract.TabIndex = 0;
            this.labelInputExtract.Text = "輸入檔案";
            // 
            // txtInputExtract
            // 
            this.txtInputExtract.BackColor = System.Drawing.Color.White;
            this.txtInputExtract.Location = new System.Drawing.Point(100, 27);
            this.txtInputExtract.Name = "txtInputExtract";
            this.txtInputExtract.ReadOnly = true;
            this.txtInputExtract.Size = new System.Drawing.Size(300, 22);
            this.txtInputExtract.TabIndex = 1;
            // 
            // btnBrowseInputExtract
            // 
            this.btnBrowseInputExtract.Location = new System.Drawing.Point(430, 25);
            this.btnBrowseInputExtract.Name = "btnBrowseInputExtract";
            this.btnBrowseInputExtract.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseInputExtract.TabIndex = 2;
            this.btnBrowseInputExtract.Text = "瀏覽";
            this.btnBrowseInputExtract.UseVisualStyleBackColor = true;
            this.btnBrowseInputExtract.Click += new System.EventHandler(this.btnBrowseInputExtract_Click);
            // 
            // labelOutputExtract
            // 
            this.labelOutputExtract.AutoSize = true;
            this.labelOutputExtract.Location = new System.Drawing.Point(30, 65);
            this.labelOutputExtract.Name = "labelOutputExtract";
            this.labelOutputExtract.Size = new System.Drawing.Size(53, 12);
            this.labelOutputExtract.TabIndex = 3;
            this.labelOutputExtract.Text = "輸出檔案";
            // 
            // txtOutputExtract
            // 
            this.txtOutputExtract.BackColor = System.Drawing.Color.White;
            this.txtOutputExtract.Location = new System.Drawing.Point(100, 62);
            this.txtOutputExtract.Name = "txtOutputExtract";
            this.txtOutputExtract.ReadOnly = true;
            this.txtOutputExtract.Size = new System.Drawing.Size(300, 22);
            this.txtOutputExtract.TabIndex = 4;
            // 
            // btnBrowseOutputExtract
            // 
            this.btnBrowseOutputExtract.Location = new System.Drawing.Point(430, 60);
            this.btnBrowseOutputExtract.Name = "btnBrowseOutputExtract";
            this.btnBrowseOutputExtract.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOutputExtract.TabIndex = 5;
            this.btnBrowseOutputExtract.Text = "瀏覽";
            this.btnBrowseOutputExtract.UseVisualStyleBackColor = true;
            this.btnBrowseOutputExtract.Click += new System.EventHandler(this.btnBrowseOutputExtract_Click);
            // 
            // btnProcessExtract
            // 
            this.btnProcessExtract.Location = new System.Drawing.Point(430, 95);
            this.btnProcessExtract.Name = "btnProcessExtract";
            this.btnProcessExtract.Size = new System.Drawing.Size(75, 23);
            this.btnProcessExtract.TabIndex = 6;
            this.btnProcessExtract.Text = "開始處理";
            this.btnProcessExtract.UseVisualStyleBackColor = true;
            this.btnProcessExtract.Click += new System.EventHandler(this.btnProcessExtract_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(554, 601);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Dot Net Packer";
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpPack.ResumeLayout(false);
            this.tpPack.PerformLayout();
            this.tpUnpack.ResumeLayout(false);
            this.tpUnpack.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ToolStripSplitButton tssbHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.CheckBox chkUAC;
        private System.Windows.Forms.Label labelEnvironment;
        private System.Windows.Forms.ComboBox cbEnvironment;
        private System.Windows.Forms.Label labelPlatform;
        private System.Windows.Forms.ComboBox cbPlatform;
        private System.Windows.Forms.ToolStripMenuItem tsmiOtherInfo;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpPack;
        private System.Windows.Forms.TabPage tpUnpack;
        private System.Windows.Forms.Label labelInputExtract;
        private System.Windows.Forms.TextBox txtInputExtract;
        private System.Windows.Forms.Button btnBrowseInputExtract;
        private System.Windows.Forms.Label labelOutputExtract;
        private System.Windows.Forms.TextBox txtOutputExtract;
        private System.Windows.Forms.Button btnBrowseOutputExtract;
        private System.Windows.Forms.Button btnProcessExtract;
        private System.Windows.Forms.Button btnAddDLL;
        private System.Windows.Forms.Button btnClearDLL;
        private System.Windows.Forms.Label labelDLLFile;
        private System.Windows.Forms.Label labelEmbedDLL;
        private System.Windows.Forms.Button btnVersion;
    }
}

