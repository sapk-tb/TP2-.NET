using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace TP2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int ballonCount = 0;

        public int premierCount = 0;

        List<Thread> _threads = new List<Thread>(); //Our thread list

        public MainWindow()
        {
            System.Console.WriteLine("Init");
            InitializeComponent();
            System.Console.WriteLine("Ready");

            pwdTextBox.Text = System.IO.Directory.GetCurrentDirectory();
            countBallonTextBox.Text = ballonCount.ToString();
            countPremierTextBox.Text = premierCount.ToString();

            this.Closed += MainWindow_Closed;
        }


        private void MainWindow_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void T_Exited(object sender, EventArgs e)
        {
            System.Console.WriteLine("Some child has closed");
            refreshClick(null, null);
        }

        private void quitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void refreshClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void startBallonBtnClick(object sender, RoutedEventArgs e)
        {
            if (ballonCount >= 5)
            {
                MessageBox.Show("Allready 5 Ballon thread started !", "Warning !");
                return;
            }
            
            var b = new Ballon.Ballon();
            Thread t = new Thread(new ThreadStart(b.Go));
            t.Start();
            _threads.Add(t);
            //b.Go();
            //b.Close();
            ballonCount++;
        }
        private void startPremierBtnClick(object sender, RoutedEventArgs e)
        {
            if (premierCount >= 5)
            {
                MessageBox.Show("Allready 5 Premier thread started !", "Warning !");
                return;
            }
            //var p = new Premier.NombrePremier();
            //Application.Run(p);
            //Application.Run(p);
            //var p = new Premier.NombrePremier();
            /*
            Thread t = new Thread(new ThreadStart(Premier.NombrePremier.Main));
            t.Start();
            _threads.Add(t);
            */
            //Application.Run(new Premier.NombrePremier.Main());
            Thread t = new Thread(new ThreadStart( delegate
            {

                Premier.NombrePremier.Main();
            }
                ));
            premierCount++;
        }
        private void closeLast(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void closeLastBallon(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void closeLastPremier(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void closeAll(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /*
        private void startThread(string str)
        {
            throw new NotImplementedException();
        }
        */
        private void addToList(string str)
        {
            var l = new ListBoxItem();
            l.Content = str;
            listBox.Items.Add(l);
            countBallonTextBox.Text = ballonCount.ToString();
            countPremierTextBox.Text = premierCount.ToString();
        }
    }
}
