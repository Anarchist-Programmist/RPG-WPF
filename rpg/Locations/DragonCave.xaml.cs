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
    public partial class Dragon : Window
    {
        private player player;

        public Dragon(player player)
        {
            InitializeComponent();
            this.player = player;
            this.DataContext = player;
        }

        private void GoToForestTwo(object sender, RoutedEventArgs e)
        {
            Forest forest = new Forest(player);
            forest.Show();

            this.Close();
        }

        private void FightMiniDragon(object sender, RoutedEventArgs e)
        {
            Fight fight = new Fight(player, "CubDragon");
            fight.Show();

            this.Close();
        }

        private void FightDragon(object sender, RoutedEventArgs e)
        {
            Fight fight = new Fight(player, "BigDragon");
            fight.Show();

            this.Close();
        }
    }
}
