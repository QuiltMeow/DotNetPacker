using DotNetPacker.Properties;
using System;
using System.IO;

namespace DotNetPacker
{
    public class Version
    {
        public const string FILE_NAME = "PackerVersion.cs";

        public string title
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public string company
        {
            get;
            set;
        }

        public string product
        {
            get;
            set;
        }

        public string copyright
        {
            get;
            set;
        }

        public string trademark
        {
            get;
            set;
        }

        public string assemblyVersion
        {
            get;
            set;
        }

        public string fileVersion
        {
            get;
            set;
        }

        public Version()
        {
            loadDefault();
        }

        public void loadDefault()
        {
            title = "Dot Net Packer";
            description = "Dot Net Packer Compress Executable";
            company = "Quilt Corporation";
            product = "Dot Net Packer";
            copyright = "Copyright © 2020 Quilt All Rights Reserved";
            trademark = string.Empty;
            assemblyVersion = "1.0.0.2";
            fileVersion = "1.0.0.9";
        }

        public void writeVersion()
        {
            string output = Resources.Version
                .Replace("{Title}", title)
                .Replace("{Description}", description)
                .Replace("{Company}", company)
                .Replace("{Product}", product)
                .Replace("{Copyright}", copyright)
                .Replace("{Trademark}", trademark)
                .Replace("{Guid}", Guid.NewGuid().ToString())
                .Replace("{AssemblyVersion}", assemblyVersion)
                .Replace("{FileVersion}", fileVersion);
            File.WriteAllText(FILE_NAME, output);
        }
    }
}