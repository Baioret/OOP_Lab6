using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryStorage;

namespace Lab6
{
    public partial class Form1 : Form
    {
        MyStorage storage; // хранилище
        DrawFigures G; // рисовальщик

        bool ctrlPressed = false;

        public Form1()
        {
            InitializeComponent();
            storage = new MyStorage();
            G = new DrawFigures(sheet.Width, sheet.Height);
        }

        private void sheet_MouseUp(object sender, MouseEventArgs e)
        {
            G.ClearSheet();

            bool wasClicked = false;

            for (storage.first(); !storage.isEOL(); storage.next())
                if (storage.getObject() is CCircle c)
                    if (c.WasClicked(e.X, e.Y) == true)
                    {
                        if (ctrlPressed == false)
                            G.UnselectAll(storage);

                        wasClicked = true;
                        c.Select();

                        break;
                    }


            if (wasClicked == false)
                NewObject(e.X, e.Y);
            else
            {
                G.DrawStorage(storage);
                sheet.Image = G.GetBitmap();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            G.DrawStorage(storage);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                ctrlPressed = true;


            if (e.KeyCode == Keys.Delete)
            {
                for (storage.first(); !storage.isEOL(); storage.next())
                    if (storage.getObject() is CCircle c)
                        if (c.Selected())
                            storage.del(c);

                G.ClearSheet();
                G.DrawStorage(storage);
                sheet.Image = G.GetBitmap();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                ctrlPressed = false;
        }

        private void NewObject(int x, int y)
        {
            G.UnselectAll(storage);
            G.DrawStorage(storage);

            //====================

            CCircle obj = new CCircle(x, y, G);

            //====================

            obj.DrawCircle();
            sheet.Image = G.GetBitmap();

            //====================

            storage.add(obj);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            sheet.Width = this.Size.Width - 166;
            sheet.Height = this.Size.Height - 39;
            panel.Height = this.Size.Height - 39;
        }
    }
}

