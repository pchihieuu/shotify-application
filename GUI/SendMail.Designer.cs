namespace GUI
{
    partial class SendMail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pcbLoader = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbLoader
            // 
            this.pcbLoader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcbLoader.Image = global::GUI.Properties.Resources.Pulse_1s_200px;
            this.pcbLoader.ImageRotate = 0F;
            this.pcbLoader.Location = new System.Drawing.Point(0, 0);
            this.pcbLoader.Name = "pcbLoader";
            this.pcbLoader.Size = new System.Drawing.Size(199, 200);
            this.pcbLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLoader.TabIndex = 0;
            this.pcbLoader.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vui  lòng đợi!";
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 240);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcbLoader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SendMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SendMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pcbLoader;
        private System.Windows.Forms.Label label1;
    }
}
