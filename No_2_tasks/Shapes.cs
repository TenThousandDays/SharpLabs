
namespace SharpLabs
{
    class Point
    {
        private double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"x: {x}, y: {y}";
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
    }

    abstract class Shape
    {
        public abstract double area();
        public abstract double perimeter();
    }

    class Circle : Shape
    {
        private Point center;
        private double radius;

        public Circle(double x = 0.0, double y = 0.0, double r = 0)
        {
            center = new Point(x, y);
            radius = r;
        }

        public Point getCenter()
        {
            return center;
        }

        public double getRadius()
        {
            return radius;
        }

        public void setCenter(double x, double y)
        {
            center.setX(x);
            center.setY(y);
        }

        public void setRadius(double r)
        {
            radius = r;
        }

        public override double area()
        {
            return Math.PI * radius * radius;
        }

        public override double perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    class Triangle : Shape
    {
        private double a, b, c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double getA()
        {
            return a;
        }

        public double getB()
        {
            return b;
        }

        public double getC()
        {
            return c;
        }

        public override double area()
        {
            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }

        public override double perimeter()
        {
            return a + b + c;
        }
    }

    class SqTriangle : Triangle
    {
        private double a, b, c;

        public SqTriangle(double kat_1, double kat_2, double hypo) 
            : base(kat_1, kat_2, hypo)
        {
            if(hypo * hypo != kat_1 * kat_1 + kat_2 * kat_2)
            {
                throw new Exception("Triangle is not squared!");
            }
            this.a = kat_1;
            this.b = kat_2;
            this.c = hypo;
        }

        public new double area()
        {
            return a * b / 2;
        }
    }
}
