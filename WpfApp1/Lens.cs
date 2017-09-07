using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

public class Lens
{
    public double index, radius1, radius2, thickness, diameter;

    public Lens()
	{
	}

    public Lens(double i, double r1, double r2, double t, double d)
    {
        index = i;
        radius1 = r1;
        radius2 = r2;
        thickness = t;
        diameter = d;
    }

    public void Draw(Canvas canvas)
    {
        Point midpoint = new Point(canvas.Width / 2, canvas.Height / 2);
        Point pointA = new Point(midpoint.X + radius1 - (thickness / 2) - (Math.Sqrt(Math.Pow(radius1, 2) - Math.Pow((diameter / 2), 2))), midpoint.Y - (diameter / 2));
        Point pointB = new Point(pointA.X, pointA.Y + diameter);
        Point pointC = new Point(midpoint.X + (thickness / 2) - radius2 + (Math.Sqrt(Math.Pow(radius2, 2) - Math.Pow((diameter / 2), 2))), pointB.Y);
        Point pointD = new Point(pointC.X, pointA.Y);
        Double size1 = (thickness / 2) - (midpoint.X - pointA.X);
        Double size2 = (thickness / 2) + (midpoint.X - pointD.X);

        ArcSegment surface1 = new ArcSegment();
        surface1.Point = pointB;
        surface1.Size = new Size(radius1, radius1);
        surface1.SweepDirection = SweepDirection.Counterclockwise;
        surface1.IsLargeArc = false;
        surface1.RotationAngle = 0;

        LineSegment bottom = new LineSegment();
        bottom.Point = pointC;

        ArcSegment surface2 = new ArcSegment();
        surface2.Point = pointD;
        surface2.Size = new Size(radius2, radius2);
        surface2.SweepDirection = SweepDirection.Counterclockwise;
        surface2.IsLargeArc = false;
        surface2.RotationAngle = 0;

        LineSegment top = new LineSegment();
        top.Point = pointA;


        PathFigure lens1 = new PathFigure();
        lens1.StartPoint = pointA;
        lens1.Segments.Add(surface1);
        lens1.Segments.Add(bottom);
        lens1.Segments.Add(surface2);
        lens1.Segments.Add(top);

        PathGeometry SurfaceGeometry = new PathGeometry();
        SurfaceGeometry.Figures.Add(lens1);

        Path surfaces = new Path();
        surfaces.StrokeThickness = 1;
        surfaces.Stroke = Brushes.Black;
        surfaces.Data = SurfaceGeometry;

        canvas.Children.Add(surfaces);
    }
}
