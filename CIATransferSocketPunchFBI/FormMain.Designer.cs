namespace CIATransferSocketPunchFBI
{
	partial class FormMain
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
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.btnStartTransfer = new System.Windows.Forms.Button();
			this.listAllCIAs = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listCIAsToTransfer = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtIpAddress = new System.Windows.Forms.TextBox();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.lbState = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnStartTransfer
			// 
			this.btnStartTransfer.Location = new System.Drawing.Point(150, 328);
			this.btnStartTransfer.Name = "btnStartTransfer";
			this.btnStartTransfer.Size = new System.Drawing.Size(75, 23);
			this.btnStartTransfer.TabIndex = 0;
			this.btnStartTransfer.Text = "开始传输";
			this.btnStartTransfer.UseVisualStyleBackColor = true;
			this.btnStartTransfer.Click += new System.EventHandler(this.btnStartTransfer_Click);
			// 
			// listAllCIAs
			// 
			this.listAllCIAs.FormattingEnabled = true;
			this.listAllCIAs.ItemHeight = 12;
			this.listAllCIAs.Location = new System.Drawing.Point(14, 24);
			this.listAllCIAs.Name = "listAllCIAs";
			this.listAllCIAs.Size = new System.Drawing.Size(519, 112);
			this.listAllCIAs.TabIndex = 1;
			this.listAllCIAs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listAllCIAs_MouseDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "CIA文件（双击加入传输队列）";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 161);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(191, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "CIA传输队列（双击移除传输队列）";
			// 
			// listCIAsToTransfer
			// 
			this.listCIAsToTransfer.FormattingEnabled = true;
			this.listCIAsToTransfer.ItemHeight = 12;
			this.listCIAsToTransfer.Location = new System.Drawing.Point(14, 176);
			this.listCIAsToTransfer.Name = "listCIAsToTransfer";
			this.listCIAsToTransfer.Size = new System.Drawing.Size(519, 112);
			this.listCIAsToTransfer.TabIndex = 4;
			this.listCIAsToTransfer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listCIAsToTransfer_MouseDoubleClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 306);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(125, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "Ip地址（设备上显示）";
			// 
			// txtIpAddress
			// 
			this.txtIpAddress.Location = new System.Drawing.Point(14, 330);
			this.txtIpAddress.Name = "txtIpAddress";
			this.txtIpAddress.Size = new System.Drawing.Size(130, 21);
			this.txtIpAddress.TabIndex = 6;
			this.txtIpAddress.Text = "192.168.55.35";
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(14, 357);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(521, 23);
			this.progress.TabIndex = 7;
			// 
			// lbState
			// 
			this.lbState.Location = new System.Drawing.Point(289, 333);
			this.lbState.Name = "lbState";
			this.lbState.Size = new System.Drawing.Size(244, 12);
			this.lbState.TabIndex = 8;
			this.lbState.Text = "0.0Mb of 0.0Mb @ 0.0%";
			this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(545, 523);
			this.Controls.Add(this.lbState);
			this.Controls.Add(this.progress);
			this.Controls.Add(this.txtIpAddress);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listCIAsToTransfer);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listAllCIAs);
			this.Controls.Add(this.btnStartTransfer);
			this.Name = "FormMain";
			this.Text = "SocketPunch-Just.Qin";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnStartTransfer;
		private System.Windows.Forms.ListBox listAllCIAs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listCIAsToTransfer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtIpAddress;
		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Label lbState;
	}
}

