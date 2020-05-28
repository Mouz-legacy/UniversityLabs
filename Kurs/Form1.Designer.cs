namespace Kursach
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.myButton1 = new Kursach.MyButton();
            this.egoldsEnterMenu2 = new Kursach.EgoldsEnterMenu();
            this.egoldsEnterMenu1 = new Kursach.EgoldsEnterMenu();
            this.egoldsFromStyle1 = new Kursach.egoldsFromStyle1(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(102, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Do you want to create a new account?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(158, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(140, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sign in";
            // 
            // myButton1
            // 
            this.myButton1.BackColor = System.Drawing.Color.Tomato;
            this.myButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButton1.ForeColor = System.Drawing.Color.White;
            this.myButton1.Location = new System.Drawing.Point(146, 301);
            this.myButton1.Name = "myButton1";
            this.myButton1.RoundingEnable = false;
            this.myButton1.Size = new System.Drawing.Size(100, 30);
            this.myButton1.TabIndex = 2;
            this.myButton1.Text = "Sign in";
            // 
            // egoldsEnterMenu2
            // 
            this.egoldsEnterMenu2.BackColor = System.Drawing.Color.White;
            this.egoldsEnterMenu2.BorderColor = System.Drawing.Color.Blue;
            this.egoldsEnterMenu2.BorderColorNotActive = System.Drawing.Color.DarkGray;
            this.egoldsEnterMenu2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.egoldsEnterMenu2.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.egoldsEnterMenu2.FontTextPreview = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.egoldsEnterMenu2.ForeColor = System.Drawing.Color.Black;
            this.egoldsEnterMenu2.Location = new System.Drawing.Point(67, 219);
            this.egoldsEnterMenu2.Name = "egoldsEnterMenu2";
            this.egoldsEnterMenu2.Size = new System.Drawing.Size(271, 43);
            this.egoldsEnterMenu2.TabIndex = 1;
            this.egoldsEnterMenu2.TextInput = "";
            this.egoldsEnterMenu2.TextPreview = "Enter password";
            // 
            // egoldsEnterMenu1
            // 
            this.egoldsEnterMenu1.BackColor = System.Drawing.Color.White;
            this.egoldsEnterMenu1.BorderColor = System.Drawing.Color.Blue;
            this.egoldsEnterMenu1.BorderColorNotActive = System.Drawing.Color.DarkGray;
            this.egoldsEnterMenu1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.egoldsEnterMenu1.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.egoldsEnterMenu1.FontTextPreview = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.egoldsEnterMenu1.ForeColor = System.Drawing.Color.Black;
            this.egoldsEnterMenu1.Location = new System.Drawing.Point(67, 157);
            this.egoldsEnterMenu1.Name = "egoldsEnterMenu1";
            this.egoldsEnterMenu1.Size = new System.Drawing.Size(271, 43);
            this.egoldsEnterMenu1.TabIndex = 0;
            this.egoldsEnterMenu1.TextInput = "";
            this.egoldsEnterMenu1.TextPreview = "Enter login";
            // 
            // egoldsFromStyle1
            // 
            this.egoldsFromStyle1.Form = this;
            this.egoldsFromStyle1.FormStyle = Kursach.egoldsFromStyle1.FStyle.SimpleDark;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 425);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 422);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.egoldsEnterMenu2);
            this.Controls.Add(this.egoldsEnterMenu1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private egoldsFromStyle1 egoldsFromStyle1;
        private MyButton myButton1;
        private EgoldsEnterMenu egoldsEnterMenu2;
        private EgoldsEnterMenu egoldsEnterMenu1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

