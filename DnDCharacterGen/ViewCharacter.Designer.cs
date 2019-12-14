namespace DnDCharacterGen
{
    partial class ViewCharacter
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
            this.charDetails = new System.Windows.Forms.RichTextBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // charDetails
            // 
            this.charDetails.Location = new System.Drawing.Point(28, 75);
            this.charDetails.Name = "charDetails";
            this.charDetails.Size = new System.Drawing.Size(746, 350);
            this.charDetails.TabIndex = 0;
            this.charDetails.Text = "";
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(28, 13);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 35);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(137, 13);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 36);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // ViewCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.charDetails);
            this.Name = "ViewCharacter";
            this.Text = "ViewCharacter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox charDetails;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}