namespace FileSort
{
    class FileIntReader
    {
        private FileStream fs;
        private byte[] curr;
        private List<byte> buffer;

        public FileIntReader(string filename)
        {
            fs = new FileStream(filename, FileMode.Open);
            curr = new byte[1];
            buffer = new List<byte>();
        }

        public int NextInt()
        {
            int num;
            while (fs.Read(curr, 0, 1) != 0)
            {
                if (curr[0] != 0x20)
                {
                    buffer.Add(curr[0]);
                }
                else
                {
                    if (!int.TryParse(buffer.ToArray(), out num))
                    {
                        throw new Exception("Error while reading numbers from file!");
                    }
                    curr[0] = 0x00;
                    buffer.Clear();
                    return num;
                }
            }
            if (int.TryParse(buffer.ToArray(), out num))
            {
                curr[0] = 0x00;
                buffer.Clear();
                return num;
            }
            fs.Close();
            return -1;
        }
    }
}