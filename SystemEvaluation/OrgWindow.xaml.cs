using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace SystemEvaluation
{
    public partial class OrgWindow : Window
    {
        public OrgWindow()
        {
            InitializeComponent();

            Timer t = new Timer(1000);
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime ci = DateTime.Now;
            this.Dispatcher.Invoke(new Action(() => this.Label1.Content = ci.ToLongTimeString()));
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get reference.
            var calendar = sender as Calendar;

            // ... See if a date is selected.
            if (calendar.SelectedDate.HasValue)
            {
                // ... Display SelectedDate in Title.
                DateTime date = calendar.SelectedDate.Value;
                this.Title = date.ToShortDateString();

            }
        }

        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
