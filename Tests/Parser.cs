namespace WorkTests
{
    /// <summary>
    /// thread safe work
    /// </summary>
    internal class Parser
    {
        private FileStream _file;

        public void setFile(FileStream f)
        {
            _file = f;
        }

        public FileStream getFile()
        {
            return _file;
        }

        public string GetContent()
        {
            var i = new StreamReader(_file);
            var output = "";
            int data;
            while ((data = i.Read()) > 0)
            {
                output += (char)data;
            }

            return output;
        }

        public void SaveContent(string content)
        {
            var o = new StreamWriter(_file);
            for (int i = 0; i < content.Length; i += 1)
            {
                o.Write(content[i]);
            }
        }
    }
}
