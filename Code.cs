using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ClassLibraryStorage;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Lab6
{
    public class DrawFigures
    {
        private Bitmap bitmap;
        private Pen blackPen;
        private Pen greenPen;
        private Graphics g;
        private Brush brush = null;

        public DrawFigures(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            g = Graphics.FromImage(bitmap);
            ClearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            greenPen = new Pen(Color.LawnGreen);
            greenPen.Width = 2;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void ClearSheet()
        {
            g.Clear(Color.White);
        }

        public Point MoveFigure(int x, int y, string direction)
        {
            if (direction == "up")
                y = y - 5;
            else if (direction == "down")
                y = y + 5;
            else if (direction == "right")
                x = x + 5;
            else if (direction == "left")
                x = x - 5;

            return new Point(x, y);
        }

        public void DrawCircle(int x, int y, int R, bool selected, string color)
        {
            brush = new SolidBrush(Color.FromName(color));

            g.FillEllipse(brush, (x - R), (y - R), 2 * R, 2 * R);

            brush.Dispose();

            if (selected)
                g.DrawEllipse(greenPen, (x - R), (y - R), 2 * R, 2 * R);
            else
                g.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void DrawTriangle(Point[] points, bool selected, string color)
        {
            brush = new SolidBrush(Color.FromName(color));

            g.FillPolygon(brush, points);

            brush.Dispose();

            if (selected)
                g.DrawPolygon(greenPen, points);
            else
                g.DrawPolygon(blackPen, points);
        }

        public void DrawSquare(int x, int y, int a, bool selected, string color)
        {
            brush = new SolidBrush(Color.FromName(color));

            g.FillRectangle(brush, x, y, a, a);

            brush.Dispose();

            if (selected)
                g.DrawRectangle(greenPen, x, y, a, a);
            else
                g.DrawRectangle(blackPen, x, y, a, a);
        }

        public void DrawStorage(MyStorage storage)
        {
            for (storage.first(); !storage.isEOL(); storage.next())
                if (storage.getObject() != null)
                    storage.getObject().Draw();
        }

        public void UnselectAll(MyStorage storage)
        {
            for (storage.first(); !storage.isEOL(); storage.next())
                if (storage.getObject() != null)
                    storage.getObject().Unselect();
        }
    }

    public class CCircle : CShape
    {
        private DrawFigures draw;

        private int R;

        private Point[] extremePoints = new Point[4];

        public CCircle(int x, int y, DrawFigures G)
        {
            this.x = x;
            this.y = y;
            R = 30;
            draw = G;

            UpdateExtremePoints();
        }

        public override void UpdateExtremePoints()
        {
            extremePoints[0].X = x - R; extremePoints[0].Y = y; // лево
            extremePoints[1].X = x; extremePoints[1].Y = y - R; // верх
            extremePoints[2].X = x + R; extremePoints[2].Y = y; // право
            extremePoints[3].X = x; extremePoints[3].Y = y + R; // низ
        }

        public override void Draw()
        {
            draw.DrawCircle(x, y, R, selected, color);
        }

        public override void Move(string direction)
        {
            if (Movable(direction))
            {
                x = draw.MoveFigure(x, y, direction).X;
                y = draw.MoveFigure(x, y, direction).Y;
            }

            UpdateExtremePoints();
        }

        public override bool Movable(string direction)
        {
            Form1 form = new Form1();
            PictureBox sheet = form.GetSheet();

            if (direction == "up")
                return extremePoints[1].Y - 5 >= 0 ? true : false;
            else if (direction == "down")
                return extremePoints[3].Y + 5 <= sheet.Height ? true : false;
            else if (direction == "right")
                return extremePoints[2].X + 5 <= sheet.Width ? true : false;
            else if (direction == "left")
                return extremePoints[0].X - 5 >= 0 ? true : false;
            else
                return false;
        }

        public override void ChangeSize(string mode)
        {
            if (mode == "+")
                R += 5;
            else if (mode == "-" && R > 10)
                R -= 5;
        }

        public override void ChangeColor(string color)
        {
            this.color = color;
        }

        public override bool WasClicked(int x0, int y0)
        {
            return (Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2) <= R * R);
        }
    }

    public class CTriangle : CShape
    {
        private DrawFigures draw;

        private Point[] points = new Point[3];

        public CTriangle(int x, int y, DrawFigures G)
        {
            this.x = x;
            this.y = y;
            draw = G;

            UpdateExtremePoints();
        }

        public override void UpdateExtremePoints()
        {
            points[0].X = x; points[0].Y = y - 35;      // верх
            points[1].X = x - 35; points[1].Y = y + 25; // лево
            points[2].X = x + 35; points[2].Y = y + 25; // право
        }

        public override void Draw()
        {
            draw.DrawTriangle(points, selected, color);
        }

        public override void Move(string direction)
        {
            if (Movable(direction))
            {
                if (direction == "up")
                {
                    points[0].Y -= 5;
                    points[1].Y -= 5;
                    points[2].Y -= 5;
                }
                if (direction == "down")
                {
                    points[0].Y += 5;
                    points[1].Y += 5;
                    points[2].Y += 5;
                }
                if (direction == "left")
                {
                    points[0].X -= 5;
                    points[1].X -= 5;
                    points[2].X -= 5;
                }
                if (direction == "right")
                {
                    points[0].X += 5;
                    points[1].X += 5;
                    points[2].X += 5;
                }
            }
        }

        public override bool Movable(string direction)
        {
            Form1 form = new Form1();
            PictureBox sheet = form.GetSheet();

            if (direction == "up")
                return points[0].Y - 5 >= 0 ? true : false;
            else if (direction == "down")
                return points[2].Y + 5 <= sheet.Height ? true : false;
            else if (direction == "right")
                return points[2].X + 5 <= sheet.Width ? true : false;
            else if (direction == "left")
                return points[1].X - 5 >= 0 ? true : false;
            else
                return false;
        }

        public override void ChangeSize(string mode)
        {
            if (mode == "+")
            {
                points[0].Y -= 5;
                points[1].X -= 5; points[1].Y += 5;
                points[2].X += 5; points[2].Y += 5;
            }
            else if (mode == "-" && points[0].Y + 10 != points[1].Y)
            {
                points[0].Y += 5;
                points[1].X += 5; points[1].Y -= 5;
                points[2].X -= 5; points[2].Y -= 5;
            }    
        }

        public override void ChangeColor(string color)
        {
            this.color = color;
        }

        public override bool WasClicked(int x0, int y0)
        {
            int a = (points[0].X - x0) * (points[1].Y - points[0].Y) - (points[1].X - points[0].X) * (points[0].Y - y0);
            int b = (points[1].X - x0) * (points[2].Y - points[1].Y) - (points[2].X - points[1].X) * (points[1].Y - y0);
            int c = (points[2].X - x0) * (points[0].Y - points[2].Y) - (points[0].X - points[2].X) * (points[2].Y - y0);

            return (a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0);
        }
    }

    public class CSquare : CShape
    {
        private DrawFigures draw;

        private int a = 60; // сторона квадрата

        private Point[] extremePoints = new Point[2];

        public CSquare(int x, int y, DrawFigures G)
        {
            this.x = x;
            this.y = y;
            draw = G;

            UpdateExtremePoints();
        }

        public override void UpdateExtremePoints()
        {
            extremePoints[0].X = x - a / 2; extremePoints[0].Y = y - a / 2; // верхняя правая
            extremePoints[1].X = x + a / 2; extremePoints[1].Y = y + a / 2; // левая нижняя
        }

        public override void Draw()
        {
            draw.DrawSquare(x - a / 2, y - a / 2, a, selected, color);
        }

        public override void Move(string direction)
        {
            if (Movable(direction))
            {
                x = draw.MoveFigure(x, y, direction).X;
                y = draw.MoveFigure(x, y, direction).Y;
            }

            UpdateExtremePoints();
        }

        public override bool Movable(string direction)
        {
            Form1 form = new Form1();
            PictureBox sheet = form.GetSheet();

            if (direction == "up")
                return extremePoints[0].Y - 5 >= 0 ? true : false;
            else if (direction == "down")
                return extremePoints[1].Y + 5 <= sheet.Height ? true : false;
            else if (direction == "right")
                return extremePoints[1].X + 5 <= sheet.Width ? true : false;
            else if (direction == "left")
                return extremePoints[0].X - 5 >= 0 ? true : false;
            else
                return false;
        }

        public override void ChangeSize(string mode)
        {
            if (mode == "+")
                a += 10;
            else if (mode == "-")
                if (a > 10)
                    a -= 10;
        }

        public override void ChangeColor(string color)
        {
            this.color = color;
        }

        public override bool WasClicked(int x0, int y0)
        {
            return x0 >= x - a / 2 && y0 >= y - a / 2 && x0 <= x + a / 2 && y0 <= y + a / 2;
        }
    }
}
