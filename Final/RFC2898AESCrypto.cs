using System;
using System.IO;
using System.Security.Cryptography;

namespace Crypto
{
    public static class RFC2898AESCrypto
    {
        // Legacy : 我需要更好的資料
        private static readonly byte[] SALT = new byte[]
        {
            0x41, 0x6B, 0x61, 0x74, 0x73,
            0x75, 0x6B, 0x69, 0x4A, 0x69,
            0x61, 0x49, 0x73, 0x56, 0x65,
            0x72, 0x79, 0x43, 0x75, 0x74,
            0x65
        };

        private static readonly byte[] SHARE_SECRET = new byte[] {
            0x63, 0x6F, 0x6D, 0x2E, 0x6D,
            0x65, 0x6F, 0x77, 0x2E, 0x73,
            0x6D, 0x61, 0x6C, 0x6C, 0x71,
            0x75, 0x69, 0x6C, 0x74
        };

        private const int ITERATION = 1500;
        private const int READ_BUFFER_SIZE = 4096;

        // 型態已簡化
        public static byte[] AESEncrypt(MemoryStream plain)
        {
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(SHARE_SECRET, SALT, ITERATION);
            RijndaelManaged aes = new RijndaelManaged();
            aes.Key = key.GetBytes(aes.KeySize / 8);
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(BitConverter.GetBytes(aes.IV.Length), 0, sizeof(int));
                ms.Write(aes.IV, 0, aes.IV.Length);
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    plain.CopyTo(cs);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
        }

        public static MemoryStream AESDecrypt(Stream stream)
        {
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(SHARE_SECRET, SALT, ITERATION);
            RijndaelManaged aes = new RijndaelManaged();
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = readLengthByteArray(stream);
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using (CryptoStream cs = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
            {
                using (BinaryReader br = new BinaryReader(cs))
                {
                    MemoryStream ret = new MemoryStream();
                    byte[] buffer = new byte[READ_BUFFER_SIZE];
                    int count;
                    while ((count = br.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        ret.Write(buffer, 0, count);
                    }
                    ret.Position = 0;
                    return ret;
                }
            }
        }

        public static byte[] readAllByte(Stream stream)
        {
            using (MemoryStream ret = new MemoryStream())
            {
                stream.CopyTo(ret);
                return ret.ToArray();
            }
        }

        private static byte[] readLengthByteArray(Stream stream)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (stream.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new IndexOutOfRangeException("無效的長度格式");
            }
            byte[] ret = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (stream.Read(ret, 0, ret.Length) != ret.Length)
            {
                throw new IndexOutOfRangeException("無效的資料長度");
            }
            return ret;
        }
    }
}