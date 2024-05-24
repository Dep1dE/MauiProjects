using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class ProgresDemo : ContentPage
    {
        private CancellationTokenSource cancellationTokenSource;
        private bool flag;
        public ProgresDemo()
        {
            InitializeComponent();
           
        }

        public void load()
        {
            for (int i = 0; i < 20000; i++)  //Нужно потом изменить на 100000
            {
                int a = 2, b = 3;
                a = a * b;
            }
        }

        private async void CalculateIntegral(object sender, EventArgs e)
        {
            double h = 0.00000001;
            double sum = 0.0;
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            Proc.Text = "Вычисление";
            try
            {
                await Task.Run(async () =>
                {
                    for (int i = 0; i < 1000000; i += 50)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        load();
                        double x_i = i * h;
                        sum += Math.Sin(x_i);

                        int progress = (int)((i / 1000000.0));

                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            progressBar1.Progress = progress / 100.0;
                            ouputLabel.Text = progress.ToString() + '%';
                        });

                    }
                    await MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        progressBar1.Progress = 1;
                        ouputLabel.Text = "100%";
                    });
                    
                    flag= false;

                }, cancellationToken);
            }

            catch (OperationCanceledException)
            {
                Proc.Text = "Задание отменено";
            }
        }

        private void Start(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
                CalculateIntegral(sender, e);
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            flag= false;
            cancellationTokenSource?.Cancel();
        }
    }
}
