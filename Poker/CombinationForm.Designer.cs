namespace Poker
{
    partial class CombinationForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombinationForm));
            imageList1 = new ImageList(components);
            pictureBox37 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox37).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // pictureBox37
            // 
            pictureBox37.BackgroundImage = (Image)resources.GetObject("pictureBox37.BackgroundImage");
            pictureBox37.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox37.Location = new Point(0, 0);
            pictureBox37.Margin = new Padding(3, 4, 3, 4);
            pictureBox37.Name = "pictureBox37";
            pictureBox37.Size = new Size(966, 763);
            pictureBox37.TabIndex = 41;
            pictureBox37.TabStop = false;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(961, 756);
            Controls.Add(pictureBox37);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form3";
            Text = "Combination";
            ((System.ComponentModel.ISupportInitialize)pictureBox37).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ImageList imageList1;
        private PictureBox pictureBox37;
    }
}