namespace ijw.demo.serviceInjection {
    partial class MainForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.buttonUseScopeFactory = new System.Windows.Forms.Button();
            this.buttonCleanUseScopeFactory = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonCleanOneNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCleanOneUseScopeFactory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCleanOneScope = new System.Windows.Forms.Button();
            this.buttonUseScope = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonCleanUseServiceCollection = new System.Windows.Forms.Button();
            this.buttonUseServiceCollection = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUseScopeFactory
            // 
            this.buttonUseScopeFactory.Location = new System.Drawing.Point(16, 24);
            this.buttonUseScopeFactory.Name = "buttonUseScopeFactory";
            this.buttonUseScopeFactory.Size = new System.Drawing.Size(208, 37);
            this.buttonUseScopeFactory.TabIndex = 0;
            this.buttonUseScopeFactory.Text = "创建mockForm";
            this.buttonUseScopeFactory.UseVisualStyleBackColor = true;
            this.buttonUseScopeFactory.Click += new System.EventHandler(this.buttonUseScopeFactory_Click);
            // 
            // buttonCleanUseScopeFactory
            // 
            this.buttonCleanUseScopeFactory.Location = new System.Drawing.Point(16, 76);
            this.buttonCleanUseScopeFactory.Name = "buttonCleanUseScopeFactory";
            this.buttonCleanUseScopeFactory.Size = new System.Drawing.Size(95, 37);
            this.buttonCleanUseScopeFactory.TabIndex = 1;
            this.buttonCleanUseScopeFactory.Text = "全部销毁";
            this.buttonCleanUseScopeFactory.UseVisualStyleBackColor = true;
            this.buttonCleanUseScopeFactory.Click += new System.EventHandler(this.buttonCleanUseScopeFactory_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(18, 24);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(203, 37);
            this.buttonNew.TabIndex = 2;
            this.buttonNew.Text = "创建mockForm";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonUseNew_Click);
            // 
            // buttonCleanOneNew
            // 
            this.buttonCleanOneNew.Location = new System.Drawing.Point(16, 76);
            this.buttonCleanOneNew.Name = "buttonCleanOneNew";
            this.buttonCleanOneNew.Size = new System.Drawing.Size(208, 37);
            this.buttonCleanOneNew.TabIndex = 3;
            this.buttonCleanOneNew.Text = "只销毁1个";
            this.buttonCleanOneNew.UseVisualStyleBackColor = true;
            this.buttonCleanOneNew.Click += new System.EventHandler(this.buttonCleanOneNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCleanOneUseScopeFactory);
            this.groupBox1.Controls.Add(this.buttonCleanUseScopeFactory);
            this.groupBox1.Controls.Add(this.buttonUseScopeFactory);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 129);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ScopeFactory";
            // 
            // buttonCleanOneUseScopeFactory
            // 
            this.buttonCleanOneUseScopeFactory.Location = new System.Drawing.Point(129, 76);
            this.buttonCleanOneUseScopeFactory.Name = "buttonCleanOneUseScopeFactory";
            this.buttonCleanOneUseScopeFactory.Size = new System.Drawing.Size(95, 37);
            this.buttonCleanOneUseScopeFactory.TabIndex = 1;
            this.buttonCleanOneUseScopeFactory.Text = "只销毁1个";
            this.buttonCleanOneUseScopeFactory.UseVisualStyleBackColor = true;
            this.buttonCleanOneUseScopeFactory.Click += new System.EventHandler(this.buttonCleanOneUseScopeFactory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCleanOneNew);
            this.groupBox2.Controls.Add(this.buttonNew);
            this.groupBox2.Location = new System.Drawing.Point(276, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 129);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.buttonCleanOneScope);
            this.groupBox3.Controls.Add(this.buttonUseScope);
            this.groupBox3.Location = new System.Drawing.Point(276, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 129);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scope";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 5.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(131, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "只销毁1个,同时销毁Scope";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCleanOneAndScope_Click);
            // 
            // buttonCleanOneScope
            // 
            this.buttonCleanOneScope.Location = new System.Drawing.Point(13, 76);
            this.buttonCleanOneScope.Name = "buttonCleanOneScope";
            this.buttonCleanOneScope.Size = new System.Drawing.Size(90, 37);
            this.buttonCleanOneScope.TabIndex = 1;
            this.buttonCleanOneScope.Text = "只销毁1个";
            this.buttonCleanOneScope.UseVisualStyleBackColor = true;
            this.buttonCleanOneScope.Click += new System.EventHandler(this.buttonCleanScope_Click);
            // 
            // buttonUseScope
            // 
            this.buttonUseScope.Location = new System.Drawing.Point(13, 24);
            this.buttonUseScope.Name = "buttonUseScope";
            this.buttonUseScope.Size = new System.Drawing.Size(208, 37);
            this.buttonUseScope.TabIndex = 0;
            this.buttonUseScope.Text = "创建mockForm";
            this.buttonUseScope.UseVisualStyleBackColor = true;
            this.buttonUseScope.Click += new System.EventHandler(this.buttonUseScope_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonCleanUseServiceCollection);
            this.groupBox4.Controls.Add(this.buttonUseServiceCollection);
            this.groupBox4.Location = new System.Drawing.Point(13, 156);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 129);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ServiceCollection";
            // 
            // buttonCleanUseServiceCollection
            // 
            this.buttonCleanUseServiceCollection.Location = new System.Drawing.Point(15, 76);
            this.buttonCleanUseServiceCollection.Name = "buttonCleanUseServiceCollection";
            this.buttonCleanUseServiceCollection.Size = new System.Drawing.Size(208, 37);
            this.buttonCleanUseServiceCollection.TabIndex = 0;
            this.buttonCleanUseServiceCollection.Text = "只销毁1个";
            this.buttonCleanUseServiceCollection.UseVisualStyleBackColor = true;
            this.buttonCleanUseServiceCollection.Click += new System.EventHandler(this.buttonCleanOneUseServiceCollection_Click);
            // 
            // buttonUseServiceCollection
            // 
            this.buttonUseServiceCollection.Location = new System.Drawing.Point(15, 24);
            this.buttonUseServiceCollection.Name = "buttonUseServiceCollection";
            this.buttonUseServiceCollection.Size = new System.Drawing.Size(208, 37);
            this.buttonUseServiceCollection.TabIndex = 0;
            this.buttonUseServiceCollection.Text = "创建mockForm";
            this.buttonUseServiceCollection.UseVisualStyleBackColor = true;
            this.buttonUseServiceCollection.Click += new System.EventHandler(this.buttonUseServiceCollection_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 297);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "资源创建测试";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUseScopeFactory;
        private System.Windows.Forms.Button buttonCleanUseScopeFactory;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonCleanOneNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCleanOneScope;
        private System.Windows.Forms.Button buttonUseScope;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonCleanUseServiceCollection;
        private System.Windows.Forms.Button buttonUseServiceCollection;
        private System.Windows.Forms.Button buttonCleanOneUseScopeFactory;
        private System.Windows.Forms.Button button1;
    }
}

