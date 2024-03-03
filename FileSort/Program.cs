

using System.Text;

namespace FileSort
{
    class Program
    {
        private static byte[] make_bytes(int x)
        {
            return Encoding.UTF8.GetBytes($"{x} ");
        }
        public static void SplitFile(string filename)
        {
            string first_fn = filename + ".A";
            string second_fn = filename + ".B";
            FileStream[] F = new FileStream[2];
            F[0] = new FileStream(first_fn, FileMode.Create);
            F[1] = new FileStream(second_fn, FileMode.Create);

            FileIntReader fir = new FileIntReader(filename);
            int x1 = fir.NextInt();
            int x2;
            int n = 0;
            while(x1 >= 0)
            {
                F[n].Write(make_bytes(x1));
                x2 = fir.NextInt();
                if(x1 > x2)
                {
                    n = 1 - n;
                }
                x1 = x2;
            }

            F[0].Close();
            F[1].Close();
            return;
        }
        private static int[] Merge(int[] a, int[] b)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            int n = a.Length;
            int m = b.Length;
            int[] result = new int[n + m];
            while (i < n && j < m)
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
            if (i < n)
            {
                while (i < n)
                {
                    result[k++] = a[i++];
                }
            }
            else
            {
                while (j < m)
                {
                    result[k++] = b[j++];
                }
            }
            return result;
        }
        public static void FileSort(string path)
        {
            SplitFile(path);
        }

        public static void Main()
        {
            string fn = @"D:\SharpLabs\SharpLabs\FileSort\1.txt";
            FileSort(fn);
            
        }
    }
}