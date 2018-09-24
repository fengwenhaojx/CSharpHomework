using System;
public class simpleFactory
{
    public static shape createShape(string shapeKind, string shapeName)
    {
        shape myShape = null;
        if (shapeKind.Equals("square"))
        {
            myShape = new square(shapeName);
        }
        else if (shapeKind.Equals("circle"))
        {
            myShape = new circle(shapeName);
        }
        else if (shapeKind.Equals("rectangle"))
        {
            myShape = new rectangle(shapeName);
        }
        else if (shapeKind.Equals("delta"))
        {
            myShape = new delta(shapeName);
        }
        return myShape;
    }
}
public abstract class shape
{
    private string myID;
    public shape(string s)
    {
        myID = s;
    }
    public string ID
    {
        get
        {
            return myID;
        }
        set
        {
            myID = value;
        }
    }
    public abstract double area
    {
        get;
    }
    public void Draw()
    {
        Console.WriteLine("名字: " + this.ID);
        Console.WriteLine("面积：" + this.area);
    }


}
public class square : shape
{
    private int side;
    public square(string id, int si = 0) : base(id)
    {
        side = si;
    }
    public void setSide(int side)
    {
        this.side = side;
    }
    public override double area
    {
        get
        {
            return side * side;
        }
    }

}
public class circle : shape
{
    private int r;
    public circle(string id, int r = 0) : base(id)
    {
        this.r = r;
    }
    public void setR(int r)
    {
        this.r = r;
    }
    public override double area
    {
        get
        {
            return r * r * System.Math.PI;
        }
    }
}
public class rectangle : shape
{
    private int a;
    private int b;
    public rectangle(string id, int a = 0, int b = 0) : base(id)
    {
        this.a = a;
        this.b = b;
    }
    public void setAB(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    public override double area
    {
        get
        {
            return a * b;
        }
    }
}
public class delta : shape
{
    private int a;
    private int b;
    private int c;
    public delta(string id, int a = 0, int b = 0, int c = 0) : base(id)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
    public void setABC(int A, int B, int C)
    {
        if ((A + B) > C && (A + C) > B && (B + C) > A)
        {
            this.a = A;
            this.b = B;
            this.c = C;
        }
        else
        {
            Console.WriteLine("不能构成三角形");
        }
    }
    public override double area
    {
        get
        {
            double p = (a + b + c) / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            delta mySha = simpleFactory.createShape("delta", "delta 001") as delta;
            mySha.setABC(6, 4, 3);
            mySha.Draw();
            square mySquare = simpleFactory.createShape("square", "square 001") as square;
            mySquare.setSide(10);
            mySquare.Draw();

        }
    }
}