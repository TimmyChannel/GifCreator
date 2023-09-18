using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GifCreator.Tools;
namespace GifCreator.FrameServices
{
    //Мультизадачный контейнер для кадров, который также отрисовывает их и регулирует их обработку
    public class FramesContainer
    {
        //Имитация таблицы кадров
        #region Grid
        int rowSize;
        int columnNum;
        int rowNum;

        #endregion
        #region Header
        readonly List<PictureBox> frames = new();
        readonly List<Label> nums = new();
        readonly int defaultDelay = 50;
        Size panelSize;
        Size frameSize;
        int margin = 40;
        readonly GraphicsPath path;


        bool moving;
        bool entered;
        Point startPosOfMouse;
        Point startPosOfPB;
        int indexOfMovingPic;
        public List<PictureBox> Container { get => frames; }
        public List<Label> NumsContainer { get => nums; }

        public Size PanelSize { set => panelSize = value; }
        public Size FrameSize { get => frameSize; set => frameSize = value; }
        public int Margin { get => margin; set => margin = value; }
        #endregion
        public int ScrollValue;
        public StaticPanel Panel;

        private bool select;
        public FramesContainer(Size panelSize, Size frameSize)
        {
            this.panelSize = panelSize;
            this.frameSize = frameSize;
            path = GetPath();
        }
        //Добавление пустого кадра
        public void AddPicture()
        {
            var frame = new PictureBox();
            #region Handlers
            frame.MouseEnter += pictureBox_MouseEntered;
            frame.MouseLeave += pictureBox_MouseLeave;
            frame.MouseDown += Picture_MouseDown;
            frame.MouseUp += Picture_MouseUp;
            frame.MouseMove += Picture_MouseMove;
            #endregion
            frame.Size = FrameSize;
            frame.SizeMode = PictureBoxSizeMode.Zoom;
            frame.Name = $"Frame {frames.Count + 1}";
            frame.BackColor = Color.FromArgb(158, 158, 158);
            frame.Region = GetRegion();
            frame.Location = CalculateLocation(frames.Count);
            frame.Cursor = Cursors.Hand;
            frame.Tag = TimeSpan.FromMilliseconds(defaultDelay);
            AddText(frame);

            frames.Add(frame);
            var label = new Label
            {
                Text = $"Кадр {frames.Count}",
                ForeColor = Color.FromArgb(229, 229, 229),
                Font = new Font("Times New Roman", 14),
                TextAlign = ContentAlignment.MiddleCenter
            };
            var point = new Point
            {
                X = frame.Location.X - label.Width / 2 + frame.Width / 2,
                Y = frame.Location.Y - label.Height
            };
            label.Location = point;

            nums.Add(label);
            Panel.Controls.Add(label);
            Panel.Controls.Add(frame);
        }
        //Добавление кадра с изображением
        public void AddPicture(Image image)
        {
            var frame = new PictureBox();
            #region Handlers
            frame.MouseEnter += pictureBox_MouseEntered;
            frame.MouseLeave += pictureBox_MouseLeave;
            frame.MouseDown += Picture_MouseDown;
            frame.MouseUp += Picture_MouseUp;
            frame.MouseMove += Picture_MouseMove;
            #endregion
            frame.Size = FrameSize;
            frame.Image = image;
            frame.SizeMode = PictureBoxSizeMode.Zoom;
            frame.BackColor = Color.FromArgb(158, 158, 158);
            frame.Name = $"Frame {frames.Count + 1}";
            frame.Region = GetRegion();
            frame.Location = CalculateLocation(frames.Count);
            frame.Cursor = Cursors.Hand;
            AddText(frame);
            frame.Tag = TimeSpan.FromMilliseconds(defaultDelay);
            var label = new Label();
            frames.Add(frame);
            label.Text = $"Кадр {frames.Count}";
            label.ForeColor = Color.FromArgb(229, 229, 229);
            label.Font = new Font("Times New Roman", 14);

            var point = new Point
            {
                X = frame.Location.X - label.Width / 2 + frame.Width / 2,
                Y = frame.Location.Y - label.Height
            };
            label.Location = point;
            label.TextAlign = ContentAlignment.MiddleCenter;
            nums.Add(label);
            Panel.Controls.Add(label);
            Panel.Controls.Add(frame);
        }
        #region Location and Stacking
        //Пересчёт положения кадров (при изменении размера панели, добавления новых кадров или удаления старых)
        public void ReStackFrames()
        {
            int i = 0;
            foreach (var frame in frames)
            {
                if (moving && entered && (frames.IndexOf(frame) == indexOfMovingPic)) continue;
                frame.Location = CalculateLocation(i);
                var point = new Point
                {
                    X = frame.Location.X + frame.Width / 2 - nums[i].Width / 2,
                    Y = frame.Location.Y - nums[i].Height
                };
                nums[i].Location = point;
                i++;
            }
            Panel.HorizontalScroll.Maximum = 0;
            Panel.AutoScroll = false;
            Panel.HorizontalScroll.Visible = false;
            Panel.AutoScroll = true;
        }
        //Просчёт точки для нового кадра 
        private Point CalculateLocation(int count)
        {
            var gap = margin;
            var result = new Point();
            rowSize = (panelSize.Width - gap) / (frameSize.Width + gap);
            if (rowSize == 0)
            {
                columnNum = 0;
                rowNum = count;
            }
            else
            {
                columnNum = count % rowSize;
                rowNum = count / rowSize;
            }
            result.X = (frameSize.Width + gap) * columnNum + gap;
            result.Y = (frameSize.Height + gap) * rowNum + gap - Panel.VerticalScroll.Value;
            return result;
        }
        #endregion
        //Обработчик наведения курсора на кадр
        private void pictureBox_MouseEntered(object sender, EventArgs e)
        {
            var temp = (PictureBox)sender;
            entered = true;
            temp.BackColor = Color.FromArgb(100, 100, 100);
        }
        //Обработчик вывода курсора из кадра
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            var temp = (PictureBox)sender;
            temp.BackColor = Color.FromArgb(158, 158, 158);
            entered = false;
        }
        #region Moving
        //Обработчик события перетаскивания кадра
        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && entered)
            {
                var frame = (PictureBox)sender;
                frame.Top += e.Y - startPosOfMouse.Y;
                frame.Left += e.X - startPosOfMouse.X;
                ReStackFrames();
                Moved(frame.Location);
                frame.Invalidate();
            }
        }
        //Перемещние кадра в зависимости от положения курсора при его перетаскивании
        private void Moved(Point currentLocation)
        {
            if (currentLocation.X > (startPosOfPB.X + frameSize.Width))
            {
                if (indexOfMovingPic == frames.Count - 1)
                {
                    moving = false;
                    ReStackFrames();
                    return;
                }
                SwapFrame(indexOfMovingPic, indexOfMovingPic + 1);
                moving = false;
                ReStackFrames();
                return;
            }
            if (currentLocation.X < (startPosOfPB.X - frameSize.Width / 2 - margin))
            {
                if (indexOfMovingPic == 0)
                {
                    moving = false;
                    ReStackFrames();
                    return;
                }
                SwapFrame(indexOfMovingPic, indexOfMovingPic - 1);
                moving = false;
                ReStackFrames();
                return;
            }
            if (currentLocation.Y > (startPosOfPB.Y + frameSize.Height + margin / 2))
            {
                if (indexOfMovingPic + rowSize >= frames.Count)
                {
                    moving = false;
                    ReStackFrames();
                    return;
                }

                SwapFrame(indexOfMovingPic, indexOfMovingPic + rowSize);
                moving = false;
                ReStackFrames();
                return;
            }
            if (currentLocation.Y < (startPosOfPB.Y - frameSize.Height / 2 - margin))
            {
                if (indexOfMovingPic - rowSize < 0)
                {
                    moving = false;
                    ReStackFrames();
                    return;
                }
                SwapFrame(indexOfMovingPic, indexOfMovingPic - rowSize);
                moving = false;
                ReStackFrames();
                return;
            }

        }
        //Смена кадров местами
        private void SwapFrame(int index1, int index2)
        {
            var frame = frames[index1];
            frames.RemoveAt(index1);
            frames.Insert(index2, frame);
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            var frame = (PictureBox)sender;
            frame.Invalidate();
            if (select) return;
            moving = false;
            frame.Paint -= DrawMoved;
            ReStackFrames();
        }
        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (select) return;
            var frame = (PictureBox)sender;
            indexOfMovingPic = frames.IndexOf((PictureBox)sender);
            startPosOfMouse = e.Location;
            moving = true;
            if (entered)
            {
                frame.BringToFront();
                startPosOfPB = frame.Location;
                frame.Paint += DrawMoved;
                frame.Invalidate();
            }
            ReStackFrames();
        }
        public void Pic_KeyDown(object? sender, KeyEventArgs e) => select = e.Control | e.Shift;
        public void Pic_KeyUp(object? sender, KeyEventArgs e) => select = e.Control | e.Shift;
        #endregion
        #region Drawing
        //Отрисовка перемещаемого кадра
        private void DrawMoved(object sender, PaintEventArgs e)
        {
            var frame = (PictureBox)sender;
            var g = e.Graphics;
            if (frame.Image != null)
            {
                frame.BackColor = Color.FromArgb(158, 158, 158);
                g.DrawPath(new Pen(Color.FromArgb(94, 94, 94), 10), path);
                g.DrawImage(frame.Image, frame.Location);
            }
            else
            {
                frame.BackColor = Color.FromArgb(158, 158, 158);
                g.DrawPath(new Pen(Color.FromArgb(94, 94, 94), 10), path);
            }
        }
        private Region GetRegion() => new(GetPath());
        private GraphicsPath GetPath()
        {
            Rectangle r = new(0, 0, frameSize.Width, frameSize.Height);
            var gp = new GraphicsPath();
            int diameter = 15;
            gp.AddArc(r.X, r.Y, diameter, diameter, 180, 90);
            gp.AddArc(r.X + r.Width - diameter, r.Y, diameter, diameter, 270, 90);
            gp.AddArc(r.X + r.Width - diameter, r.Y + r.Height - diameter, diameter, diameter, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - diameter, diameter, diameter, 90, 90);
            return gp;
        }
        //Добавление текста под кадром
        private static void AddText(PictureBox frame)
        {
            frame.Paint += new PaintEventHandler((sender, e) =>
            {
                PointF locationToDraw = new();
                var text = $"\nЗадержка {((TimeSpan)frame.Tag).Milliseconds}мс";
                SizeF textSize = e.Graphics.MeasureString(text, new Font("Times New Roman", 10));
                textSize = e.Graphics.MeasureString(text, new Font("Times New Roman", 10));
                locationToDraw = new PointF
                {
                    X = (frame.Width / 2) - (textSize.Width / 2),
                    Y = (frame.Height) - (textSize.Height)
                };
                e.Graphics.DrawString(text, new Font("Times New Roman", 10), new SolidBrush(Color.FromArgb(229, 229, 229)), locationToDraw);
            });
        }
        //Перерисовка кадров
        public void ReDrawFrames()
        {
            foreach (var frame in frames)
                frame.Invalidate();
        }
        //Удаление кадра
        public void Remove(PictureBox frame)
        {
            Panel.Controls.Remove(frame);
            Panel.Controls.Remove(nums.Last());
            frames.Remove(frame);
            Console.WriteLine();
            nums.Remove(nums.Last());
            ReStackFrames();
        }
        //Перемещение кадра 
        public void MoveFromTo(int from, int to)
        {
            var frame = frames[from];
            if (to >= frames.Count) throw new Exception("Вы не можете вставить этот кадр после последнего");
            frames.RemoveAt(from);
            frames.Insert(to, frame);
        }
        //Удаление всех кадров
        public void RemoveAll()
        {
            Panel.Controls.Clear();
            frames.Clear();
            nums.Clear();
        }
        #endregion
    }
}
