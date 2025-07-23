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
using static rpg.Characters.Enemy;

namespace rpg
{

    public partial class Fight : Window
    {
        private player player;
        public Enemy RandomEnemy { get; set; }
        private Random random = new Random();
        private string from;
        private static int bigDragonsKilled = 0;

        public Fight(player player, string from)
        {
            InitializeComponent();
            this.player = player;
            Hero.DataContext = player;

            this.from = from;

            SetRandomEnemy();
            SetBackground();
        }

        private void SetRandomEnemy()
        {
            if (from == "Forest")
            {
                if (random.Next(2) == 0)
                {
                    RandomEnemy = new Wolf();
                }
                else
                {
                    RandomEnemy = new Bandit();
                }
                
            }
            else if (from == "BigDragon")
            {
                RandomEnemy = new BigFireDragon();

                if(bigDragonsKilled == 5)
                {
                    RandomEnemy = new KingDragon();
                }
            }
            else if (from == "CubDragon")
            {
                RandomEnemy = new CubFireDragon();
            }
            else
                return;
            
            enemy.DataContext = RandomEnemy;
        }

        private void SetBackground()
        {

            if (from == "Forest")
            {
                ImageBrush brush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/image/Forest.jpg")));
                brush.Stretch = Stretch.Fill;
                this.Background = brush;
            }
            else if (from == "BigDragon" || from == "CubDragon")
            {
                ImageBrush brush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/image/DragonCave.jpg")));
                brush.Stretch = Stretch.Fill;
                this.Background = brush;
            }
        }

        private void BackToForest(object sender, RoutedEventArgs e)
        {
            if (from == "Forest")
            {
                Forest forest = new Forest(player);
                forest.Show();
            }
            else if (from == "BigDragon" || from == "CubDragon")
            {
                Dragon dragon = new Dragon(player);
                dragon.Show();
            }
            else
                return;

            this.Close();
            
        }

        private void StartFigth(object sender, RoutedEventArgs e)
        {
            RandomEnemy.Health -= player.Attack;

            if (RandomEnemy.Health <= 0)
            {
                if(RandomEnemy is BigFireDragon)
                {
                    bigDragonsKilled++;
                }

                player.TakeXP(RandomEnemy.Exp);
                player.TakeMoney(RandomEnemy.Money);
                MessageBox.Show($"Вы победили {RandomEnemy.Name} " +
                    $"и получили {RandomEnemy.Exp} опыта и {RandomEnemy.Money} монет!");

                SetRandomEnemy();
                return;
            }

            if (RandomEnemy is Wolf wolf)
            {
                wolf.Attack(player);
            }
            else if (RandomEnemy is Bandit bandit)
            {
                bandit.Attack(player);
            }
            else if (RandomEnemy is BigFireDragon bigFireDragon)
            {
                bigFireDragon.Attack(player);
            }
            else if (RandomEnemy is CubFireDragon cubFireDragon)
            {
                cubFireDragon.Attack(player);
            }

            if (player.HP <= 0)
            {
                MessageBox.Show("Вы проиграли...");
                MainWindow main = new MainWindow();
                main.Show();

                this.Close();
            }
        }
        
    }
}
