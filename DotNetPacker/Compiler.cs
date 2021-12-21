using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace DotNetPacker
{
    public class Compiler
    {
        public CompilerParameters compilerParameter
        {
            get;
            private set;
        }

        public CSharpCodeProvider codeProvider
        {
            get;
            private set;
        }

        public Compiler()
        {
            reset();
        }

        public void reset()
        {
            compilerParameter = new CompilerParameters()
            {
                GenerateExecutable = true
            };
            addInternalReference();

            codeProvider = new CSharpCodeProvider();
        }

        public void addReference(string file)
        {
            compilerParameter.ReferencedAssemblies.Add(file);
        }

        private void addInternalReference()
        {
            // 預設參考
            addReference("Microsoft.CSharp.dll");
            addReference("System.dll");
            addReference("System.Core.dll");
            addReference("System.Data.dll");
            addReference("System.Data.DataSetExtensions.dll");
            addReference("System.Deployment.dll");
            addReference("System.Drawing.dll");
            addReference("System.IO.Compression.dll");
            addReference("System.IO.Compression.FileSystem.dll");
            addReference("System.Net.Http.dll");
            addReference("System.Windows.Forms.dll");
            addReference("System.Xml.dll");
            addReference("System.Xml.Linq.dll");

            // WPF 支援
            addReference("WPF/PresentationCore.dll");
            addReference("WPF/PresentationFramework.dll");
            addReference("WPF/WindowsBase.dll");
            addReference("System.Xaml.dll");
        }

        public void addResourceFile(string file)
        {
            compilerParameter.EmbeddedResources.Add(file);
        }

        public void compile(string savePath, string icon, string platform, bool console, bool uac)
        {
            List<string> file = new List<string>();
            file.Add("RFC2898AESCrypto.cs"); // 單純不能以常規方式拆除
            file.Add("Unpacker.cs");
            file.Add("PackerVersion.cs");

            StringBuilder option = new StringBuilder();
            option.Append("/target:").Append(console ? "exe" : "winexe");
            option.Append(" /platform:").Append(platform);
            if (icon != null)
            {
                option.Append(" /win32icon:").Append(icon);
            }
            if (uac)
            {
                option.Append(" /win32manifest:package.manifest");
            }

            compilerParameter.CompilerOptions = option.ToString();
            compilerParameter.OutputAssembly = savePath;

            CompilerResults result = codeProvider.CompileAssemblyFromFile(compilerParameter, file.ToArray());
            CompilerErrorCollection errorCollection = result.Errors;
            if (errorCollection.HasErrors)
            {
                StringBuilder ex = new StringBuilder();
                foreach (CompilerError error in errorCollection)
                {
                    ex.AppendLine(error.ToString());
                }
                throw new Exception(ex.ToString());
            }
        }
    }
}