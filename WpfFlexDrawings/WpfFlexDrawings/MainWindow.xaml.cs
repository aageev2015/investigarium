// for capturing used https://github.com/shimat/opencvsharp

using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfFlexDrawings
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : System.Windows.Window
	{
		private readonly OpenCvSharp.VideoCapture videoCapture;
		private readonly BackgroundWorker videoCaptureWorker;

		private readonly Image commonImage;

		public MainWindow()
		{
			InitializeComponent();

			videoCapture = new OpenCvSharp.VideoCapture();
			videoCaptureWorker = new BackgroundWorker { WorkerSupportsCancellation = true };
			videoCaptureWorker.DoWork += captureWorker_OnDoWork;

			commonImage = new Image();
			Canvas.SetTop(commonImage, 0);
			Canvas.SetLeft(commonImage, 0);
			cnvClient.Children.Add(commonImage);
		}

		#region Window event handlers

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			var fileName = requestImageFileFromUser();
			if (string.IsNullOrEmpty(fileName))
			{
				return;
			}

			clearAll();
			var bmp = new BitmapImage(new Uri(fileName));
			commonImage.Width = bmp.Width;
			commonImage.Height = bmp.Height;
			commonImage.Source = bmp;
			cnvClient.Children.Remove(commonImage);
			cnvClient.Children.Add(commonImage);
		}

		private void btnCaptureFromCamera_Click(object sender, RoutedEventArgs e)
		{
			startCameraCapture();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			clearAll();
			cameraDispose();
		}

		#endregion

		#region Image Processing

		private string requestImageFileFromUser()
		{
			var dialog = new Microsoft.Win32.OpenFileDialog();
			dialog.FileName = "Image";
			dialog.DefaultExt = ".png";
			dialog.Filter = "(.png)|*.png";
			bool? result = dialog.ShowDialog();
			return result == true ? dialog.FileName : null;
		}

		#endregion

		#region Camera capture processing

		private void startCameraCapture()
		{
			if (videoCapture.IsOpened())
			{
				MessageBox.Show($"Already capturing. Nothing changed");
				return;
			}
			clearAll();

			videoCapture.Open(0, VideoCaptureAPIs.ANY);
			videoCapture.Set(VideoCaptureProperties.FrameWidth, 680);
			videoCapture.Set(VideoCaptureProperties.FrameHeight, 480);
			if (!videoCapture.IsOpened())
			{
				MessageBox.Show($"Open camera capture failed");
				return;
			}
			videoCaptureWorker.RunWorkerAsync();
		}

		private async void stopCameraCapture()
		{
			if (videoCapture.IsOpened())
			{
				videoCaptureWorker.CancelAsync();
				videoCapture.Release();
				/*while (videoCaptureWorker.CancellationPending)
				{
					await Task.Delay(50);
				}
				Thread.Sleep(1000);*/
			}
		}

		private void cameraDispose()
		{
			videoCapture.Dispose();
		}

		private void captureWorker_OnDoWork(object sender, DoWorkEventArgs e)
		{
			var worker = (BackgroundWorker)sender;
			while (!worker.CancellationPending)
			{
				using (var frameMat = videoCapture.RetrieveMat())
				{
					Dispatcher.Invoke(() =>
					{
						commonImage.Width = cnvClient.Width;
						commonImage.Height = cnvClient.Height;
						commonImage.Source = frameMat.ToWriteableBitmap();
					});
				}

				Thread.Sleep(30);
			}
		}
		#endregion

		#region Commmon tools
		private void clearAll()
		{
			stopCameraCapture();
		}
		#endregion
	}
}
