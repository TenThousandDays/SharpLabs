

using System.Text;

namespace FileSort
{
    class Program
    {
        private static byte[] make_bytes(int x)
        {
            return Encoding.UTF8.GetBytes($"{x} ");
        }
        public static void SplitFile(string filename, string out_fn_1, string out_fn_2)
        {
            FileStream[] F = new FileStream[2];
            F[0] = new FileStream(out_fn_1, FileMode.Create);
            F[1] = new FileStream(out_fn_2, FileMode.Create);

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
            fir.Close();
            return;
        }

        public static void MergeFiles(string in_file_1, string in_file_2, string out_file_1, string out_file_2)
        {
            FileIntReader[] S = new FileIntReader[2];
            S[0] = new FileIntReader(in_file_1);
            S[1] = new FileIntReader(in_file_2);
            
            FileStream[] F = new FileStream[2];
            F[0] = new FileStream(out_file_1, FileMode.Create);
            F[1] = new FileStream(out_file_2, FileMode.Create);

            int[] x = new int[2];
            int[] y = new int[2];
            int n, m;
            n = m = 0;

            x[0] = S[0].NextInt();
            x[1] = S[1].NextInt();
            while (x[0] >= 0 && x[1] >= 0)
            {
                if (x[m] > x[1 - m])
                {
                    m = 1 - m;
                }
                F[n].Write(make_bytes(x[m]));
                y[m] = S[m].NextInt();
                if (y[m] < 0 || x[m] > y[m])
                {
                    m = 1 - m;
                    F[n].Write(make_bytes(x[m]));
                    y[m] = S[m].NextInt();
                    while (y[m] >= 0 && x[m] <= y[m])
                    {
                        x[m] = y[m];
                        F[n].Write(make_bytes(x[m]));
                        y[m] = S[m].NextInt();
                    }
                    x[1 - m] = y[1 - m];
                    n = 1 - n;
                }
                x[m] = y[m];
            }

            // !!!
            while (y[0] >= 0)
            {
                F[n].Write(make_bytes(x[0]));
                y[0] = S[0].NextInt();
                if (x[0] > y[0])
                {
                    n = 1 - n;
                }
                x[0] = y[0];
            }
            while (y[1] >= 0)
            {
                F[n].Write(make_bytes(x[1]));
                y[1] = S[1].NextInt();
                if (x[1] > y[1])
                {
                    n = 1 - n;
                }
                x[1] = y[1];
            }
            F[0].Close();
            F[1].Close();
            S[0].Close();
            S[1].Close();
        }

        public static void FileSort(string path)
        {
            string f_1 = path + ".A";
            string f_2 = path + ".B";
            string s_1 = f_1 + ".A";
            string s_2 = f_2 + ".B";
            List<string> files = [f_1, f_2, s_1, s_2];

            try
            {
                SplitFile(path, f_1, f_2);
                long file_len;
                while (true)
                {
                    file_len = new FileInfo(f_1).Length;
                    if (file_len == 0)
                    {
                        return;
                    }
                    MergeFiles(f_1, f_2, s_1, s_2);
                    file_len = new FileInfo(s_1).Length;
                    if (file_len == 0)
                    {
                        return;
                    }
                    MergeFiles(s_1, s_2, f_1, f_2);
                }
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }

        public static void Main()
        {
            string fn = @"D:\SharpLabs\SharpLabs\FileSort\1.txt";
            FileSort(fn);
        }
    }
}