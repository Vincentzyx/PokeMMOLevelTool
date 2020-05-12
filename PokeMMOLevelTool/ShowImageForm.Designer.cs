namespace PokeMMOLevelTool
{
    partial class ShowImageForm
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
            this.pictureBox_showPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_showPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_showPic
            // 
            this.pictureBox_showPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_showPic.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_showPic.Name = "pictureBox_showPic";
            this.pictureBox_showPic.Size = new System.Drawing.Size(382, 360);
            this.pictureBox_showPic.TabIndex = 0;
            this.pictureBox_showPic.TabStop = false;
            // 
            // ShowImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 360);
            this.Controls.Add(this.pictureBox_showPic);
            this.Name = "ShowImageForm";
            this.Text = "ShowImageForm";
            this.Load += new System.EventHandler(this.ShowImageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_showPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_showPic;
    }
}