using Crypto;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace DotNetUnpacker
{
    public static class Program
    {
        private const string BINARY = "Data.ew";
        private static readonly IDictionary<string, Assembly> LIBRARY = new Dictionary<string, Assembly>();

        public static IOrderedDictionary unpack()
        {
            IOrderedDictionary ret = new OrderedDictionary();
            using (Stream cipher = Assembly.GetExecutingAssembly().GetManifestResourceStream(BINARY))
            {
                using (MemoryStream ms = RFC2898AESCrypto.AESDecrypt(cipher))
                {
                    using (ZipArchive archive = new ZipArchive(ms))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            string name = entry.Name;
                            using (Stream stream = entry.Open())
                            {
                                byte[] data = RFC2898AESCrypto.readAllByte(stream);
                                ret.Add(name, data);
                            }
                        }
                    }
                }
            }
            return ret;
        }

        private static void loadWPFApplication(Assembly assembly, MethodInfo method, string[] args)
        {
            Type application = typeof(System.Windows.Application);
            FieldInfo field = application.GetField("_resourceAssembly", BindingFlags.NonPublic | BindingFlags.Static);
            field.SetValue(null, assembly);

            Type helper = typeof(BaseUriHelper);
            PropertyInfo property = helper.GetProperty("ResourceAssembly", BindingFlags.NonPublic | BindingFlags.Static);
            property.SetValue(null, assembly, null);
            invokeMain(method, args);
        }

        private static void invokeMain(MethodInfo method, string[] args)
        {
            try
            {
                method.Invoke(null, new object[]{
                    args
                });
            }
            catch
            {
                method.Invoke(null, null);
            }
        }

        private static Assembly resolveDLLEventHandler(object sender, ResolveEventArgs e)
        {
            Assembly ret;
            LIBRARY.TryGetValue(e.Name, out ret);
            return ret;
        }

        // 記憶體解壓執行
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                IOrderedDictionary extract = unpack();
                if (extract.Count > 1)
                {
                    for (int i = 1; i < extract.Count; ++i)
                    {
                        Assembly dll = Assembly.Load((byte[])extract[i]);
                        LIBRARY.Add(dll.FullName, dll);
                    }
                    AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += resolveDLLEventHandler;
                    AppDomain.CurrentDomain.AssemblyResolve += resolveDLLEventHandler;
                }
                Assembly assembly = Assembly.Load((byte[])extract[0]);
                MethodInfo method = assembly.EntryPoint;

                try
                {
                    loadWPFApplication(assembly, method, args);
                }
                catch
                {
                    invokeMain(method, args);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程式執行失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}