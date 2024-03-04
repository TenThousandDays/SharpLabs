namespace FileSort
{
    class FileIntReader
    {
        private FileStream fs;
        private byte[] cur;
        private List<byte> buffer;

        public FileIntReader(string filename)
        {
            fs = new FileStream(filename, FileMode.Open);
            cur = new byte[1];
            buffer = new List<byte>();
        }

        public int NextInt()
        {
            int num;
            while (fs.Read(cur, 0, 1) != 0)
            {
                if (cur[0] != 0x20)
                {
                    buffer.Add(cur[0]);
                }
                else
                {
                    if (!int.TryParse(buffer.ToArray(), out num))
                    {
                        throw new Exception("Error while reading numbers from file!");
                    }
                    cur[0] = 0x00;
                    buffer.Clear();
                    return num;
                }
            }
            if (int.TryParse(buffer.ToArray(), out num))
            {
                cur[0] = 0x00;
                buffer.Clear();
                return num;
            }
            Close();
            return -1;
        }

        public void Close()
        {
            fs.Close();
        }
    }
}