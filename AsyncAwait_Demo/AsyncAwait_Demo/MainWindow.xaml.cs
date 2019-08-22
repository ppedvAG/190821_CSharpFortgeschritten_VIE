using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwait_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Start");
            //await Task.Run(() =>
            //{
            //    for (int i = 0; i <= 100; i++)
            //    {
            //        Thread.Sleep(100);
            //        // Logik auf dem UI-Thread ausführen
            //        Dispatcher.Invoke(() => progressBarWert.Value = i);
            //    }
            //});

            Task t1 = Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            Task t2 = Task.Run(() =>
            {
                Thread.Sleep(5000);
            });
            Task t3 = Task.Run(() =>
            {
                Thread.Sleep(10000);
            });
            
            await Watchdog(t1, t2, t3);
            MessageBox.Show("Ende");
        }

        private async Task Watchdog(params Task[] tasksToAwait)
        {
            while(tasksToAwait.Any(x => x.IsCompleted == false))
            {
                await Task.Delay(100);
            }
        }
    }
}
