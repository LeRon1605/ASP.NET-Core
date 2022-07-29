
namespace Async
{
    partial class Main
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
            this.btnFetch = new System.Windows.Forms.Button();
            this.data = new System.Windows.Forms.TextBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(30, 227);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(334, 34);
            this.btnFetch.TabIndex = 0;
            this.btnFetch.Text = "Fetch Data";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(31, 40);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(333, 20);
            this.data.TabIndex = 1;
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(31, 170);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(333, 36);
            this.btnLog.TabIndex = 2;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(30, 78);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(334, 20);
            this.txtNum.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 273);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.data);
            this.Controls.Add(this.btnFetch);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.TextBox data;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TextBox txtNum;
    }
}

