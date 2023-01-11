
using System.Drawing;
using System.Drawing.Imaging;

Image resourceImage = Image.FromFile("./code.jpg");
int Height = (int)(resourceImage.Height * 0.75);
int Width = (int)(resourceImage.Width * 0.75);

Bitmap bitmap = null;
try
{
    //用指定的大小和格式初始化Bitmap类的新实例 
    bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
    //从指定的Image对象创建新Graphics对象 
    Graphics graphics = Graphics.FromImage(bitmap);
    //清除整个绘图面并以透明背景色填充 
    graphics.Clear(Color.Transparent);
    //在指定位置并且按指定大小绘制原图片对象 
    graphics.DrawImage(resourceImage, new Rectangle(0, 0, Width, Height));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);

}

if (bitmap is not null) bitmap.Save("./aaaa.jpg", ImageFormat.Jpeg);