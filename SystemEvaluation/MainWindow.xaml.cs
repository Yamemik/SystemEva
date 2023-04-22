using System;
using System.Windows;

namespace SystemEvaluation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool bTrue = true;
        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            if (bTrue)
            {
                StudentWindow studentWindow = new StudentWindow();
                studentWindow.Show();
                this.Visibility = Visibility.Hidden;
                bTrue = false;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var response = MessageBox.Show("Закрыть приложение?", "Выход...",
                                           MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (response == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Автоматизированная информационная система аптеки\n" +
                "Автор: Подкорытова Виктория\n" +
                "Версия: 1.0.0");
        }

        private void btmRate_Click(object sender, RoutedEventArgs e)
        {
            RatingWindow ratingWindow = new RatingWindow();
            ratingWindow.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btnOrg_Click(object sender, RoutedEventArgs e)
        {
            OrgWindow orgWindow = new OrgWindow();
            orgWindow.Show();
        }

        private void btnTxt_Click(object sender, RoutedEventArgs e)
        {
            DataUseWindow dataUse = new DataUseWindow();
            dataUse.Show();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
