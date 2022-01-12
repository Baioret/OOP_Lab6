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
        Bitmap bitmap;
        Pen blackPen;
        Pen greenPen;
        Graphics g;

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

        public void DrawCircle(int x, int y, int R, bool selected)
        {
            //g.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);

            if (selected)
                g.DrawEllipse(greenPen, (x - R), (y - R), 2 * R, 2 * R);
            else
                g.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void DrawTriangle(Point[] points, bool selected)
        {
            if (selected)
                g.DrawPolygon(greenPen, points);
            else
                g.DrawPolygon(blackPen, points);
        }

        public void DrawSquare(int x, int y, int a, bool selected)
        {
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
        DrawFigures draw;

        private int R;

        public CCircle(int x, int y, DrawFigures G)
        {
            this.x = x;
            this.y = y;
            R = 30;
            draw = G;
        }

        public CCircle(CCircle obj, DrawFigures G)
        {
            x = obj.x;
            y = obj.y;
            R = obj.R;
            draw = G;
        }

        public override void Draw()
        {
            draw.DrawCircle(x, y, R, selected);
        }

        override public bool WasClicked(int x0, int y0)
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

            points[0].X = x; points[0].Y = y - 35;
            points[1].X = x - 35; points[1].Y = y + 25;
            points[2].X = x + 35; points[2].Y = y + 25;
        }

        public override void Draw()
        {
            draw.DrawTriangle(points, selected);
        }

        override public bool WasClicked(int x0, int y0)
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

        public CSquare(int x, int y, DrawFigures G)
        {
            this.x = x;
            this.y = y;
            draw = G;
        }

        public override void Draw()
        {
            draw.DrawSquare(x - a / 2, y - a / 2, a, selected);
        }

        public override bool WasClicked(int x0, int y0)
        {
            return x0 >= x - a / 2 && y0 >= y - a / 2 && x0 <= x + a && y0 <= y + a;
        }
    }
}
