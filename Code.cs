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

        public void DrawCircle(int x, int y, int R)
        {
            //g.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            g.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void DrawSelectedCircle(int x, int y, int R)
        {
            //g.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            g.DrawEllipse(greenPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void DrawStorage(MyStorage storage)
        {
            for (storage.first(); !storage.isEOL(); storage.next())
                if (storage.getObject() is CCircle obj)
                    obj.DrawCircle();
        }

        public void UnselectAll(MyStorage storage)
        {
            for (storage.first(); !storage.isEOL(); storage.next())
                if (storage.getObject() is CCircle obj)
                    obj.Unselect();
        }
    }

    public class CCircle : CShape
    {
        DrawFigures draw;

        private int x, y, R;
        private bool selected = true;

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

        public void Select()
        {
            selected = true;
        }

        public void Unselect()
        {
            selected = false;
        }

        public bool Selected()
        {
            if (selected)
                return true;
            else
                return false;
        }

        public void DrawCircle()
        {
            if (Selected())
                draw.DrawSelectedCircle(x, y, R);
            else
                draw.DrawCircle(x, y, R);
        }

        public bool WasClicked(int coordX, int coordY)
        {
            if (Math.Pow(x - coordX, 2) + Math.Pow(y - coordY, 2) <= R * R)
                return true;
            else
                return false;
        }
    }
}
