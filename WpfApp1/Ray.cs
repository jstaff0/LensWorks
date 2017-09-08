using System;
using System.Windows;
using System.Windows.Controls;

public class Ray
{
    public Point startPoint;
    public Vector direction;
    
    public Ray()
    {

    }

    public Ray(Point p, Vector d)
    {
        startPoint = p;
        direction = d;
    }

    public void Draw(Canvas canvas)
    {

    }
}
