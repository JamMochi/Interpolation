namespace double2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load_Image = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.OpenImageDisplay = new System.Windows.Forms.PictureBox();
            this.Double = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // Load_Image
            // 
            this.Load_Image.Location = new System.Drawing.Point(521, 4);
            this.Load_Image.Name = "Load_Image";
            this.Load_Image.Size = new System.Drawing.Size(88, 39);
            this.Load_Image.TabIndex = 0;
            this.Load_Image.Text = "Load";
            this.Load_Image.UseVisualStyleBackColor = true;
            this.Load_Image.Click += new System.EventHandler(this.Load_Image_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(709, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(88, 39);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // OpenImageDisplay
            // 
            this.OpenImageDisplay.Location = new System.Drawing.Point(7, 49);
            this.OpenImageDisplay.Name = "OpenImageDisplay";
            this.OpenImageDisplay.Size = new System.Drawing.Size(790, 394);
            this.OpenImageDisplay.TabIndex = 2;
            this.OpenImageDisplay.TabStop = false;
            // 
            // Double
            // 
            this.Double.Location = new System.Drawing.Point(615, 4);
            this.Double.Name = "Double";
            this.Double.Size = new System.Drawing.Size(88, 39);
            this.Double.TabIndex = 3;
            this.Double.Text = "Double";
            this.Double.UseVisualStyleBackColor = true;
            this.Double.Click += new System.EventHandler(this.Double_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Double);
            this.Controls.Add(this.OpenImageDisplay);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Load_Image);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Load_Image;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.PictureBox OpenImageDisplay;
        private System.Windows.Forms.Button Double;
    }
}

