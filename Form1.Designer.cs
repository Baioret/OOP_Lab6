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
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
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
            this.panel.Controls.Add(this.btnSquare);
            this.panel.Controls.Add(this.btnCircle);
            this.panel.Controls.Add(this.btnTriangle);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(150, 643);
            this.panel.TabIndex = 1;
            // 
            // btnSquare
            // 
            this.btnSquare.Image = global::Lab6.Properties.Resources.SquareInact;
            this.btnSquare.Location = new System.Drawing.Point(23, 387);
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
            this.btnCircle.Location = new System.Drawing.Point(23, 156);
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
            this.btnTriangle.Location = new System.Drawing.Point(23, 272);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(100, 100);
            this.btnTriangle.TabIndex = 3;
            this.btnTriangle.TabStop = false;
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1099, 643);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.sheet);
            this.Name = "Form1";
            this.Text = "Визуальный редактор";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnCircle;
    }
}

