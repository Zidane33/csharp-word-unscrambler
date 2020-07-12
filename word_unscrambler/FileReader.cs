using System;
using System.IO;

namespace word_unscrambler
{
    internal class FileReader
    {
        public string[] Read(string filename)
        {
            try
            {
                string[] fileContent = File.ReadAllLines(filename);
                return fileContent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
