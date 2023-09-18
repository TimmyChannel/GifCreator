using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifCreator.Tools
{
    public class MultiSelectionMenu
    {
        #region Controls

        readonly Button DeleteFrames;
        readonly Button DeleteImages;
        readonly Label EditTimeDelay;
        readonly Label time;
        readonly Label PasteAfter;
        readonly Label frame;
        readonly TextBox TimeDelayBox;
        readonly TextBox PasteAfterBox;
        readonly int margin;
        readonly public GroupBox Menu;
        #endregion
        #region Fields
        private int index;
        private int timeDelays;
        private bool deleteImgs;
        private bool deleteFrms;
        private bool indexEnter;
        private bool delayEnter;
        #endregion
        #region Poperties
        public int IndexOfPasting => index;
        public bool IndexIsValid => indexEnter;
        public bool DelayIsValid => delayEnter;
        public int TimeDelays => timeDelays;
        public bool DeleteImgs => deleteImgs;
        public bool DeleteFrms => deleteFrms;
        #endregion
        public MultiSelectionMenu()
        {
            margin = 10;
            //GroupBox для всех объектов
            #region Menu
            Menu = new GroupBox
            {
                Location = new Point(5, 450),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Text = "Изменить кадры",
                ForeColor = Color.FromArgb(229, 229, 229),
                Font = new Font("Times New Roman", 14),
                Visible = false
            };
            #endregion
            //Кнопка для удаления кадров
            #region DeleteFrames
            DeleteFrames = new Button();
            Menu.Controls.Add(DeleteFrames);
            DeleteFrames.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            DeleteFrames.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteFrames.BackColor = Color.Transparent;
            DeleteFrames.Cursor = Cursors.Hand;
            DeleteFrames.FlatAppearance.BorderColor = Color.FromArgb(158, 158, 158);
            DeleteFrames.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 31, 31);
            DeleteFrames.FlatAppearance.MouseOverBackColor = Color.FromArgb(61, 61, 61);
            DeleteFrames.FlatStyle = FlatStyle.Flat;
            DeleteFrames.ForeColor = Color.FromArgb(229, 229, 229);
            DeleteFrames.Location = new Point(5, 30);
            DeleteFrames.MaximumSize = new Size(400, 50);
            DeleteFrames.MinimumSize = new Size(120, 30);
            DeleteFrames.Name = "DeleteFrames";
            DeleteFrames.Size = new Size(Menu.Size.Width - 10, 50);
            DeleteFrames.TabIndex = 0;
            DeleteFrames.Text = "Удалить кадры";
            DeleteFrames.UseVisualStyleBackColor = false;
            DeleteFrames.Click += DeleteFrame_Click;
            #endregion
            //Кнопка для удаления изображений кадров
            #region DeleteImages
            DeleteImages = new Button();
            Menu.Controls.Add(DeleteImages);
            DeleteImages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            DeleteImages.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteImages.BackColor = Color.Transparent;
            DeleteImages.Cursor = Cursors.Hand;
            DeleteImages.FlatAppearance.BorderColor = Color.FromArgb(158, 158, 158);
            DeleteImages.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 31, 31);
            DeleteImages.FlatAppearance.MouseOverBackColor = Color.FromArgb(61, 61, 61);
            DeleteImages.FlatStyle = FlatStyle.Flat;
            DeleteImages.ForeColor = Color.FromArgb(229, 229, 229);
            DeleteImages.Location = new Point(DeleteFrames.Location.X, DeleteFrames.Location.Y + margin + DeleteFrames.Size.Height);
            DeleteImages.MaximumSize = new Size(400, 50);
            DeleteImages.MinimumSize = new Size(120, 30);
            DeleteImages.Name = "DeleteImages";
            DeleteImages.Size = new Size(Menu.Size.Width - 10, 50);
            DeleteImages.TabIndex = 0;
            DeleteImages.Text = "Удалить изображения";
            DeleteImages.UseVisualStyleBackColor = false;
            DeleteImages.Click += DeleteImage_Click;
            #endregion
            //TextBox для изменения времени задержки одного кадра
            #region TimeDelayBox
            TimeDelayBox = new TextBox();
            Menu.Controls.Add(TimeDelayBox);
            TimeDelayBox.BorderStyle = BorderStyle.Fixed3D;
            TimeDelayBox.BackColor = Color.FromArgb(31, 31, 31);
            TimeDelayBox.ForeColor = Color.FromArgb(229, 229, 229);
            TimeDelayBox.Cursor = Cursors.IBeam;
            TimeDelayBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            TimeDelayBox.Name = "TimeDelayBox";
            TimeDelayBox.KeyPress += TimeDelayBox_KeyPress;
            TimeDelayBox.Size = new Size(30, 20);
            TimeDelayBox.Location = new Point(130, DeleteImages.Location.Y + margin + DeleteImages.Size.Height);
            #endregion
            //TextBox для вставки выбранных кадров после указанного
            #region PasteAfterBox
            PasteAfterBox = new TextBox();
            Menu.Controls.Add(PasteAfterBox);
            PasteAfterBox.BorderStyle = BorderStyle.Fixed3D;
            PasteAfterBox.BackColor = Color.FromArgb(31, 31, 31);
            PasteAfterBox.ForeColor = Color.FromArgb(229, 229, 229);
            PasteAfterBox.Cursor = Cursors.IBeam;
            PasteAfterBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            PasteAfterBox.Name = "PasteAfterBox";
            PasteAfterBox.KeyPress += PasteAfterBox_KeyPress;
            PasteAfterBox.Size = new Size(30, 100);
            PasteAfterBox.Location = new Point(110, TimeDelayBox.Location.Y + margin + TimeDelayBox.Size.Height);
            #endregion
            //Подписи к элементам управления
            #region frame
            frame = new Label();
            Menu.Controls.Add(frame);
            frame.Cursor = Cursors.Default;
            frame.BackColor = Color.Transparent;
            frame.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
            frame.ForeColor = Color.FromArgb(229, 229, 229);
            frame.Name = "frame";
            frame.Text = "кадра";
            frame.Font = new Font("Times New Roman", 10);
            frame.Location = new Point(PasteAfterBox.Location.X + PasteAfterBox.Size.Width, PasteAfterBox.Location.Y + 6);
            frame.Size = new Size(100, 20);
            #endregion
            #region PasteAfter
            PasteAfter = new Label();
            Menu.Controls.Add(PasteAfter);
            PasteAfter.Cursor = Cursors.IBeam;
            PasteAfter.BackColor = Color.Transparent;
            PasteAfter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            PasteAfter.ForeColor = Color.FromArgb(229, 229, 229);
            PasteAfter.Name = "PasteAfter";
            PasteAfter.Text = "Вставить после";
            PasteAfter.Font = new Font("Times New Roman", 10);
            PasteAfter.Location = new Point(DeleteImages.Location.X, PasteAfterBox.Location.Y + 6);
            PasteAfter.Size = new Size(100, 20);
            #endregion
            #region time
            time = new Label();
            Menu.Controls.Add(time);
            time.Cursor = Cursors.Default;
            time.BackColor = Color.Transparent;
            time.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
            time.ForeColor = Color.FromArgb(229, 229, 229);
            time.Name = "time";
            time.Text = "мс";
            time.Font = new Font("Times New Roman", 10);
            time.Location = new Point(TimeDelayBox.Location.X + TimeDelayBox.Size.Width, TimeDelayBox.Location.Y + 6);
            time.Size = new Size(100, 20);
            #endregion
            #region EditTimeDelay
            EditTimeDelay = new Label();
            Menu.Controls.Add(EditTimeDelay);
            EditTimeDelay.Cursor = Cursors.IBeam;
            EditTimeDelay.BackColor = Color.Transparent;
            EditTimeDelay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;
            EditTimeDelay.ForeColor = Color.FromArgb(229, 229, 229);
            EditTimeDelay.Name = "EditTimeDelay";
            EditTimeDelay.Text = "Изменить время задержки";
            EditTimeDelay.Font = new Font("Times New Roman", 10);
            EditTimeDelay.Location = new Point(DeleteImages.Location.X, TimeDelayBox.Location.Y - 1);
            EditTimeDelay.Size = new Size(120, 20);
            #endregion
            Menu.MaximumSize = new Size(400, 400);
        }
        //Обновление полей
        public void UpdateFields()
        {
            deleteFrms = false;
            deleteImgs = false;
            indexEnter = false;
            delayEnter = false;
            index = 0;
            timeDelays = 0;
        }
        public void InitializeComponent() => Menu.Size = new Size(Menu.Parent.Size.Width - 8, 300);

        private void DeleteImage_Click(object? sender, EventArgs e) => deleteImgs = true;
        private void DeleteFrame_Click(object? sender, EventArgs e) => deleteFrms = true;
        //Обработка события нажатий на клавиатуру при вводе в TextBox
        private void PasteAfterBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            try
            {
                char number = e.KeyChar;
                if (Char.IsDigit(number) || e.KeyChar == Convert.ToChar(8) || e.KeyChar == Convert.ToChar(13))
                {
                    //Если нажат enter
                    if (e.KeyChar == Convert.ToChar(13))
                    {
                        indexEnter = true;
                        index = Convert.ToInt32(PasteAfterBox.Text);
                    }
                }
                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        //Обработка события нажатий на клавиатуру при вводе в TextBox
        private void TimeDelayBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            try
            {
                char number = e.KeyChar;
                if (Char.IsDigit(number) || e.KeyChar == Convert.ToChar(8) || e.KeyChar == Convert.ToChar(13))
                {
                    //Если нажат enter
                    if (e.KeyChar == Convert.ToChar(13))
                    {
                        timeDelays = Convert.ToInt32(TimeDelayBox.Text);
                        delayEnter = true;
                    }
                }
                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
