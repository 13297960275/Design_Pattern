using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;

namespace _.NET中装饰者模式实现
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStream memoryStream = new MemoryStream(new byte[] {95,96,97,98,99});

            // 扩展缓冲的功能
            BufferedStream buffStream = new BufferedStream(memoryStream);

            // 添加加密的功能
            CryptoStream cryptoStream = new CryptoStream(memoryStream,new AesManaged().CreateEncryptor(),CryptoStreamMode.Write);
            // 添加压缩功能
            GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true);
        }
    }
}
