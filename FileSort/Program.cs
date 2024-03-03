﻿
file class FileIntReader
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
class Program
{
    private static int[] Merge(int[] a, int[] b)
    {
        int i = 0;
        int j = 0;
        int k = 0;

        int n = a.Length;
        int m = b.Length;
        int[] result = new int[n + m];
        while(i < n && j < m)
        {
            if (a[i] < b[j])
            {
                result[k++] = a[i++];
            }
            else
            {
                result[k++] = b[j++];
            }
        }
        if(i < n)
        {
            while(i < n)
            {
                result[k++] = a[i++];
            }
        }
        else
        {
            while(j < m)
            {
                result[k++] = b[j++];
            }
        }
        return result;
    }
    public static void FileSort(string path)
    {
        return;
    }

    public static void Main()
    {
        string fn = @"D:\SharpLabs\SharpLabs\FileSort\1.txt";
        FileSort(fn);
        //FileIntReader fir = new FileIntReader(fn);
        //int n = fir.NextInt();
        //while(n >= 0)
        //{
        //    Console.WriteLine($"Read from file: {n}");
        //    n = fir.NextInt();
        //}
    }
}