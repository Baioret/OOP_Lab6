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

        public void DrawTriangle(int x, int y, bool selected)
        {
            Point[] points = new Point[3];

            points[0].X = x; points[0].Y = y - 15;
            points[1].X = x - 35; points[1].Y = y + 45;
            points[2].X = x + 35; points[2].Y = y + 45;

            if (selected)
                g.DrawPolygon(greenPen, points);
            else
                g.DrawPolygon(blackPen, points);
        }

        public void DrawSquare()
        {

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

        override public bool WasClicked(int coordX, int coordY)
        {
            if (Math.Pow(x - coordX, 2) + Math.Pow(y - coordY, 2) <= R * R)
                return true;
            else
                return false;
        }
    }

    public class CTriangle : CShape
    {
        DrawFigures draw;

        public CTriangle(int x, int y, DrawFigures G)
        {
            this.x = x;
            this.y = y;
            draw = G;
        }

        public override void Draw()
        {
            draw.DrawTriangle(x, y, selected);
        }

        override public bool WasClicked(int coordX, int coordY)
        {
            return true;
        }
    }

    public class CSquare : CShape
    {
        DrawFigures draw;

        private int a;

        public CSquare(int x, int y, DrawFigures G)
        {
            this.x = x;
            this.y = y;
            draw = G;
        }

        public override void Draw()
        {
            draw.DrawSquare();
        }

        public override bool WasClicked(int coordX, int coordY)
        {
            return true;
        }
    }
}
