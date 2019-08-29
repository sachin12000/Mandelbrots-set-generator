using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FractalLockBits
{
    public partial class Form1 : Form
    {
        const int MAX_ITERATIONS = 100;
        bool fullscreen = false;
        ulong zoom;  //zoom history
        ulong[] zoomHistory = new ulong[100];  //zoom history for 100 steps 
        double xBound, yBound;  //xBound is the left most x value of the graph, yBound is the upper most y value of the graph
        double[] xBoundHistory = new double[100];  //History of the xBound
        double[] yBoundHistory = new double[100];  //History of the yBound
        sbyte offset = 0; //offset to the current step from the begenning (0) in history arrays 
        double realSlope, imaginarySlope;  //Slopes for linear transformation equations
        int width, height;

        int[] colorArray = new int[768];  //Array of predefined colors(gradient). [Color #, BGRA]. 1 pixel takes 4 bytes in memory

        public Form1()
        {
            InitializeComponent();
        }

        private unsafe void Form1_Load(object sender, EventArgs e)
        {
            zoom = 1;
            xBound = -2.5d;
            yBound = 1.5d;
            width = pictureBox1.Width;  //Caching
            height = pictureBox1.Height;  //Caching
            realSlope = 4.0d / zoom / width; imaginarySlope = -3.0d / zoom / height;  //Caching
            byte* colorArrayPtr;  //Pointer that will point to the first byte of coloarArray

            //Generating the gradient and storing it in colorArray
            byte colorValueR = 0;  //R
            byte colorValueG = 0;  //G
            byte colorValueB = 0;  //B

            fixed (int* colorArrayPtrInt = colorArray)  //Temperory pointer has to be used inorder to cast int pointer to byte pointer
            {
                colorArrayPtr = (byte*)colorArrayPtrInt;
            }


            for (int i = 0; i < 768; i++)
            {
                if (i >= 512)
                {
                    colorValueR = (byte)(i - 512);
                    colorValueG = (byte)(255 - colorValueR);
                }
                else if (i >= 256)
                {
                    colorValueG = (byte)(i - 256);
                    colorValueB = (byte)(255 - colorValueG);
                }
                else
                {
                    colorValueB = (byte)(i);
                }

                colorArrayPtr[i * 4 + 3] = 255;  //A
                colorArrayPtr[i * 4 + 2] = colorValueR;  //R
                colorArrayPtr[i * 4 + 1] = colorValueG;  //G
                colorArrayPtr[i * 4] = colorValueB;  //B
            }
        }

        private unsafe Bitmap drawFractal()
        {            byte coloringMethod = 1;

            if (cmbBoxColoringMethods.Text == "Red Stripes")
            {
                coloringMethod = 2;
            }

            lblZoom.Text = "Zoom = " + zoom.ToString();
            Bitmap fractalBMP = new Bitmap(width, height);
            BitmapData fractalBMPData = fractalBMP.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, fractalBMP.PixelFormat);  //Locking out the entire all the memory the Bitmap occupies inorder to direct editing
            int* pointerToFirstPixel = (int*)(void*)fractalBMPData.Scan0.ToPointer();  //Pointer that points to the first byte of the Bitmap

            double zr, zi, cr, ci, zrPrevious;  //Variales that will hold zReal, zImaginary, cReal, cImaginary, zRealPrevious
            int iterations, colorIndex;  //Variables that will hold the # of iterations and an index value that refers to a color in the colors array
            double modulus, mu;  //varialble to hold modulus of z. mu is used to decide the color

            realSlope = 4.0d / zoom / width;  //Setting the real slope
            imaginarySlope = -3.0d / zoom / height;  //Setting the imaginary slope

            zr = zi = cr = ci = 0;  //Assigning an intial values to prevent errors
            colorIndex = iterations = 0;  //Assigning ab intial values to prevent errors
            modulus = mu = 0;  //Assigning an intial values to prevent errors

            double maxR = 0, maxI = 0;

            byte[] RGBA = new byte[4];
            RGBA[0] = RGBA[1] = RGBA[2] = 0;
            RGBA[3] = 255;  //Alpha = 255
            //I tried to reduce the number of calls made to outside functions to improve efficiency. Therefore Math.Pow is not used for squaring.
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cr = realSlope * x + xBound;
                    ci = imaginarySlope * y + yBound;

                    zr = 0; zi = 0;

                    iterations = 0;
                    colorIndex = 0;

                    do
                    {
                        zrPrevious = zr; //Storing zReal in zRealPrevious
                        zr = (zr * zr) - (zi * zi) + cr;  //Caculating the real part of z
                        zi = (2 * zrPrevious * zi) + ci;  //Calculating the imaginary part of z
                        iterations++;
                    } while (Math.Sqrt((zr * zr) + (zi * zi)) < 2 && iterations < MAX_ITERATIONS);  //Checking absolute of z and iterations

                    modulus = Math.Sqrt(zr * zr + zi + Math.Pow(zi, 2));  //Calculating absolute of z

                    if (coloringMethod == 1)  //Selecting which coloring method should be used
                    {
                        if (iterations < MAX_ITERATIONS)  //Smooth coloring method
                        {
                            //Calculating z for 2 more iterations
                            zr = (zr * zr) - (zi * zi) + cr; zrPrevious = zr; zi = (2 * zrPrevious * zi) + ci;
                            zr = (zr * zr) - (zi * zi) + cr; zrPrevious = zr; zi = (2 * zrPrevious * zi) + ci;

                            iterations += 2;

                            mu = iterations - ((Math.Log(Math.Log(modulus))) / 2);
                            colorIndex = (int)(mu / MAX_ITERATIONS * 768);
                            if (colorIndex >= 768) colorIndex = 0;
                            if (colorIndex < 0) colorIndex = 0;
                        }
                        pointerToFirstPixel[y * width + x] = colorArray[colorIndex];
                    }
                    else
                    {
                        if (iterations < MAX_ITERATIONS & modulus < 2)
                        {
                            RGBA[0] = (byte)((int)(modulus * 10) ^ 3 % 255);
                            //Green is always zero
                            RGBA[2] = 255;
                        }
                        else
                        {
                            RGBA[0] = 0;
                            RGBA[2] = 0;
                        }
                        pointerToFirstPixel[y * width + x] = BitConverter.ToInt32(RGBA, 0);
                    }

                    maxR = (zr > maxR) ? zr : maxR;
                    maxI = (zi > maxI) ? zi : maxI;
                }
            }

            fractalBMP.UnlockBits(fractalBMPData);
            //MessageBox.Show(zr.ToString() + "\n" + zi.ToString());
            return fractalBMP;
        }

        private Bitmap drawColorPalatte()
        {  //Drawing the palatte
            Bitmap BMP = new Bitmap(768, height);
            Graphics g = Graphics.FromImage(BMP);

            Pen myPen;

            for (int x = 0; x < 768; x++)
            {
                myPen = new Pen(new SolidBrush(Color.FromArgb(colorArray[x])));
                g.DrawLine(myPen, x, 0, x, height);  //One vertical line for each color
            }

            return BMP;
        }

        private void btnShowPalatte_Click(object sender, EventArgs e)
        {
            //Draws the color palatte that is used by the smooth coloring method
            updateHistory();
            pictureBox1.Image = drawColorPalatte();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            lblCoordinates.Text = "Screen coordinates\n" + "X = " + e.X.ToString() + "  |  Y = " + e.Y.ToString() + "\n\nComplex plane coordinates\n" +
                          "X = " + Math.Round(realSlope * e.X + xBound, 2).ToString() + "  |  Im = " + Math.Round(imaginarySlope * e.Y + yBound, 2).ToString();
        }

        private void btnDrawOriginal_Click(object sender, EventArgs e)
        {
            //Drawing the original MadelbrotSet
            updateHistory();
            zoom = 1;
            xBound = -2.5;
            yBound = 1.5d;
            pictureBox1.Image = drawFractal();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Zooming in
            updateHistory();
            zoom *= 10;
            xBound = (realSlope * (e.X - (Width / 20)) + xBound);
            yBound = (imaginarySlope * (e.Y - (Height / 20)) + yBound);

            pictureBox1.Image = drawFractal();
        }

        private void updateHistory()
        {
            if (offset < 100)
            {
                //Saving all the variables in history variables for when needed for undoing
                xBoundHistory[offset] = xBound;
                yBoundHistory[offset] = yBound;
                zoomHistory[offset] = zoom;
                offset++;
            }


        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (offset > 0)
            {
                offset -= (sbyte)1;  //Going to the previous step

                zoom = zoomHistory[offset];
                xBound = xBoundHistory[offset];
                yBound = yBoundHistory[offset];

                pictureBox1.Image = drawFractal();

            }
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            bool visibility;

            if (fullscreen == true)  //If fullscreen is enabled, disable it
            {
                width = 800; height = 600;
                fullscreen = false;
                visibility = true;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                pictureBox1.Location = new Point(13, 13);
                this.Location = new Point(50, 50);
                pictureBox1.Size = new Size(width, height);
                this.Size = new Size(843, 747);
            }
            else  //If fullscreen is disabled, enable it
            {
                width = SystemInformation.VirtualScreen.Width; height = SystemInformation.VirtualScreen.Height;
                fullscreen = true;
                visibility = false;
                this.FormBorderStyle = FormBorderStyle.None;
                pictureBox1.Location = new Point(0, 0);
                this.Location = new Point(0, 0);
                pictureBox1.Size = new Size(width, height);
                this.Size = new Size(width, height);
            }
            btnShowPalatte.Visible = visibility;
            btnDrawOriginal.Visible = visibility;
            btnUndo.Visible = visibility;
            btnFullscreen.Visible = visibility;
            btnRefresh.Visible = visibility;

            lblCoordinates.Visible = visibility;
            lblZoom.Visible = visibility;

            label1.Visible = visibility;

            cmbBoxColoringMethods.Visible = visibility;

            //Showing complex plane coordinates does not work until real and imaginary slopes are recalclated
            realSlope = 4.0d / zoom / width;  //Recalculating real slope
            imaginarySlope = -3.0d / zoom / height;  //Recalculating imaginary slope

            pictureBox1.Image = drawFractal();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)  //Using keyboard controls when its on full screen
        {
            const int WM_KEYDOWN = 0x100;  //Code for key down event

            if (msg.Msg == WM_KEYDOWN)
            {
                switch (keyData.ToString())
                {
                    case "Left":
                        btnUndo_Click(null, null);  //Eventhandler mehtod of the Undo button
                        break;

                    case "Return":
                        btnDrawOriginal_Click(null, null);
                        break;

                    case "Escape":
                        btnFullscreen_Click(null, null);
                        break;

                    default:
                        break;
                }
            }
            return true;
            // return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)  //Purpose of the refresh button is to view the same picture with a different coloring method
        {
            pictureBox1.Image = drawFractal();
        }

        private void btnShowControls_Click(object sender, EventArgs e)  //Show keyboard controls
        {
            const string controlsMessage = "Draw original fractal = Return\nUndo = Left Arrow\nExit fullscreen = Escape\n";
            MessageBox.Show(controlsMessage, "Controls");
        }
    }
}
