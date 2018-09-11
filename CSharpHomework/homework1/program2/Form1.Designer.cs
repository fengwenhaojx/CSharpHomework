namespace program2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.num1_label = new System.Windows.Forms.Label();
            this.num1_textBox = new System.Windows.Forms.TextBox();
            this.num2_label = new System.Windows.Forms.Label();
            this.num2_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // num1_label
            // 
            resources.ApplyResources(this.num1_label, "num1_label");
            this.num1_label.Name = "num1_label";
            // 
            // num1_textBox
            // 
            resources.ApplyResources(this.num1_textBox, "num1_textBox");
            this.num1_textBox.Name = "num1_textBox";
            // 
            // num2_label
            // 
            resources.ApplyResources(this.num2_label, "num2_label");
            this.num2_label.Name = "num2_label";
            // 
            // num2_textBox
            // 
            resources.ApplyResources(this.num2_textBox, "num2_textBox");
            this.num2_textBox.Name = "num2_textBox";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.num2_textBox);
            this.Controls.Add(this.num2_label);
            this.Controls.Add(this.num1_textBox);
            this.Controls.Add(this.num1_label);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label num1_label;
        private System.Windows.Forms.TextBox num1_textBox;
        private System.Windows.Forms.Label num2_label;
        private System.Windows.Forms.TextBox num2_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

