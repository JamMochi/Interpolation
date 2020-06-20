using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace double2
{
    public partial class Form1 : Form
    {
        private int doubling = 0;
        private Bitmap doubleInstance = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Load_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagefileopen = new OpenFileDialog();
            imagefileopen.Filter = "Image Files(*.jpg;*.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg; *.gif; *.bmp; *.png";
            if (imagefileopen.ShowDialog() == DialogResult.OK)
            {
                OpenImageDisplay.Image = new Bitmap(imagefileopen.FileName);
                OpenImageDisplay.Size = OpenImageDisplay.Image.Size;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Color Interpolate(Bitmap bm, int x, int y)
        {
            int red = 0;
            int green = 0;
            int blue = 0;

            for(int i = -3; i < 4; i++)
            {
                Color originalColor = bm.GetPixel(x + i, y);
                red += originalColor.R * (int)((Math.Sin((0.5 - i) * Math.PI) / ((0.5 - i) * Math.PI)) * 100);
                green += originalColor.G * (int)((Math.Sin((0.5 - i) * Math.PI) / ((0.5 - i) * Math.PI)) * 100);
                blue += originalColor.B * (int)((Math.Sin((0.5 - i) * Math.PI) / ((0.5 - i) * Math.PI)) * 100);
            }
                    
            red = red / 100;
            green = green / 100;
            blue = blue / 100;

            if (red < 0)
            {
                green = green - red;
                blue = blue - red;
                red = 0;
            }
            if (green < 0)
            {
                red = red - green;
                blue = blue - green;
                green = 0;
            }
            if (blue < 0)
            {
                red = red - blue;
                green = green - blue;
                blue = 0;
            }

            Color newColor = Color.FromArgb(red, green, blue);
            return newColor;
        }
        private Color Interpolation2(Bitmap bm, int x, int y)
        {
            int red = 0;
            int green = 0;
            int blue = 0;

            for (int i = -3; i < 4; i++)
            {
                Color originalColor = bm.GetPixel(x, y + i);
                red += originalColor.R * (int)((Math.Sin((0.5 - i) * Math.PI) / ((0.5 - i) * Math.PI)) * 100);
                green += originalColor.G * (int)((Math.Sin((0.5 - i) * Math.PI) / ((0.5 - i) * Math.PI)) * 100);
                blue += originalColor.B * (int)((Math.Sin((0.5 - i) * Math.PI) / ((0.5 - i) * Math.PI)) * 100);
            }

            red = red / 100;
            green = green / 100;
            blue = blue / 100;

            if (red < 0)
            {
                green = green - red;
                blue = blue - red;
                red = 0;
            }
            if (green < 0)
            {
                red = red - green;
                blue = blue - green;
                green = 0;
            }
            if (blue < 0)
            {
                red = red - blue;
                green = green - blue;
                blue = 0;
            }

            Color newColor = Color.FromArgb(red, green, blue);
            return newColor;
        }

        private Bitmap MakeDoublescale(Bitmap orignal, Bitmap newMap)
        {  
            try
            {
                Bitmap doubleMap = new Bitmap(newMap.Width, newMap.Height);
                Bitmap padMap = Padding_Bitmap(orignal, 4);

                for(int j = 5; j < padMap.Height - 5; j++)
                {
                    for(int i = 5; i < padMap.Width - 5; i++)
                    {
                        try
                        {
                            Color originalColor = Interpolate(padMap, i, j);
                            doubleMap.SetPixel(2 * i, j, originalColor);
                            doubleMap.SetPixel(2 * i + 1, j, originalColor);
                        }
                        catch
                        {
                            doubleMap.SetPixel(i, j, Color.White);
                            doubleMap.SetPixel(2 * i + 1, j, Color.White);
                        }

                    }
                }

                return doubleMap;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        private Bitmap MakeDoubleVertical(Bitmap orignal, Bitmap newMap)
        {
            try
            {
                Bitmap doubleMap = new Bitmap(newMap.Width, newMap.Height);

                for (int i = 5; i < orignal.Width - 5; i++)
                {
                    for (int j = 5; j < orignal.Height / 2; j++)
                    {
                        try
                        {
                            Color originalColor = Interpolation2(orignal, i, j);
                            doubleMap.SetPixel(i, 2 * j, originalColor);
                            doubleMap.SetPixel(i, 2 * j + 1, originalColor);
                        }
                        catch
                        {
                            doubleMap.SetPixel(i, 2 * j, Color.White);
                            doubleMap.SetPixel(i, 2 * j + 1, Color.White);
                        }

                    }
                }

                return doubleMap;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        private void Double_Click(object sender, EventArgs e)
        {
            Form form2 = new Double_Scale();
            Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
            Bitmap imageInstance1 = new Bitmap(imageInstance.Width * 2, imageInstance.Height * 2);

            if(imageInstance != null)
            {
                if(doubling == 0)
                {
                    imageInstance1 = MakeDoublescale(imageInstance, imageInstance1);
                    doubleInstance = imageInstance1;
                    PictureBox tempPict = new PictureBox();
                    tempPict.Size = imageInstance1.Size;
                    form2.Controls.Add(tempPict);
                    tempPict.Image = imageInstance1;
                    form2.Show();
                    doubling += 1;
                }
                else if (doubling == 1)
                {
                    imageInstance1 = MakeDoubleVertical(doubleInstance, imageInstance1);
                    PictureBox tempPict = new PictureBox();
                    tempPict.Size = imageInstance1.Size;
                    form2.Controls.Add(tempPict);
                    tempPict.Image = imageInstance1;
                    form2.Show();
                    doubling += 1;
                }
                else
                {
                    Application.Exit();
                }

            }
        }

        private Bitmap Padding_Bitmap(Bitmap original, int filter)
        {
            int offset = filter - 1;
            try
            {
                Bitmap newBitMap = new Bitmap(original.Width + offset, original.Height + offset);
                for (int i = 0; i < newBitMap.Width; i++)
                {
                    for (int j = 0; j < newBitMap.Height; j++)
                    {
                        newBitMap.SetPixel(i, j, Color.White);
                    }
                }

                for (int i = 0; i < original.Width; i++)
                {
                    for (int j = 0; j < original.Height; j++)
                    {
                        Color originalColor = original.GetPixel(i, j);
                        newBitMap.SetPixel(i + 1, j + 1, originalColor);
                    }
                }

                for (int i = 1; i < original.Width; i++)
                {
                    newBitMap.SetPixel(i, 0, original.GetPixel(i, 1));
                    newBitMap.SetPixel(i, newBitMap.Height - 1, original.GetPixel(i, original.Height - 1));
                }

                for (int j = 1; j < original.Height; j++)
                {
                    newBitMap.SetPixel(0, j, original.GetPixel(1, j));
                    newBitMap.SetPixel(newBitMap.Width - 1, j, original.GetPixel(original.Width - 1, j));
                }

                newBitMap.SetPixel(0, 0, original.GetPixel(1, 1));
                newBitMap.SetPixel(newBitMap.Width - 1, 0, original.GetPixel(original.Width - offset, 1));
                newBitMap.SetPixel(0, newBitMap.Height - 1, original.GetPixel(1, original.Height - offset));
                newBitMap.SetPixel(newBitMap.Width - 1, newBitMap.Height - 1, original.GetPixel(original.Width - offset, original.Height - offset));

                return newBitMap;

            }
            catch
            {
                throw new NotImplementedException();
            }
        }

    }
}
