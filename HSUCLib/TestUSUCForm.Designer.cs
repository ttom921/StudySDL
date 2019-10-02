namespace HSUCLib
{
    partial class TestUSUCForm
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
            this.hsucax1 = new HSUCLib.HSUCAX();
            this.SuspendLayout();
            // 
            // hsucax1
            // 
            this.hsucax1.Location = new System.Drawing.Point(22, 12);
            this.hsucax1.Name = "hsucax1";
            this.hsucax1.Size = new System.Drawing.Size(766, 450);
            this.hsucax1.TabIndex = 0;
            // 
            // TestUSUCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 496);
            this.Controls.Add(this.hsucax1);
            this.Name = "TestUSUCForm";
            this.Text = "TestUSUCForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestUSUCForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private HSUCAX hsucax1;
    }
}