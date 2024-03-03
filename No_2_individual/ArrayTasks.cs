/* 
 * #8: На плоскости заданы n точек с координатами (x[i], y[i]).
 * Расположить их в порядке возрастания их расстояния от (0, 0).

 * #25: Умножение матриц.
*/


class Point : IComparable<Point>
{
    private double x, y;

    public Point(double x = 0.0, double y = 0.0)
    {
        this.x = x;
        this.y = y;
    }

    public double X
    {
        get => x;
        set => x = value;
    }

    public double Y
    {
        get => y;
        set => y = value;
    }

    public double Distance()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public override string ToString()
    {
        return $"({x},{y})";
    }

    public int CompareTo(Point other)
    {
        if (this == other)
        {
            return 0;
        }
        double d1 = this.Distance();
        double d2 = other.Distance();
        return d1.CompareTo(d2);
    }
}

class Matrix
{
    private int rows, cols;
    private int[,] mtx;

    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        mtx = new int[rows, cols];
    }

    public int nRows
    {
        get => rows;
    }

    public int nCols
    {
        get => cols;
    }

    public int this[int i, int j]
    {
        get => mtx[i, j];
        set => mtx[i, j] = value;
    }

    public void fillRandom()
    {
        Random rnd = new Random();
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                mtx[i, j] = rnd.Next(-10, 10);
            }
        }
    }

    public static Matrix operator * (Matrix m1, Matrix m2)
    {
        if(m1.cols != m2.rows)
        {
            throw new Exception("Can't multiply these matrices!");
        }
        Matrix res = new Matrix(m1.rows, m2.cols);
        for(int i = 0; i < m1.rows; i++)
        {
            for(int j = 0; j < m2.cols; j++)
            {
                res[i, j] = 0;
                for(int k = 0; k < m1.cols; k++)
                {
                    res[i, j] += m1[i, k] * m2[k, j];
                }
            }
        }
        return res;
    }

    public override string ToString()
    {
        string res = "";
        res += $"({rows} x {cols})\n";
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                res += $"{mtx[i, j]}\t";
            }
            res += "\n";
        }
        return res;
    }
}
class ArrayTasks
{
    public static int PointTest()
    {
        Console.Write("Enter n of points: ");
        string? input = Console.ReadLine();
        int n_pts;
        if (!Int32.TryParse(input, out n_pts))
        {
            Console.WriteLine("Invalid input!");
            return -1;
        }
        List<Point> pts = new List<Point>();

        Random rnd = new Random();
        for (int i = 0; i < n_pts; i++)
        {
            Point p = new Point();
            p.X = rnd.Next(-10, 10);
            p.Y = rnd.Next(-10, 10);
            pts.Add(p);
        }
        pts.Sort();
        for (int i = 0; i < n_pts; i++)
        {
            double d = pts[i].Distance();
            Console.WriteLine($"#{i + 1} {pts[i]} Distance: {d.ToString("#.###")}");
        }
        return 0;
    }

    public static int MatrixTest()
    {
        int m1, n1, m2, n2;
        Console.WriteLine("Enter Matrix #1 row count: ");
        m1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Matrix #1 col count: ");
        n1 = int.Parse(Console.ReadLine());
        Matrix mtx1 = new Matrix(m1, n1);
        mtx1.fillRandom();

        Console.WriteLine("Enter Matrix #2 row count: ");
        m2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Matrix #2 col count: ");
        n2 = int.Parse(Console.ReadLine());
        Matrix mtx2 = new Matrix(m2, n2);
        mtx2.fillRandom();

        Console.WriteLine("Matrix 1: ");
        Console.WriteLine(mtx1);
        Console.WriteLine("Matrix 2: ");
        Console.WriteLine(mtx2);

        try
        {
            Matrix result = mtx1 * mtx2;
            Console.WriteLine("M1 * M2: ");
            Console.WriteLine(result);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return -1;
        }

        return 0;
    }
    public static int Main(string[] args)
    {
        // return PointTest();
        return MatrixTest();
    }
}