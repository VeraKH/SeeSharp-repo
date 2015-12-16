using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_Editor_4_Lb
{
    public interface IFileManager
    {
        string GetContent(string FilePath, Encoding encoding);
        string GetContent(string FilePath);
        void SaveContent(string content, string FilePath, Encoding encoding);
        void SaveContent(string FilePath, string content);
        bool isExist(string FilePath);
        int GetSymbolCount(string content);
    }

    public class FileManager : IFileManager
    {

        #region Checking file existence method

        public bool isExist(string FilePath)
        {
            bool isExist = File.Exists(FilePath);
            return isExist;
        }

        #endregion

        #region Open file and get content method

        public string GetContent(string FilePath, Encoding encoding)
        {
            string content = File.ReadAllText(FilePath, encoding);
            return content;
        }

        private readonly Encoding defaultEncoding = Encoding.GetEncoding(1251);

        public string GetContent(string FilePath)
        {
            return GetContent(FilePath, defaultEncoding);
        }

        #endregion

        #region Save file content method

        public void SaveContent(string content, string FilePath, Encoding encoding)
        {
            File.WriteAllText(FilePath, content, encoding);
        }

        public void SaveContent(string content, string FilePath)
        {

            SaveContent(content, FilePath, defaultEncoding);
        }

        #endregion

        #region Geting symbol count method

        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }

        #endregion 

    }
}
