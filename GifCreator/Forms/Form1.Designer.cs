using GifCreator.Tools;
using System.Windows.Forms;

namespace GifCreator.Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.WorkSpace = new System.Windows.Forms.SplitContainer();
            this.Tools = new System.Windows.Forms.GroupBox();
            this.AddImage = new System.Windows.Forms.Button();
            this.AddEmptyFrame = new System.Windows.Forms.Button();
            this.GifButton = new System.Windows.Forms.Button();
            this.GifProperties = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RepeatSlider = new System.Windows.Forms.TrackBar();
            this.RepeatCount = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.Label();
            this.Height = new System.Windows.Forms.Label();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.GifSpace = new System.Windows.Forms.SplitContainer();
            this.imagePanel = new GifCreator.Tools.StaticPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.WorkSpace)).BeginInit();
            this.WorkSpace.Panel1.SuspendLayout();
            this.WorkSpace.Panel2.SuspendLayout();
            this.WorkSpace.SuspendLayout();
            this.Tools.SuspendLayout();
            this.GifProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GifSpace)).BeginInit();
            this.GifSpace.Panel1.SuspendLayout();
            this.GifSpace.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkSpace
            // 
            this.WorkSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.WorkSpace.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.WorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpace.Location = new System.Drawing.Point(0, 0);
            this.WorkSpace.Name = "WorkSpace";
            // 
            // WorkSpace.Panel1
            // 
            this.WorkSpace.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.WorkSpace.Panel1.Controls.Add(this.Tools);
            this.WorkSpace.Panel1.Controls.Add(this.GifProperties);
            this.WorkSpace.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.WorkSpace.Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.WorkSpace.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.WorkSpace.Panel1MinSize = 240;
            // 
            // WorkSpace.Panel2
            // 
            this.WorkSpace.Panel2.Controls.Add(this.GifSpace);
            this.WorkSpace.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.WorkSpace.Panel2MinSize = 250;
            this.WorkSpace.Size = new System.Drawing.Size(1198, 775);
            this.WorkSpace.SplitterDistance = 245;
            this.WorkSpace.SplitterWidth = 6;
            this.WorkSpace.TabIndex = 2;
            this.WorkSpace.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // Tools
            // 
            this.Tools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tools.Controls.Add(this.AddImage);
            this.Tools.Controls.Add(this.AddEmptyFrame);
            this.Tools.Controls.Add(this.GifButton);
            this.Tools.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Tools.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Tools.Location = new System.Drawing.Point(6, 12);
            this.Tools.MaximumSize = new System.Drawing.Size(400, 250);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(232, 210);
            this.Tools.TabIndex = 4;
            this.Tools.TabStop = false;
            this.Tools.Text = "Инструменты";
            // 
            // AddImage
            // 
            this.AddImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddImage.BackColor = System.Drawing.Color.Transparent;
            this.AddImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.AddImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.AddImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.AddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddImage.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.AddImage.Location = new System.Drawing.Point(6, 27);
            this.AddImage.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.AddImage.MaximumSize = new System.Drawing.Size(400, 50);
            this.AddImage.MinimumSize = new System.Drawing.Size(120, 30);
            this.AddImage.Name = "AddImage";
            this.AddImage.Size = new System.Drawing.Size(220, 50);
            this.AddImage.TabIndex = 0;
            this.AddImage.Text = "Добавить изображения";
            this.AddImage.UseVisualStyleBackColor = false;
            this.AddImage.Click += new System.EventHandler(this.AddImage_Click);
            // 
            // AddEmptyFrame
            // 
            this.AddEmptyFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEmptyFrame.BackColor = System.Drawing.Color.Transparent;
            this.AddEmptyFrame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddEmptyFrame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.AddEmptyFrame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.AddEmptyFrame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.AddEmptyFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEmptyFrame.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddEmptyFrame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.AddEmptyFrame.Location = new System.Drawing.Point(6, 87);
            this.AddEmptyFrame.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.AddEmptyFrame.MaximumSize = new System.Drawing.Size(400, 50);
            this.AddEmptyFrame.MinimumSize = new System.Drawing.Size(120, 30);
            this.AddEmptyFrame.Name = "AddEmptyFrame";
            this.AddEmptyFrame.Size = new System.Drawing.Size(220, 50);
            this.AddEmptyFrame.TabIndex = 1;
            this.AddEmptyFrame.Text = "Добавить пустой кадр";
            this.AddEmptyFrame.UseVisualStyleBackColor = false;
            this.AddEmptyFrame.Click += new System.EventHandler(this.AddEmptyFrame_Click);
            // 
            // GifButton
            // 
            this.GifButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GifButton.BackColor = System.Drawing.Color.Transparent;
            this.GifButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GifButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.GifButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.GifButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.GifButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GifButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GifButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.GifButton.Location = new System.Drawing.Point(6, 147);
            this.GifButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.GifButton.MaximumSize = new System.Drawing.Size(400, 50);
            this.GifButton.MinimumSize = new System.Drawing.Size(120, 30);
            this.GifButton.Name = "GifButton";
            this.GifButton.Size = new System.Drawing.Size(220, 50);
            this.GifButton.TabIndex = 2;
            this.GifButton.Text = "Создать GIF";
            this.GifButton.UseVisualStyleBackColor = false;
            this.GifButton.Click += new System.EventHandler(this.GifButton_Click);
            // 
            // GifProperties
            // 
            this.GifProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GifProperties.Controls.Add(this.label8);
            this.GifProperties.Controls.Add(this.label7);
            this.GifProperties.Controls.Add(this.label6);
            this.GifProperties.Controls.Add(this.label5);
            this.GifProperties.Controls.Add(this.label4);
            this.GifProperties.Controls.Add(this.label3);
            this.GifProperties.Controls.Add(this.label2);
            this.GifProperties.Controls.Add(this.label1);
            this.GifProperties.Controls.Add(this.RepeatSlider);
            this.GifProperties.Controls.Add(this.RepeatCount);
            this.GifProperties.Controls.Add(this.Width);
            this.GifProperties.Controls.Add(this.Height);
            this.GifProperties.Controls.Add(this.WidthBox);
            this.GifProperties.Controls.Add(this.HeightBox);
            this.GifProperties.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GifProperties.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.GifProperties.Location = new System.Drawing.Point(6, 228);
            this.GifProperties.MaximumSize = new System.Drawing.Size(400, 206);
            this.GifProperties.Name = "GifProperties";
            this.GifProperties.Size = new System.Drawing.Size(232, 206);
            this.GifProperties.TabIndex = 4;
            this.GifProperties.TabStop = false;
            this.GifProperties.Text = "Свойства GIF";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "∞";
            this.label8.Click += new System.EventHandler(this.label1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "25";
            this.label7.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "10";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "5";
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "4";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "3";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "2";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RepeatSlider
            // 
            this.RepeatSlider.AutoSize = false;
            this.RepeatSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RepeatSlider.Location = new System.Drawing.Point(7, 118);
            this.RepeatSlider.Maximum = 7;
            this.RepeatSlider.Name = "RepeatSlider";
            this.RepeatSlider.Size = new System.Drawing.Size(217, 45);
            this.RepeatSlider.TabIndex = 5;
            this.RepeatSlider.Value = 3;
            // 
            // RepeatCount
            // 
            this.RepeatCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RepeatCount.AutoSize = true;
            this.RepeatCount.Location = new System.Drawing.Point(12, 94);
            this.RepeatCount.Name = "RepeatCount";
            this.RepeatCount.Size = new System.Drawing.Size(205, 21);
            this.RepeatCount.TabIndex = 4;
            this.RepeatCount.Text = "Количество повторений";
            // 
            // Width
            // 
            this.Width.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Width.AutoSize = true;
            this.Width.Location = new System.Drawing.Point(151, 25);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(76, 21);
            this.Width.TabIndex = 4;
            this.Width.Text = "Ширина";
            // 
            // Height
            // 
            this.Height.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Height.AutoSize = true;
            this.Height.Location = new System.Drawing.Point(9, 25);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(70, 21);
            this.Height.TabIndex = 4;
            this.Height.Text = "Высота";
            // 
            // WidthBox
            // 
            this.WidthBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.WidthBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WidthBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WidthBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.WidthBox.Location = new System.Drawing.Point(123, 49);
            this.WidthBox.MaxLength = 1920;
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(100, 26);
            this.WidthBox.TabIndex = 3;
            this.WidthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WidthBox_KeyPress);
            // 
            // HeightBox
            // 
            this.HeightBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.HeightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeightBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.HeightBox.Location = new System.Drawing.Point(9, 49);
            this.HeightBox.MaxLength = 1080;
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(100, 26);
            this.HeightBox.TabIndex = 3;
            this.HeightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HeightBox_KeyPress);
            // 
            // GifSpace
            // 
            this.GifSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.GifSpace.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.GifSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GifSpace.Location = new System.Drawing.Point(0, 0);
            this.GifSpace.MinimumSize = new System.Drawing.Size(0, 25);
            this.GifSpace.Name = "GifSpace";
            this.GifSpace.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // GifSpace.Panel1
            // 
            this.GifSpace.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.GifSpace.Panel1.Controls.Add(this.imagePanel);
            this.GifSpace.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.GifSpace.Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.GifSpace.Size = new System.Drawing.Size(947, 775);
            this.GifSpace.SplitterDistance = 387;
            this.GifSpace.TabIndex = 0;
            // 
            // imagePanel
            // 
            this.imagePanel.AutoScroll = true;
            this.imagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel.Location = new System.Drawing.Point(0, 0);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(947, 387);
            this.imagePanel.TabIndex = 0;
            this.imagePanel.SizeChanged += new System.EventHandler(this.ImagePanel_SizeChaged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1198, 775);
            this.Controls.Add(this.WorkSpace);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "DuckGifer";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.WorkSpace.Panel1.ResumeLayout(false);
            this.WorkSpace.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkSpace)).EndInit();
            this.WorkSpace.ResumeLayout(false);
            this.Tools.ResumeLayout(false);
            this.GifProperties.ResumeLayout(false);
            this.GifProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatSlider)).EndInit();
            this.GifSpace.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GifSpace)).EndInit();
            this.GifSpace.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer WorkSpace;
        private SplitContainer GifSpace;
        private Button AddImage;
        private StaticPanel imagePanel;
        private System.Windows.Forms.Timer timer1;
        private Button AddEmptyFrame;
        private Button GifButton;
        private GroupBox GifProperties;
        private TextBox HeightBox;
        private Label Width;
        private Label Height;
        private TrackBar RepeatSlider;
        private Label RepeatCount;
        private TextBox WidthBox;
        private Label label1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox Tools;
    }
}