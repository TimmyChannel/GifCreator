using GifCreator.Encoding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifCreator.Forms
{
    /// <summary>
    /// Форма предпросмотра GIF
    /// </summary>
    public partial class GifPreview : Form
    {
        readonly private List<PictureBox> frames;
        public bool IsOpened { get; set; }
        //Размеры GIF
        public int Height { get; set; }
        public int Width { get; set; }
        //Количество циклов
        public int RepeatCount { get; set; }
        public GifPreview(List<PictureBox> frames)
        {
            InitializeComponent();
            this.frames = frames;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Height = 128;
            Width = 128;
            RepeatCount = 0;
        }
        //Функция изменения размера изображения до нужного
        private Bitmap ResizeImage(Bitmap imgToResize, Size size)
        {
            try
            {
                Bitmap b = new Bitmap(size.Width, size.Height);
                using (Graphics g = Graphics.FromImage((Image)b))
                {
                    //Устанавливаем режим интерполяции
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    //Отрисовываем новое изображение
                    g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
                }
                return b;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return imgToResize;
            }
        }
        public void Gif()
        {
            try
            {
                if (frames.Count == 0) throw new Exception("Нет кадров");
                bool allImagesAreNullable = true;
                foreach (var frm in frames)
                {
                    if (frm.Image == null) allImagesAreNullable |= true;
                    else
                    {
                        allImagesAreNullable = false;
                        break;
                    }
                }
                if (allImagesAreNullable) throw new Exception("Нет изображений");
                var stream = new MemoryStream();
                //В цикле добавляем в кодировщик те кадры, где есть изображение
                using (var gif = new GifEncoder(stream, Width, Height, RepeatCount))
                {
                    foreach (var frm in frames)
                        if (frm.Image != null)
                        {
                            //Если размер текущего изображения совпадает с требуемым, то загружаем, иначе меняем её размер
                            if (Width == frm.Image.Width && Height == frm.Image.Height)
                            {
                                gif.AddFrame(frm.Image, 0, 0, (TimeSpan)frm.Tag);
                            }
                            else
                            {
                                var img = ResizeImage((Bitmap)frm.Image, new Size(Width, Height));
                                gif.AddFrame(img, 0, 0, (TimeSpan)frm.Tag);
                            }

                        }
                }
                stream.Position = 0;
                GifBox.Image = Image.FromStream(stream);

                ImageAnimator.Animate(GifBox.Image, OnFrameChanged);
                this.Show();
                IsOpened = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                this.Close();
                IsOpened = false;
            }
        }
        //Событие для работы предпросмотра Gif
        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }
        //Обработчик события при нажатии на кнопку сохранения
        private void AddImage_Click(object sender, EventArgs e)
        {
            //Останавливаем проигрывание анимации и освобождаем ресурсы
            ImageAnimator.StopAnimate(GifBox.Image, OnFrameChanged);
            var dlg = new SaveFileDialog
            {
                Filter = "GIF (*.gif)|*.gif"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Запускаем поток записи в файл
                var stream = new FileStream(dlg.FileName, FileMode.Create);
                //В цикле добавляем в кодировщик те кадры, где есть изображение
                using (var gif = new GifEncoder(stream, Width, Height, RepeatCount))
                {
                    foreach (var frm in frames)
                        if (frm.Image != null)
                        {                            
                            //Если размер текущего изображения совпадает с требуемым, то загружаем, иначе меняем её размер
                            if (Width == frm.Image.Width && Height == frm.Image.Height)
                            {
                                gif.AddFrame(frm.Image, 0, 0, (TimeSpan)frm.Tag);
                            }
                            else
                            {
                                var img = ResizeImage((Bitmap)frm.Image, new Size(Width, Height));
                                gif.AddFrame(img, 0, 0, (TimeSpan)frm.Tag);
                            }
                        }
                }
                this.Close();
                IsOpened = false;
            }
        }

    }
}
