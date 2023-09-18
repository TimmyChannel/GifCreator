namespace GifCreator.Forms
{
    partial class GifPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GifBox = new System.Windows.Forms.PictureBox();
            this.AddImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GifBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GifBox
            // 
            this.GifBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GifBox.Location = new System.Drawing.Point(-2, 0);
            this.GifBox.Name = "GifBox";
            this.GifBox.Size = new System.Drawing.Size(801, 438);
            this.GifBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GifBox.TabIndex = 0;
            this.GifBox.TabStop = false;
            // 
            // AddImage
            // 
            this.AddImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddImage.BackColor = System.Drawing.Color.Transparent;
            this.AddImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.AddImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.AddImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.AddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddImage.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.AddImage.Location = new System.Drawing.Point(19, 451);
            this.AddImage.Margin = new System.Windows.Forms.Padding(10);
            this.AddImage.MaximumSize = new System.Drawing.Size(1080, 50);
            this.AddImage.MinimumSize = new System.Drawing.Size(120, 50);
            this.AddImage.Name = "AddImage";
            this.AddImage.Size = new System.Drawing.Size(762, 50);
            this.AddImage.TabIndex = 1;
            this.AddImage.Text = "Сохранить GIF";
            this.AddImage.UseVisualStyleBackColor = false;
            this.AddImage.Click += new System.EventHandler(this.AddImage_Click);
            // 
            // GifViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.AddImage);
            this.Controls.Add(this.GifBox);
            this.Name = "GifViewer";
            this.Text = "GifViewer";
            ((System.ComponentModel.ISupportInitialize)(this.GifBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox GifBox;
        private Button AddImage;
    }
}