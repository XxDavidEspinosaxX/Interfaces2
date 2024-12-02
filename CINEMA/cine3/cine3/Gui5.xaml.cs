using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace cine3
{

    public partial class Gui5 : Window
    {
        public Gui5()
        {
            InitializeComponent();
        }

        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            Button seat = sender as Button;

            if (seat.Tag.ToString() == "Occupied")
            {
                MessageBox.Show("Este asiento ya está ocupado.");
                return;
            }

            if (seat.Background == Brushes.Orange)
            {
                seat.Background = Brushes.Green;
                seat.Tag = "Free";
            }
            else
            {
                seat.Background = Brushes.Orange;
                seat.Tag = "Selected";
            }
        }
    }
}