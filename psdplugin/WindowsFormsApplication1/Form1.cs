using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PhotoshopFile.PsdFile pfile = new PhotoshopFile.PsdFile();
            pfile.Load("D:/11.psd");
            //Rectangle rect = new Rectangle(0,0,300,300);
            //pfile.Layers[0].Channels[0].DecompressImageData(pfile.Layers[0].Rect);
           

            for (int i = 0; i < pfile.Layers.Count; i++)
            {
                int width0 = pfile.Layers[i].Rect.Width;
                int height0 = pfile.Layers[i].Rect.Height;
                if (i == 2)
                {
                    int a = 3;
                }
                    test2(pfile.Layers[i], "D://ps//conkhi" + i.ToString() + ".", pfile.ColorMode);
               

            }


        }
        public void test(int width, int height, byte[] imgDataArray1, byte[] imgDataArray2, byte[] imgDataArray3, string path)
        {
            //Here create the Bitmap to the know height, width and format
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            //Bitmap bmp = new Bitmap(width, height);

            //Create a BitmapData and Lock all pixels to be written 
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(
                                 new Rectangle(0, 0, bmp.Width, bmp.Height),
                                 ImageLockMode.WriteOnly, bmp.PixelFormat);

            //Copy the data from the byte array into BitmapData.Scan0
            System.Runtime.InteropServices.Marshal.Copy(imgDataArray1, 0, bmpData.Scan0, imgDataArray1.Length);
            System.Runtime.InteropServices.Marshal.Copy(imgDataArray2, 0, bmpData.Scan0, imgDataArray2.Length);
            System.Runtime.InteropServices.Marshal.Copy(imgDataArray3, 0, bmpData.Scan0, imgDataArray3.Length);
            //Unlock the pixels
            bmp.UnlockBits(bmpData);
            bmp.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);

        }
        public void test2(PhotoshopFile.Layer layer, string path,PhotoshopFile.PsdColorMode ColorMode)
        {
            int width = layer.Rect.Width;
            string ImageMode = layer.BlendModeKey;
            int height = layer.Rect.Height;
            bool isAlpha = false;
            if (layer.Channels.Count == 4)
                isAlpha = true;
            if (width > 0 && height > 0)
            {
                var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

                for (int y = 0; y < height; y++)
                    for (int x = 0; x < width; x++)
                    {
                        int red=0, green=0, blue=0, alpha=0,mask=0;
                        switch (ColorMode)
                        { 
                            case PhotoshopFile.PsdColorMode.RGB:
                                for (int i = 0; i < layer.Channels.Count; i++)
                                {
                                    int position = (width * y) + x;
                                    if (layer.Channels[i].ID == -2)
                                    {
                                        
                                        int widthMask = layer.MaskData.Rect.Width;
                                        int heightMask = layer.MaskData.Rect.Height;
                                        int XMask = layer.MaskData.Rect.X;
                                        int YMask = layer.MaskData.Rect.Y;
                                        if(position>((YMask*width)+ XMask) && position<(YMask*width)+XMask+ widthMask)
                                        {
                                            //get mask data
                                        }
                                        mask = layer.Channels[i].ImageData[position];
                                    }
                                    if (layer.Channels[i].ID == -1)
                                    {
                                        alpha = layer.Channels[i].ImageData[position];
                                    }
                                    if (layer.Channels[i].ID == 0)
                                    {
                                        red = layer.Channels[i].ImageData[position];
                                    }
                                    if (layer.Channels[i].ID == 1)
                                    {
                                        green = layer.Channels[i].ImageData[position];
                                    }
                                    if (layer.Channels[i].ID == 2)
                                    {
                                        blue = layer.Channels[i].ImageData[position];
                                    }
                                }
                                bitmap.SetPixel(x, y, Color.FromArgb(1, red, green, blue));
                                //if (layer.Channels.Count == 3)
                                //{
                                //    red = layer.Channels[0].ImageData[(width * y) + x]; // read from array
                                //    green = layer.Channels[1].ImageData[(width * y) + x]; // read from array
                                //    blue = layer.Channels[2].ImageData[(width * y) + x]; // read from array
                                //    alpha = 0;
                                //    bitmap.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                                //}
                                //else if (layer.Channels.Count == 4)
                                //{
                                //    alpha = layer.Channels[0].ImageData[(width * y) + x]; // read from array
                                //    red = layer.Channels[1].ImageData[(width * y) + x]; // read from array
                                //    green = layer.Channels[2].ImageData[(width * y) + x]; // read from array
                                //    blue = layer.Channels[3].ImageData[(width * y) + x]; // read from array
                                //    bitmap.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                                //}
                                break;
                            case PhotoshopFile.PsdColorMode.CMYK:
                                if (layer.Channels.Count == 4)
                                {
                                    int c,m,yellow,k;
                                    c= layer.Channels[0].ImageData[(width * y) + x];
                                    m= layer.Channels[1].ImageData[(width * y) + x];
                                    yellow= layer.Channels[2].ImageData[(width * y) + x];
                                    k= layer.Channels[3].ImageData[(width * y) + x];
                                    int[] RGB = cmykToRgb(c, m, yellow, k);
                                    red = RGB[0];
                                    green = RGB[1];
                                    blue = RGB[2];
                                    alpha = 0;
                                    bitmap.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                                }
                                else if (layer.Channels.Count ==5)
                                {
                                    int c, m, yellow, k;
                                    alpha = layer.Channels[0].ImageData[(width * y) + x];
                                    c = layer.Channels[1].ImageData[(width * y) + x];
                                    m= layer.Channels[2].ImageData[(width * y) + x];
                                    yellow = layer.Channels[3].ImageData[(width * y) + x];
                                    k = layer.Channels[4].ImageData[(width * y) + x];
                                    int[] RGB = cmykToRgb(c, m, yellow, k);
                                    red = RGB[0];
                                    green = RGB[1];
                                    blue = RGB[2];
                                    
                                    bitmap.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                                }
                                break;
                        }
                       

                        //if (layer.AlphaChannel != null)
                        //{
                        //    alpha = layer.AlphaChannel.ImageData[(width * y) + x];
                        //}

                    }
                if (isAlpha)
                    bitmap.Save(path + "png", System.Drawing.Imaging.ImageFormat.Png);
                else
                    bitmap.Save(path+ "jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    
            }
        }
        public static int[] cmykToRgb(int cyan, int magenta, int yellow, int black)
        {
            //if (black != 255)
            //{
            //    int R = ((255 - cyan) * (255 - black)) / 255;
            //    int G = ((255 - magenta) * (255 - black)) / 255;
            //    int B = ((255 - yellow) * (255 - black)) / 255;
            //    return new int[] { R, G, B };
            //}
            //else
            //{
            //    int R = 255 - cyan;
            //    int G = 255 - magenta;
            //    int B = 255 - yellow;
            //    return new int[] { R, G, B };
            //}
            int[] rgb=new int[3];
            int colors = 255 - black;
            rgb[0] = colors * (255 - cyan) / 255;
            rgb[1] = colors * (255 - magenta) / 255;
            rgb[2] = colors * (255 - yellow) / 255;
            return rgb;
        }
        private void byteArrayToImage(byte[] byteArrayIn)
        {
            System.Drawing.Image newImage;

            string strFileName = "D://2.jpg";
            if (byteArrayIn != null)
            {

                using (MemoryStream stream = new MemoryStream(byteArrayIn))
                {
                    newImage = System.Drawing.Image.FromStream(stream);

                    newImage.Save(strFileName);

                    //img.Attributes.Add("src", strFileName);
                }

                // lblMessage.Text = "The image conversion was successful.";
            }
            else
            {
                //Response.Write("No image data found!");
            }
        }
    }
}
