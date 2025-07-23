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
    public partial class Forest : Window
    {
        private player player;

        public Forest(player player)
        {
            InitializeComponent();
            this.player = player;
            this.DataContext = player;
        }

        private void GoToTower(object sender, RoutedEventArgs e)
        {
            Tower tower = new Tower(player);
            tower.Show();

            this.Close();
        }

        private void GoToDragon(object sender, RoutedEventArgs e)
        {
            Dragon dragon = new Dragon(player);
            dragon.Show();

            this.Close();
        }

        private void StartOneFight(object sender, RoutedEventArgs e)
        {
            Fight fight = new Fight(player, "Forest");
            fight.Show();

            this.Close();
        }
    }
}
