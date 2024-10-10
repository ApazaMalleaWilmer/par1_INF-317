using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void deteccionBordes_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap original = (Bitmap)pictureBox1.Image;
                Bitmap bordes = DetectarBordes(original);
                pictureBox2.Image = bordes; // Muestra la imagen con bordes detectados
            }

        }
        
        private Bitmap DetectarBordes(Bitmap original)
        {
            int width = original.Width;
            int height = original.Height;
            Bitmap edgeImage = new Bitmap(width, height);

            int[,] gx = new int[3, 3]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

                    int[,] gy = new int[3, 3]
            {
                { 1, 2, 1 },
                { 0, 0, 0 },
                { -1, -2, -1 }
            };

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int pixelX = 0;
                    int pixelY = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixelColor = original.GetPixel(x + i, y + j);
                            int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3; // Convertir a escala de grises

                            pixelX += gx[i + 1, j + 1] * grayValue;
                            pixelY += gy[i + 1, j + 1] * grayValue;
                        }
                    }

                    int magnitud = (int)Math.Sqrt(pixelX * pixelX + pixelY * pixelY);
                    magnitud = Clamp(magnitud, 0, 255);

                    edgeImage.SetPixel(x, y, Color.FromArgb(magnitud, magnitud, magnitud));
                }
            }

            return edgeImage;
        }
        private int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
