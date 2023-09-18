using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifCreator.FrameServices
{
    //Класс для работы с выборкой кадров
    public class FrameSelector
    {
        List<PictureBox> frames;
        bool ctrl;
        bool shift;
        int indexOfSelectedFrame;
        readonly List<PictureBox> selection;

        public List<PictureBox> SelectedFrames { get => selection; }
        public bool Selected;
        public bool ManySelected;
        public bool Delete;
        public FrameSelector(List<PictureBox> frames)
        {
            this.frames = frames;
            selection = new List<PictureBox>();
            AddEvents();
        }
        //Добавление каждому существующему кадру обработчика событий нажатия на кнопку
        private void AddEvents()
        {
            foreach (var frame in frames)
            {
                frame.MouseClick += Frame_MouseClick;
            }
        }
        //Отрисовка базы кадра
        private void Frame_Paint(object sender, PaintEventArgs e)
        {
            var frame = (PictureBox)sender;
            var g = e.Graphics;
            var path = GetPath(frame.Size);
            g.FillPath(new SolidBrush(Color.FromArgb(130, 42, 100, 120)), path);

        }
        //Получение геометрии для отрисовки
        private static GraphicsPath GetPath(Size pictureSize)
        {
            Rectangle r = new(0, 0, pictureSize.Width, pictureSize.Height);
            var gp = new GraphicsPath();
            int diameter = 15;
            gp.AddArc(r.X, r.Y, diameter, diameter, 180, 90);
            gp.AddArc(r.X + r.Width - diameter, r.Y, diameter, diameter, 270, 90);
            gp.AddArc(r.X + r.Width - diameter, r.Y + r.Height - diameter, diameter, diameter, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - diameter, diameter, diameter, 90, 90);
            return gp;
        }
        //Обработка нажатия клавиш при выбранных кадрах
        //Здесь имитируется работа следующих сочетаний клавиш:
        //CTRL + A
        //SHIFT
        //CTRL + D
        //Delete
        public void Frame_KeyDown(object? sender, KeyEventArgs e)
        {
            shift = e.Shift;
            ctrl = e.Control;
            
            if (ctrl && e.KeyCode == Keys.A)
            {
                if (frames.Count == selection.Count)
                    DeselectAll();
                else
                    SelectAll();
            }
            if (ctrl && e.KeyCode == Keys.D)
                DeselectAll();

            if (selection.Count == 1) Selected = true;
            else Selected = false;
            if (selection.Count > 1) ManySelected = true;
            else ManySelected = false;
            if (e.KeyCode == Keys.Delete)
                Delete = true;
        }
        
        public void Frame_KeyUp(object? sender, KeyEventArgs e)
        {
            shift = e.Shift;
            ctrl = e.Control;
            if (e.KeyCode == Keys.Delete)
                Delete = false;
        }
        //Обработчик нажатия на кадры и их выделения
        private void Frame_MouseClick(object? sender, MouseEventArgs e)
        {
            int currentIndex = frames.IndexOf((PictureBox)sender);
            if (shift)
            {
                if (currentIndex < indexOfSelectedFrame)
                    SelectFrom(currentIndex, indexOfSelectedFrame);
                else SelectFrom(indexOfSelectedFrame, currentIndex);
            }
            else
            {
                if (ctrl)
                    if (selection.Contains((PictureBox)sender))
                        Remove((PictureBox)sender);
                    else
                        Add((PictureBox)sender);
                else
                if (currentIndex != indexOfSelectedFrame)
                {
                    DeselectAll();
                    Add((PictureBox)sender);
                }
            }
            if (selection.Count == 1) Selected = true;
            else Selected = false;
            if (selection.Count > 1) ManySelected = true;
            else ManySelected = false;
        }
        //Выбор кадров группы кадров по индексу
        private void SelectFrom(int index1, int index2)
        {
            DeselectAll();
            for (int i = index1; i <= index2; i++)
                Add(frames[i]);
        }
        //Выбор всех кадров
        public void SelectAll()
        {
            foreach (var frame in frames)
                Add(frame);
            Selected = true;
            ManySelected = true;
        }
        //Снятие выделения со всех кадров
        public void DeselectAll()
        {
            foreach (var frame in frames)
                Remove(frame);
            Selected = false;
            ManySelected = false;
        }
        //Добавление кадра для его обработки
        private void Add(PictureBox frame)
        {
            if (selection.Contains(frame)) return;
            selection.Add(frame);
            frame.Paint += Frame_Paint;
            frame.Invalidate();
            indexOfSelectedFrame = frames.IndexOf(frame);
        }
        //Удаление кадра из списка доступных для выделения
        private void Remove(PictureBox frame)
        {
            if (!selection.Contains(frame)) return;
            selection.Remove(frame);
            frame.Paint -= Frame_Paint;
            frame.Invalidate();
            if (selection.Count == 0)
            {
                indexOfSelectedFrame = -1;
                return;
            }
            indexOfSelectedFrame = frames.IndexOf(selection[^1]);
        }
        //Обновление всех кадров
        public void UpdateFrames(List<PictureBox> frames)
        {
            this.frames = frames;
            AddEvents();
        }
        public int GetIndexOfFirstFrame() => frames.IndexOf(selection[0]);
        public int GetIndexOfLastFrame() => frames.IndexOf(selection.Last());
        //Получения выбранных кадров
        public int[] GetIndexes()
        {
            var indexes = new int[selection.Count];
            var i = 0;
            foreach (var frm in selection)
            {
                indexes[i] = frames.IndexOf(frm);
                i++;
            }
            Array.Sort(indexes);
            return indexes;
        }
    }
}
