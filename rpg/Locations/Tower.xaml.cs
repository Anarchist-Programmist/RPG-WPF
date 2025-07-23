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
using rpg.Characters;

namespace rpg
{
    /// <summary>
    /// Логика взаимодействия для Tower.xaml
    /// </summary>
    public partial class Tower : Window
    {
        private player player;

        public Tower(player player)
        {
            InitializeComponent();
            this.player = player;
            this.DataContext = player;
        }

        private void GoToForestOne(object sender, RoutedEventArgs e)
        {
            Forest forest = new Forest(player);
            forest.Show();

            this.Close();
        }

        private void Regen(object sender, RoutedEventArgs e)
        {
            player.Regen();
        }
    }
}
