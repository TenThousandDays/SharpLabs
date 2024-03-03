
namespace SharpLabs
{
    class Vector
    {
        private double x, y;

        public Vector(double x = 0.0, double y = 0.0)
        {
            this.x = x;
            this.y = y;
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public void setX(double x)
        {
            this.x = x;
        }

        public void setY(double y)
        {
            this.y = y;
        }

        public static bool operator == (Vector v1, Vector v2)
        {
            return v1.x == v2.x && v1.y == v2.y;
        }

        public static bool operator != (Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        public static Vector operator * (double n, Vector vec)
        {
            double new_x = n * vec.x;
            double new_y = n * vec.y;
            return new Vector(new_x, new_y);
        }

        public static double operator * (Vector v1, Vector v2)
        {
            double scalar = v1.x * v2.x + v1.y * v2.y;
            return scalar;
        }

        public static Vector operator - (Vector vec)
        {
            double new_x = -vec.x;
            double new_y = -vec.y;
            return new Vector(new_x, new_y);
        }
    }
}
