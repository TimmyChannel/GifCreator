using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifCreator.Tools
{
    public class SelectionMenu
    {
        #region Controls
        readonly Button DeleteFrame;
        readonly Button ChangeImage;
        readonly Button DeleteImage;
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
        private int timeDelay;
        private bool deleteImg;
        private bool changeImg;
        private bool deleteFrm;
        private bool indexEnter;
        private bool delayEnter;
        #endregion
        #region Poperties
        public int IndexOfPasting => index;
        public bool IndexIsValid => indexEnter;
        public bool DelayIsValid => delayEnter;
        public int TimeDelay => timeDelay;
        public bool DeleteImg => deleteImg;
        public bool DeleteFrm => deleteFrm;
        public bool ChangeImg => changeImg;

        #endregion
        public SelectionMenu()
        {
            margin = 10;
            #region Menu
            Menu = new GroupBox
            {
                Location = new Point(5, 450),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Text = "Изменить кадр",
                ForeColor = Color.FromArgb(229, 229, 229),
                Font = new Font("Times New Roman", 14),
                Visible = false
            };
            #endregion
            #region DeleteFrame
            DeleteFrame = new Button();
            Menu.Controls.Add(DeleteFrame);
            DeleteFrame.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            DeleteFrame.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteFrame.BackColor = Color.Transparent;
            DeleteFrame.Cursor = Cursors.Hand;
            DeleteFrame.FlatAppearance.BorderColor = Color.FromArgb(158, 158, 158);
            DeleteFrame.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 31, 31);
            DeleteFrame.FlatAppearance.MouseOverBackColor = Color.FromArgb(61, 61, 61);
            DeleteFrame.FlatStyle = FlatStyle.Flat;
            DeleteFrame.ForeColor = Color.FromArgb(229, 229, 229);
            DeleteFrame.Location = new Point(5, 30);
            DeleteFrame.MaximumSize = new Size(400, 50);
            DeleteFrame.MinimumSize = new Size(120, 30);
            DeleteFrame.Name = "DeleteFrame";
            DeleteFrame.Size = new Size(Menu.Size.Width - 10, 50);
            DeleteFrame.TabIndex = 0;
            DeleteFrame.Text = "Удалить кадр";
            DeleteFrame.UseVisualStyleBackColor = false;
            DeleteFrame.Click += DeleteFrame_Click;
            #endregion       
            #region ChangeImage
            ChangeImage = new Button();
            Menu.Controls.Add(ChangeImage);
            ChangeImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            ChangeImage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ChangeImage.BackColor = Color.Transparent;
            ChangeImage.Cursor = Cursors.Hand;
            ChangeImage.FlatAppearance.BorderColor = Color.FromArgb(158, 158, 158);
            ChangeImage.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 31, 31);
            ChangeImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(61, 61, 61);
            ChangeImage.FlatStyle = FlatStyle.Flat;
            ChangeImage.ForeColor = Color.FromArgb(229, 229, 229);
            ChangeImage.Location = new Point(DeleteFrame.Location.X, DeleteFrame.Location.Y + margin + DeleteFrame.Size.Height);
            ChangeImage.MaximumSize = new Size(400, 50);
            ChangeImage.MinimumSize = new Size(120, 30);
            ChangeImage.Name = "ChangeImage";
            ChangeImage.Size = new Size(Menu.Size.Width - 10, 50);
            ChangeImage.TabIndex = 0;
            ChangeImage.Text = "Изменить изображение";
            ChangeImage.UseVisualStyleBackColor = false;
            ChangeImage.Click += ChangeImage_Click;
            #endregion           
            #region DeleteImage
            DeleteImage = new Button();
            Menu.Controls.Add(DeleteImage);
            DeleteImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            DeleteImage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DeleteImage.BackColor = Color.Transparent;
            DeleteImage.Cursor = Cursors.Hand;
            DeleteImage.FlatAppearance.BorderColor = Color.FromArgb(158, 158, 158);
            DeleteImage.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 31, 31);
            DeleteImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(61, 61, 61);
            DeleteImage.FlatStyle = FlatStyle.Flat;
            DeleteImage.ForeColor = Color.FromArgb(229, 229, 229);
            DeleteImage.Location = new Point(ChangeImage.Location.X, ChangeImage.Location.Y + margin + ChangeImage.Size.Height);
            DeleteImage.MaximumSize = new Size(400, 50);
            DeleteImage.MinimumSize = new Size(120, 30);
            DeleteImage.Name = "DeleteImage";
            DeleteImage.Size = new Size(Menu.Size.Width - 10, 50);
            DeleteImage.TabIndex = 0;
            DeleteImage.Text = "Удалить изображение";
            DeleteImage.UseVisualStyleBackColor = false;
            DeleteImage.Click += DeleteImage_Click;
            #endregion
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
            TimeDelayBox.Location = new Point(130, DeleteImage.Location.Y + margin + DeleteImage.Size.Height);
            #endregion
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
            PasteAfter.Location = new Point(DeleteImage.Location.X, PasteAfterBox.Location.Y + 6);
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
            EditTimeDelay.Location = new Point(DeleteImage.Location.X, TimeDelayBox.Location.Y - 1);
            EditTimeDelay.Size = new Size(120, 20);
            #endregion
            Menu.MaximumSize = new Size(400, 600);
        }
        public void UpdateFields()
        {
            deleteFrm = false;
            deleteImg = false;
            changeImg = false;
            indexEnter = false;
            delayEnter = false;
            index = 0;
            timeDelay = 0;
        }
        public void InitializeComponent() => Menu.Size = new Size(Menu.Parent.Size.Width - 8, 300);
        private void ChangeImage_Click(object? sender, EventArgs e) => changeImg = true;
       
        private void DeleteImage_Click(object? sender, EventArgs e) => deleteImg = true;
        private void DeleteFrame_Click(object? sender, EventArgs e) => deleteFrm = true;
        private void PasteAfterBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            try
            {
                char number = e.KeyChar;
                if (Char.IsDigit(number) || e.KeyChar == Convert.ToChar(8) || e.KeyChar == Convert.ToChar(13))
                {
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
        private void TimeDelayBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            try
            {
                char number = e.KeyChar;
                if (Char.IsDigit(number) || e.KeyChar == Convert.ToChar(8) || e.KeyChar == Convert.ToChar(13))
                {
                    if (e.KeyChar == Convert.ToChar(13))
                    {
                        timeDelay = Convert.ToInt32(TimeDelayBox.Text);
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
