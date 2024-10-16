using System.Drawing;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TrackBar trackBarThickness;

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.trackBarThickness = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(205, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(567, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnLine
            // 
            this.btnLine.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLine.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnLine.ForeColor = System.Drawing.Color.White;
            this.btnLine.Location = new System.Drawing.Point(29, 31);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(130, 38);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "Линия";
            this.btnLine.UseVisualStyleBackColor = false;
            // 
            // btnCircle
            // 
            this.btnCircle.BackColor = System.Drawing.Color.LightCoral;
            this.btnCircle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCircle.ForeColor = System.Drawing.Color.White;
            this.btnCircle.Location = new System.Drawing.Point(29, 92);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(130, 36);
            this.btnCircle.TabIndex = 2;
            this.btnCircle.Text = "Круг";
            this.btnCircle.UseVisualStyleBackColor = false;
            // 
            // btnSquare
            // 
            this.btnSquare.BackColor = System.Drawing.Color.LightGreen;
            this.btnSquare.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSquare.ForeColor = System.Drawing.Color.White;
            this.btnSquare.Location = new System.Drawing.Point(29, 144);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(130, 33);
            this.btnSquare.TabIndex = 3;
            this.btnSquare.Text = "Квадрат";
            this.btnSquare.UseVisualStyleBackColor = false;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.MediumPurple;
            this.btnColor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(29, 195);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(130, 34);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "Цвет";
            this.btnColor.UseVisualStyleBackColor = false;
            // 
            // trackBarThickness
            // 
            this.trackBarThickness.BackColor = System.Drawing.Color.White;
            this.trackBarThickness.Location = new System.Drawing.Point(12, 249);
            this.trackBarThickness.Minimum = 1;
            this.trackBarThickness.Name = "trackBarThickness";
            this.trackBarThickness.Size = new System.Drawing.Size(169, 56);
            this.trackBarThickness.TabIndex = 5;
            this.trackBarThickness.Value = 2;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 476);
            this.Controls.Add(this.trackBarThickness);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnSquare);
            this.Controls.Add(this.btnCircle);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Программа для рисования";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
