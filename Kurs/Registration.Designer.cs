namespace Kursach
{
    partial class Registration
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
            this.components = new System.ComponentModel.Container();
            this.egoldsFromStyle11 = new Kursach.egoldsFromStyle1(this.components);
            this.SuspendLayout();
            // 
            // egoldsFromStyle11
            // 
            this.egoldsFromStyle11.Form = this;
            this.egoldsFromStyle11.FormStyle = Kursach.egoldsFromStyle1.FStyle.SimpleDark;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 399);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);

        }

        #endregion

        private egoldsFromStyle1 egoldsFromStyle11;
    }
}