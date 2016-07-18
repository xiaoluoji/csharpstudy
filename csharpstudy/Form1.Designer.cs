namespace csharpstudy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCollection = new System.Windows.Forms.Button();
            this.btnDelegate = new System.Windows.Forms.Button();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.btnLinq = new System.Windows.Forms.Button();
            this.btnReflection = new System.Windows.Forms.Button();
            this.btnMultiProcess = new System.Windows.Forms.Button();
            this.labTime = new System.Windows.Forms.Label();
            this.btnNewMultiprocess = new System.Windows.Forms.Button();
            this.btnFileInput = new System.Windows.Forms.Button();
            this.btnRegex = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCancelTest = new System.Windows.Forms.Button();
            this.btnSubstrcn = new System.Windows.Forms.Button();
            this.btnMakeThumb = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnXpathTest = new System.Windows.Forms.Button();
            this.btnImageMagic = new System.Windows.Forms.Button();
            this.btnAforge = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnClearHtml = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 838);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "前5章学习";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1587, 391);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 838);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "类学习";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCollection
            // 
            this.btnCollection.Location = new System.Drawing.Point(332, 838);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(140, 43);
            this.btnCollection.TabIndex = 3;
            this.btnCollection.Text = "集合于泛型";
            this.btnCollection.UseVisualStyleBackColor = true;
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnDelegate
            // 
            this.btnDelegate.Location = new System.Drawing.Point(492, 838);
            this.btnDelegate.Name = "btnDelegate";
            this.btnDelegate.Size = new System.Drawing.Size(140, 43);
            this.btnDelegate.TabIndex = 4;
            this.btnDelegate.Text = "委托与事件";
            this.btnDelegate.UseVisualStyleBackColor = true;
            this.btnDelegate.Click += new System.EventHandler(this.btnDelegate_Click);
            // 
            // btnAdvance
            // 
            this.btnAdvance.Location = new System.Drawing.Point(652, 838);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(140, 43);
            this.btnAdvance.TabIndex = 5;
            this.btnAdvance.Text = "高级语言特性";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // btnLinq
            // 
            this.btnLinq.Location = new System.Drawing.Point(819, 838);
            this.btnLinq.Name = "btnLinq";
            this.btnLinq.Size = new System.Drawing.Size(140, 43);
            this.btnLinq.TabIndex = 6;
            this.btnLinq.Text = "Linq";
            this.btnLinq.UseVisualStyleBackColor = true;
            this.btnLinq.Click += new System.EventHandler(this.btnLinq_Click);
            // 
            // btnReflection
            // 
            this.btnReflection.Location = new System.Drawing.Point(979, 838);
            this.btnReflection.Name = "btnReflection";
            this.btnReflection.Size = new System.Drawing.Size(140, 43);
            this.btnReflection.TabIndex = 7;
            this.btnReflection.Text = "反射";
            this.btnReflection.UseVisualStyleBackColor = true;
            this.btnReflection.Click += new System.EventHandler(this.btnReflection_Click);
            // 
            // btnMultiProcess
            // 
            this.btnMultiProcess.Location = new System.Drawing.Point(1139, 838);
            this.btnMultiProcess.Name = "btnMultiProcess";
            this.btnMultiProcess.Size = new System.Drawing.Size(140, 43);
            this.btnMultiProcess.TabIndex = 8;
            this.btnMultiProcess.Text = "多线程（一）";
            this.btnMultiProcess.UseVisualStyleBackColor = true;
            this.btnMultiProcess.Click += new System.EventHandler(this.btnMultiProcess_Click);
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(13, 9);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(62, 18);
            this.labTime.TabIndex = 9;
            this.labTime.Text = "[time]";
            // 
            // btnNewMultiprocess
            // 
            this.btnNewMultiprocess.Location = new System.Drawing.Point(1299, 838);
            this.btnNewMultiprocess.Name = "btnNewMultiprocess";
            this.btnNewMultiprocess.Size = new System.Drawing.Size(140, 43);
            this.btnNewMultiprocess.TabIndex = 10;
            this.btnNewMultiprocess.Text = "多线程（二）";
            this.btnNewMultiprocess.UseVisualStyleBackColor = true;
            this.btnNewMultiprocess.Click += new System.EventHandler(this.btnNewMultiprocess_Click);
            // 
            // btnFileInput
            // 
            this.btnFileInput.Location = new System.Drawing.Point(1459, 838);
            this.btnFileInput.Name = "btnFileInput";
            this.btnFileInput.Size = new System.Drawing.Size(140, 43);
            this.btnFileInput.TabIndex = 11;
            this.btnFileInput.Text = "文件输入";
            this.btnFileInput.UseVisualStyleBackColor = true;
            this.btnFileInput.Click += new System.EventHandler(this.btnFileInput_Click);
            // 
            // btnRegex
            // 
            this.btnRegex.Location = new System.Drawing.Point(12, 900);
            this.btnRegex.Name = "btnRegex";
            this.btnRegex.Size = new System.Drawing.Size(140, 42);
            this.btnRegex.TabIndex = 12;
            this.btnRegex.Text = "Regex";
            this.btnRegex.UseVisualStyleBackColor = true;
            this.btnRegex.Click += new System.EventHandler(this.btnRegex_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(172, 900);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(140, 42);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(592, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // btnCancelTest
            // 
            this.btnCancelTest.Location = new System.Drawing.Point(332, 900);
            this.btnCancelTest.Name = "btnCancelTest";
            this.btnCancelTest.Size = new System.Drawing.Size(140, 42);
            this.btnCancelTest.TabIndex = 15;
            this.btnCancelTest.Text = "Cancel test";
            this.btnCancelTest.UseVisualStyleBackColor = true;
            this.btnCancelTest.Click += new System.EventHandler(this.btnCancelTest_Click);
            // 
            // btnSubstrcn
            // 
            this.btnSubstrcn.Location = new System.Drawing.Point(492, 900);
            this.btnSubstrcn.Name = "btnSubstrcn";
            this.btnSubstrcn.Size = new System.Drawing.Size(140, 42);
            this.btnSubstrcn.TabIndex = 16;
            this.btnSubstrcn.Text = "汉字截取";
            this.btnSubstrcn.UseVisualStyleBackColor = true;
            this.btnSubstrcn.Click += new System.EventHandler(this.btnSubstrcn_Click);
            // 
            // btnMakeThumb
            // 
            this.btnMakeThumb.Location = new System.Drawing.Point(652, 900);
            this.btnMakeThumb.Name = "btnMakeThumb";
            this.btnMakeThumb.Size = new System.Drawing.Size(140, 42);
            this.btnMakeThumb.TabIndex = 17;
            this.btnMakeThumb.Text = "生成缩略图";
            this.btnMakeThumb.UseVisualStyleBackColor = true;
            this.btnMakeThumb.Click += new System.EventHandler(this.btnMakeThumb_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(819, 900);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 40);
            this.button3.TabIndex = 18;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.jpg");
            this.imageList1.Images.SetKeyName(1, "2.jpg");
            this.imageList1.Images.SetKeyName(2, "3.jpg");
            this.imageList1.Images.SetKeyName(3, "4.jpg");
            this.imageList1.Images.SetKeyName(4, "5.jpg");
            this.imageList1.Images.SetKeyName(5, "6.jpg");
            // 
            // btnXpathTest
            // 
            this.btnXpathTest.Location = new System.Drawing.Point(979, 900);
            this.btnXpathTest.Name = "btnXpathTest";
            this.btnXpathTest.Size = new System.Drawing.Size(140, 42);
            this.btnXpathTest.TabIndex = 19;
            this.btnXpathTest.Text = "XPATH测试";
            this.btnXpathTest.UseVisualStyleBackColor = true;
            this.btnXpathTest.Click += new System.EventHandler(this.btnXpathTest_Click);
            // 
            // btnImageMagic
            // 
            this.btnImageMagic.Location = new System.Drawing.Point(1139, 900);
            this.btnImageMagic.Name = "btnImageMagic";
            this.btnImageMagic.Size = new System.Drawing.Size(140, 42);
            this.btnImageMagic.TabIndex = 20;
            this.btnImageMagic.Text = "ImageMagic";
            this.btnImageMagic.UseVisualStyleBackColor = true;
            this.btnImageMagic.Click += new System.EventHandler(this.btnImageMagic_Click);
            // 
            // btnAforge
            // 
            this.btnAforge.Location = new System.Drawing.Point(1299, 900);
            this.btnAforge.Name = "btnAforge";
            this.btnAforge.Size = new System.Drawing.Size(140, 42);
            this.btnAforge.TabIndex = 21;
            this.btnAforge.Text = "Aforge";
            this.btnAforge.UseVisualStyleBackColor = true;
            this.btnAforge.Click += new System.EventHandler(this.btnAforge_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 443);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(1587, 391);
            this.textBox2.TabIndex = 22;
            // 
            // btnClearHtml
            // 
            this.btnClearHtml.Location = new System.Drawing.Point(1459, 900);
            this.btnClearHtml.Name = "btnClearHtml";
            this.btnClearHtml.Size = new System.Drawing.Size(140, 40);
            this.btnClearHtml.TabIndex = 23;
            this.btnClearHtml.Text = "清除HTML格式";
            this.btnClearHtml.UseVisualStyleBackColor = true;
            this.btnClearHtml.Click += new System.EventHandler(this.btnClearHtml_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1616, 962);
            this.Controls.Add(this.btnClearHtml);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnAforge);
            this.Controls.Add(this.btnImageMagic);
            this.Controls.Add(this.btnXpathTest);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnMakeThumb);
            this.Controls.Add(this.btnSubstrcn);
            this.Controls.Add(this.btnCancelTest);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnRegex);
            this.Controls.Add(this.btnFileInput);
            this.Controls.Add(this.btnNewMultiprocess);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.btnMultiProcess);
            this.Controls.Add(this.btnReflection);
            this.Controls.Add(this.btnLinq);
            this.Controls.Add(this.btnAdvance);
            this.Controls.Add(this.btnDelegate);
            this.Controls.Add(this.btnCollection);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCollection;
        private System.Windows.Forms.Button btnDelegate;
        private System.Windows.Forms.Button btnAdvance;
        private System.Windows.Forms.Button btnLinq;
        private System.Windows.Forms.Button btnReflection;
        private System.Windows.Forms.Button btnMultiProcess;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Button btnNewMultiprocess;
        private System.Windows.Forms.Button btnFileInput;
        private System.Windows.Forms.Button btnRegex;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCancelTest;
        private System.Windows.Forms.Button btnSubstrcn;
        private System.Windows.Forms.Button btnMakeThumb;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnXpathTest;
        private System.Windows.Forms.Button btnImageMagic;
        private System.Windows.Forms.Button btnAforge;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnClearHtml;
    }
}

