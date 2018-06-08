using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CIATransferSocketPunchFBI
{
	public partial class FormMain : Form
	{
		private Socket socket;
		List<string> ciaFiles;
		private List<string> ciaToTransfers = new List<string>();
		private void ListAllCIAs()
		{
			ciaFiles = Directory.EnumerateFiles(Environment.CurrentDirectory, "*.cia", SearchOption.AllDirectories).ToList();
			if (ciaFiles == null || ciaFiles.Count == 0)
			{
				listAllCIAs.Items.Add("没有找到CIA文件");
			}
			for (int i = 0; i < ciaFiles.Count; i++)
			{
				listAllCIAs.Items.Add(Path.GetFileName(ciaFiles[i]));
			}
		}

		public FormMain()
		{
			InitializeComponent();
			ListAllCIAs();
		}

		void ThreadTransfer(object ip)
		{
			try
			{
				byte[] buffer = new byte[256 * 1024];
				for (int i = 0; i < ciaToTransfers.Count; i++)
				{
					if (!socket.Connected)
					{
						socket.Connect(ip.ToString(), 5000);
					}
					FileStream stream = new FileStream(ciaToTransfers[i], FileMode.Open);

					BinaryReader fileReader = new BinaryReader(stream);
					long fileTotalLength = stream.Length;
					buffer[0] = (byte) (fileTotalLength >> 56);
					buffer[1] = (byte) (fileTotalLength >> 48);
					buffer[2] = (byte) (fileTotalLength >> 40);
					buffer[3] = (byte) (fileTotalLength >> 32);
					buffer[4] = (byte) (fileTotalLength >> 24);
					buffer[5] = (byte) (fileTotalLength >> 16);
					buffer[6] = (byte) (fileTotalLength >> 8);
					buffer[7] = (byte) (fileTotalLength >> 0);
					socket.Send(buffer, 0, 8, SocketFlags.DontRoute);
					this.Invoke(new MethodInvoker(delegate
					{
						listCIAsToTransfer.SelectedIndex = i;
						progress.Value = 0;
						progress.Maximum = (int) fileTotalLength;
						lbState.Text = string.Format("{0:F2}Mb of {1:F2}Mb @ {2:F2}%", 0, 0, 0);
					}));
					//Thread.Sleep(5000);
					int readLength;
					long sendLength = 0;
					double fileMb = fileTotalLength / (1024.0 * 1024.0);
					while ((readLength = fileReader.Read(buffer, 0, buffer.Length)) > 0)
					{
						sendLength += readLength;
						//Console.WriteLine("{0}/{1},{2}", sendLength, fileTotalLength, sendLength * 100.0 / fileTotalLength);
						if (readLength != buffer.Length)
						{
							socket.Send(buffer, 0, readLength, SocketFlags.DontRoute);
						}
						else
							socket.Send(buffer, SocketFlags.DontRoute);
						this.Invoke(new MethodInvoker(delegate
						{
							lbState.Text = string.Format("{0:F2}Mb of {1:F2}Mb @ {2:F2}%", sendLength / (1024.0 * 1024.0), fileMb,
								sendLength * 100.0 / fileTotalLength);
							progress.Value = (int) sendLength;
						}));
					}
					fileReader.Close();
					stream.Close();
					Console.WriteLine("tans complete");
					Thread.Sleep(2000);
				}

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			finally
			{
				this.Invoke(new MethodInvoker(delegate
				{
					btnStartTransfer.Enabled = true;
				}));
			}
		}

		private void btnStartTransfer_Click(object sender, EventArgs e)
		{
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			new Thread(ThreadTransfer, 0).Start(txtIpAddress.Text);
			btnStartTransfer.Enabled = false;
		}

		private void listAllCIAs_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = listAllCIAs.IndexFromPoint(e.Location);
			if (index != ListBox.NoMatches)
			{
				if (ciaToTransfers.Contains(ciaFiles[index]))
				{
					return;
				}
				ciaToTransfers.Add(ciaFiles[index]);
				listCIAsToTransfer.Items.Add(Path.GetFileName(ciaFiles[index]));
			}
		}

		private void listCIAsToTransfer_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = listCIAsToTransfer.IndexFromPoint(e.Location);
			if (index != ListBox.NoMatches)
			{
				ciaToTransfers.RemoveAt(index);
				listCIAsToTransfer.Items.RemoveAt(index);
			}
		}
	}
}
