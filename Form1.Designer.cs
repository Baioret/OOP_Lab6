namespace Lab6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.sheet = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            this.colorPreview = new System.Windows.Forms.Panel();
            this.lbPreview = new System.Windows.Forms.Label();
            this.lbChoose = new System.Windows.Forms.Label();
            this.colorList = new System.Windows.Forms.ComboBox();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnChangeColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.Window;
            this.sheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sheet.Location = new System.Drawing.Point(150, 0);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(949, 643);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.sheet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseUp);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Ivory;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.btnChangeColor);
            this.panel.Controls.Add(this.colorPreview);
            this.panel.Controls.Add(this.lbPreview);
            this.panel.Controls.Add(this.lbChoose);
            this.panel.Controls.Add(this.colorList);
            this.panel.Controls.Add(this.btnSquare);
            this.panel.Controls.Add(this.btnCircle);
            this.panel.Controls.Add(this.btnTriangle);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(150, 643);
            this.panel.TabIndex = 1;
            // 
            // colorPreview
            // 
            this.colorPreview.BackColor = System.Drawing.Color.White;
            this.colorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPreview.Location = new System.Drawing.Point(23, 115);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(100, 100);
            this.colorPreview.TabIndex = 7;
            // 
            // lbPreview
            // 
            this.lbPreview.AutoSize = true;
            this.lbPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPreview.Location = new System.Drawing.Point(20, 88);
            this.lbPreview.Name = "lbPreview";
            this.lbPreview.Size = new System.Drawing.Size(58, 16);
            this.lbPreview.TabIndex = 6;
            this.lbPreview.Text = "Preview:";
            // 
            // lbChoose
            // 
            this.lbChoose.AutoSize = true;
            this.lbChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbChoose.Location = new System.Drawing.Point(20, 19);
            this.lbChoose.Name = "lbChoose";
            this.lbChoose.Size = new System.Drawing.Size(90, 16);
            this.lbChoose.TabIndex = 5;
            this.lbChoose.Text = "Choose color:";
            // 
            // colorList
            // 
            this.colorList.FormattingEnabled = true;
            this.colorList.Location = new System.Drawing.Point(23, 44);
            this.colorList.Name = "colorList";
            this.colorList.Size = new System.Drawing.Size(100, 21);
            this.colorList.TabIndex = 2;
            this.colorList.TabStop = false;
            this.colorList.SelectionChangeCommitted += new System.EventHandler(this.colorList_SelectionChangeCommitted);
            this.colorList.DropDownClosed += new System.EventHandler(this.colorList_DropDownClosed);
            // 
            // btnSquare
            // 
            this.btnSquare.Image = global::Lab6.Properties.Resources.SquareInact;
            this.btnSquare.Location = new System.Drawing.Point(23, 520);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(100, 100);
            this.btnSquare.TabIndex = 4;
            this.btnSquare.TabStop = false;
            this.btnSquare.UseVisualStyleBackColor = true;
            this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Image = global::Lab6.Properties.Resources.CircleInact;
            this.btnCircle.Location = new System.Drawing.Point(23, 289);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(100, 100);
            this.btnCircle.TabIndex = 2;
            this.btnCircle.TabStop = false;
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Image = global::Lab6.Properties.Resources.TriangleInact;
            this.btnTriangle.Location = new System.Drawing.Point(23, 405);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(100, 100);
            this.btnTriangle.TabIndex = 3;
            this.btnTriangle.TabStop = false;
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeColor.Location = new System.Drawing.Point(23, 235);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(100, 26);
            this.btnChangeColor.TabIndex = 2;
            this.btnChangeColor.TabStop = false;
            this.btnChangeColor.Text = "Change color";
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1099, 643);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.sheet);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Визуальный редактор";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Panel colorPreview;
        private System.Windows.Forms.Label lbPreview;
        private System.Windows.Forms.Label lbChoose;
        private System.Windows.Forms.ComboBox colorList;
        private System.Windows.Forms.Button btnChangeColor;
    }
}

