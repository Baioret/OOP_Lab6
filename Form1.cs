using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClassLibraryStorage;

namespace Lab6
{
    public partial class Form1 : Form
    {
        CShapeStorage storage; // хранилище
        DrawFigures G; // рисовальщик
        CShapeFactory factory; // фабрика фигур (для загрузки из файла)

        bool ctrlPressed;

        public Form1()
        {
            InitializeComponent();
            storage = new CShapeStorage();
            G = new DrawFigures(sheet);

            factory = new CMyShapeFactory();

            foreach (var color in Enum.GetNames(typeof(KnownColor)))
                colorList.Items.Add(color.ToString());
        }

        public ref PictureBox GetSheet()
        {
            return ref sheet;
        }

        public ref DrawFigures GetDrawFigures()
        {
            return ref G;
        }

        private void sheet_MouseUp(object sender, MouseEventArgs e)
        {
            G.ClearSheet();

            bool wasClicked = false;

            CShape curr = null;

            for (storage.first(); !storage.isEOL(); storage.next())
                if (storage.getObject() is CShape c)
                    if (c.WasClicked(e.X, e.Y) == true)
                        curr = c;

            if (curr != null)
            {
                if (ctrlPressed == false)
                    G.UnselectAll(storage);

                wasClicked = true;
                curr.Select();
            }

            if (wasClicked == false)
                NewObject(e.X, e.Y);
            else
                UpdateSheet();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            G.ClearSheet();
            G.DrawStorage(storage);
            sheet.Image = G.GetBitmap();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                ctrlPressed = true;

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                for (storage.first(); !storage.isEOL(); storage.next())
                    if (storage.getObject() is CShape c)
                        if (c.Selected())
                        {
                            if (e.KeyCode == Keys.Up)
                                c.Move("up");
                            if (e.KeyCode == Keys.Down)
                                c.Move("down");
                            if (e.KeyCode == Keys.Right)
                                c.Move("right");
                            if (e.KeyCode == Keys.Left)
                                c.Move("left");
                        }


                UpdateSheet();
            }

            if (ctrlPressed == true && (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.OemMinus))
            {
                for (storage.first(); !storage.isEOL(); storage.next())
                    if (storage.getObject() is CShape c)
                        if (c.Selected())
                        {
                            if (e.KeyCode == Keys.Oemplus)
                                c.ChangeSize("+");
                            else if (e.KeyCode == Keys.OemMinus)
                                c.ChangeSize("-");
                        }

                UpdateSheet();
            }

            if (e.KeyCode == Keys.Delete)
            {
                for (storage.first(); !storage.isEOL(); storage.next())
                    if (storage.getObject() is CShape c)
                        if (c.Selected())
                            storage.del(c);


                UpdateSheet();
            }
        }

        private void UpdateSheet()
        {
            G.ClearSheet();
            G.DrawStorage(storage);
            sheet.Image = G.GetBitmap();
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

            CShape obj = null;

            if (btnCircle.Enabled == false)
                obj = new CCircle(x, y, G);
            else if (btnTriangle.Enabled == false)
                obj = new CTriangle(x, y, G);
            else if (btnSquare.Enabled == false)
                obj = new CSquare(x, y, G);

            //====================

            if (obj != null)
                obj.Draw();
            sheet.Image = G.GetBitmap();

            //====================

            storage.add(obj);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            sheet.Width = this.Size.Width - panel.Width - 16;
            sheet.Height = this.Size.Height - 39;
            panel.Height = this.Size.Height - 39;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            btnCircle.Enabled = false;
            btnTriangle.Enabled = true;
            btnSquare.Enabled = true;

            ActiveControl = sheet;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            btnCircle.Enabled = true;
            btnTriangle.Enabled = false;
            btnSquare.Enabled = true;

            ActiveControl = sheet;
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            btnCircle.Enabled = true;
            btnTriangle.Enabled = true;
            btnSquare.Enabled = false;

           ActiveControl = sheet;
        }

        private void colorList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            colorPreview.BackColor = Color.FromName(colorList.SelectedItem.ToString());
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            if (colorList.SelectedItem != null)
            {
                for (storage.first(); !storage.isEOL(); storage.next())
                    if (storage.getObject() is CShape c)
                        if (c.Selected())
                            c.ChangeColor(colorList.SelectedItem.ToString());

                UpdateSheet();

                ActiveControl = sheet;
            }
        }

        private void colorList_DropDownClosed(object sender, EventArgs e)
        {
            ActiveControl = sheet;
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            CSGroup group = new CSGroup();

            for (storage.first(); !storage.isEOL(); storage.next())
                if (storage.getObject() is CShape c)
                    if (c.Selected())
                    {
                        group.Add(c);
                        storage.del(c);
                    }

            storage.add(group);
            ActiveControl = sheet;

            UpdateSheet();
        }

        private void btnUngroup_Click(object sender, EventArgs e)
        {
            for (storage.first(); !storage.isEOL(); storage.next())
                if (storage.getObject() is CSGroup c)
                    if (c.Selected())
                    {
                        int size = c.Size();

                        storage.del(c);

                        for (int i = 0; i < size; i++)
                            storage.add(c.GetObject(i));
                    }

            UpdateSheet();

            ActiveControl = sheet;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter stream = new StreamWriter("D://CPP/OOP/Lab6/Shapes.txt", false);

            for (storage.first(); !storage.isEOL(); storage.next())
                if (storage.getObject() is CShape c)
                    c.Save(stream);

            stream.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            StreamReader stream = new StreamReader("D://CPP/OOP/Lab6/Shapes.txt", false);

            storage.loadShapes(stream, factory, G);

            stream.Close();
        }
    }
}

