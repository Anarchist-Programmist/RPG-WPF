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
using System.Windows.Navigation;
using System.Windows.Shapes;
using rpg.Characters;
using static rpg.Characters.player;

namespace rpg
{
    public partial class MainWindow : Window
    {
        public player player { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

    private void Start(object sender, RoutedEventArgs e)
        {
            if (player == null)
            {
                MessageBox.Show("Сначала выберите класс!");
                return;
            }

            var forest = new Forest(player);
            forest.Show();

            this.Close();
        }

    private void Warrior(object sender, RoutedEventArgs e)
        {
            player = new Warrior();

        }

    private void Archer(object sender, RoutedEventArgs e)
        {
            player = new Archer();
        }
    }
}
