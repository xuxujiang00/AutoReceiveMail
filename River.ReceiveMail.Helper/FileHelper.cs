using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace River.ReceiveMail.Helper
{
    public class FileHelper
    {
        /// <summary>
        /// 保存数据到指定位置 eml格式
        /// </summary>
        /// <param name="b"></param>
        /// <param name="outputFile"></param>
        public static void SaveFileFromBytes(byte[] b, String outputFile)
        {
            try
            {
                File.WriteAllBytes(outputFile, b);
            }
            catch
            {
                throw new ArgumentException("数据保存在本地文件出错");
            }
        }

        /// <summary>
        /// 判断是否需要创建文件夹
        /// </summary>
        /// <param name="pathStr"></param>
        public static void CreateFile(string pathStr)
        {
            if (!Directory.Exists(pathStr))
                Directory.CreateDirectory(pathStr);
        }
    }
}
