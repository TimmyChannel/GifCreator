using GifCreator.FrameServices;
using GifCreator.Tools;
using System.Diagnostics;

namespace GifCreator.Forms
{
    public partial class Form1 : Form
    {
        readonly FramesContainer boxes;
        readonly FrameSelector selector;
        readonly SelectionMenu SelectionMenu;
        readonly MultiSelectionMenu MultiSelectionMenu;
        bool ChangeDialogIsOpen;
        OpenFileDialog ChangeImg;
        DialogResult result;

        int GifHeight;
        int GifWidth;
        public Form1()
        {
            InitializeComponent();

            imagePanel.HorizontalScroll.Maximum = 0;
            imagePanel.AutoScroll = false;
            imagePanel.VerticalScroll.Visible = false;
            imagePanel.AutoScroll = true;

            timer1.Tick += Checker;
            timer1.Interval = 100;
            timer1.Start();
            boxes = new FramesContainer(imagePanel.ClientSize, new Size(120, 120))
            {
                Panel = imagePanel
            };
            selector = new FrameSelector(boxes.Container);
            SelectionMenu = new SelectionMenu();
            MultiSelectionMenu = new MultiSelectionMenu();
            this.KeyDown += selector.Frame_KeyDown;
            this.KeyUp += selector.Frame_KeyUp;
            this.KeyDown += boxes.Pic_KeyDown;
            this.KeyUp += boxes.Pic_KeyUp;
            WorkSpace.Panel1.Controls.Add(SelectionMenu.Menu);
            SelectionMenu.Menu.Parent = WorkSpace.Panel1;
            SelectionMenu.InitializeComponent();
            WorkSpace.Panel1.Controls.Add(MultiSelectionMenu.Menu);
            MultiSelectionMenu.Menu.Parent = WorkSpace.Panel1;
            MultiSelectionMenu.InitializeComponent();
            HeightBox.Text = "128";
            WidthBox.Text = "128";
        }

        private void GifButton_Click(object sender, EventArgs e)
        {
            try
            {
                GifHeight = Convert.ToInt32(HeightBox.Text);
                GifWidth = Convert.ToInt32(WidthBox.Text);

                int repeats = 0;
                switch (RepeatSlider.Value)
                {
                    case 5: repeats = 10; break;
                    case 6: repeats = 25; break;
                    case 7: repeats = 0; break;
                    default:
                        repeats = RepeatSlider.Value + 1;
                        break;
                }
                if (GifHeight == 0) throw new Exception("Высота !=0");
                if (GifWidth == 0) throw new Exception("Ширина !=0");
                var f = new GifPreview(boxes.Container);
                f.Width = GifWidth;
                f.Height = GifHeight;
                f.RepeatCount = repeats;
                f.Gif();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void Checker(object? sender, EventArgs e)
        {
            try
            {
                if (selector.Selected)
                {
                    timer1.Interval = 20;
                    SelectionMenu.Menu.Visible = true;
                    if (SelectionMenu.IndexIsValid && SelectionMenu.IndexOfPasting != 0)
                    {
                        if (SelectionMenu.IndexOfPasting >= boxes.Container.Count + 1)
                            throw new Exception("Номер кадра для вставки выходит за границы");

                        var index = selector.GetIndexOfFirstFrame();
                        boxes.MoveFromTo(index, SelectionMenu.IndexOfPasting);
                        boxes.ReStackFrames();
                    }
                    if (SelectionMenu.DelayIsValid)
                    {
                        selector.SelectedFrames[0].Tag = TimeSpan.FromMilliseconds(SelectionMenu.TimeDelay);
                        boxes.ReDrawFrames();
                    }
                    if (SelectionMenu.DeleteFrm || (selector.Delete && SelectionMenu.Menu.Visible))
                    {
                        selector.Delete = false;
                        var frm = selector.SelectedFrames[0];
                        selector.DeselectAll();
                        boxes.Remove(frm);
                        boxes.ReStackFrames();
                    }
                    if (SelectionMenu.ChangeImg)
                    {
                        if (!ChangeDialogIsOpen)
                        {
                            ChangeImg = new OpenFileDialog { Title = "Пожалуйста, выберите изображение для изменения:", Filter = "Jpeg|*.jpg|Jpeg|*.jpeg|Png|*.png|Bitmap|*.bmp" };
                            ChangeDialogIsOpen = true;
                            result = ChangeImg.ShowDialog();
                        }
                        if (result != DialogResult.OK)
                            return;
                        var index = boxes.Container.IndexOf(selector.SelectedFrames[0]);
                        boxes.Container[index].Image = Image.FromFile(ChangeImg.FileName);
                        result = DialogResult.No;
                        ChangeDialogIsOpen = false;
                        boxes.ReDrawFrames();
                    }
                    if (SelectionMenu.DeleteImg)
                    {
                        var index = boxes.Container.IndexOf(selector.SelectedFrames[0]);
                        boxes.Container[index].Image = null;
                        boxes.ReDrawFrames();
                    }
                    SelectionMenu.UpdateFields();
                }
                else
                {
                    timer1.Interval = 100;
                    SelectionMenu.Menu.Visible = false;
                }
                if (selector.ManySelected)
                {
                    timer1.Interval = 20;
                    MultiSelectionMenu.Menu.Visible = true;
                    if (MultiSelectionMenu.IndexIsValid && MultiSelectionMenu.IndexOfPasting != 0)
                    {
                        if (MultiSelectionMenu.IndexOfPasting >= boxes.Container.Count + 1)
                            throw new Exception("Номер кадра для вставки выходит за границы");
                        var selection = new PictureBox[selector.SelectedFrames.Count];
                        selector.SelectedFrames.CopyTo(selection);
                        var count = selector.SelectedFrames.Count;
                        if (boxes.Container.Count - MultiSelectionMenu.IndexOfPasting < count)
                            throw new Exception("Вы не можете вставить такое количество кадров после введённого индекса");
                        for (int j = count - 1; j >= 0; j--)
                        {
                            var index = selector.GetIndexOfLastFrame();
                            if (index < MultiSelectionMenu.IndexOfPasting)
                                boxes.MoveFromTo(index, MultiSelectionMenu.IndexOfPasting + j);
                            else
                                boxes.MoveFromTo(index, MultiSelectionMenu.IndexOfPasting);
                            selector.SelectedFrames.RemoveAt(j);
                        }
                        selector.SelectedFrames.AddRange(selection);
                        boxes.ReStackFrames();
                    }
                    if (MultiSelectionMenu.DelayIsValid)
                    {
                        foreach (var frm in selector.SelectedFrames)
                            frm.Tag = TimeSpan.FromMilliseconds(MultiSelectionMenu.TimeDelays);
                        boxes.ReDrawFrames();
                    }
                    if (MultiSelectionMenu.DeleteImgs)
                    {
                        var indexes = selector.GetIndexes();
                        foreach (var index in indexes)
                            boxes.Container[index].Image = null;
                        boxes.ReDrawFrames();
                    }
                    if (MultiSelectionMenu.DeleteFrms || (selector.Delete && MultiSelectionMenu.Menu.Visible))
                    {
                        var indexes = selector.GetIndexes();
                        var i = 0;
                        selector.DeselectAll();
                        if (indexes.Length == boxes.Container.Count)
                        {
                            boxes.RemoveAll();
                            MultiSelectionMenu.UpdateFields();
                            selector.Delete = false;
                            return;
                        }
                        foreach (var index in indexes)
                        {
                            boxes.Remove(boxes.Container[index - i]);
                            i++;
                        }
                        selector.Delete = false;
                    }
                    MultiSelectionMenu.UpdateFields();
                }
                else
                {
                    timer1.Interval = 100;
                    MultiSelectionMenu.Menu.Visible = false;
                }
                selector.UpdateFrames(boxes.Container);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                SelectionMenu.UpdateFields();
                MultiSelectionMenu.UpdateFields();
            }
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        private void ImagePanel_SizeChaged(object sender, EventArgs e)
        {
            if (boxes == null)
                return;
            boxes.PanelSize = imagePanel.DisplayRectangle.Size;
            boxes.ReStackFrames();
        }
        private void AddImage_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog { Title = "Пожалуйста, выберите изображения:", Filter = "Png|*.png|Jpg|*.jpg|Jpeg|*.jpeg|Bitmap|*.bmp" };
                dlg.Multiselect = true;
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                var count = 0;
                foreach (var file in dlg.FileNames)
                {
                    boxes.AddPicture(Image.FromFile(file));
                    count++;
                }
                selector.UpdateFrames(boxes.Container);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void AddEmptyFrame_Click(object sender, EventArgs e)
        {
            try
            {
                boxes.AddPicture();
                selector.UpdateFrames(boxes.Container);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void InfoBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HeightBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char number = e.KeyChar;
                if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void WidthBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char number = e.KeyChar;
                if (!Char.IsDigit(number) && e.KeyChar != Convert.ToChar(8))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void GifSpace_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}