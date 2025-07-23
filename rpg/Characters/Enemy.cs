using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace rpg.Characters
{
    public class Enemy : INotifyPropertyChanged
    {
        private int health;
        private int damage;
        private int exp;
        private int money;
        private string name;

        public int Health
        {
            get => health;
            set { health = value; OnPropertyChanged("Health"); }
        }

        public int Damage
        {
            get => damage;
            set { damage = value; OnPropertyChanged("Damage"); }
        }

        public int Exp
        {
            get => exp;
            set { exp = value; OnPropertyChanged("Exp"); }
        }
        public int Money
        {
            get => money;
            set { money = value; OnPropertyChanged("Money"); }
        }

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged("Name"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public class Wolf : Enemy
        {
            public Wolf()
            {
                Health = 30;
                Damage = 13;
                Exp = 10;
                Money = 5;
                Name = "Wolf";
            }
            public void Attack(player player)
            {
                player.TakeDamage(Damage);
            }
        }

        public class Bandit : Enemy
        {
            public Bandit()
            {
                Health = 50;
                Damage = 4;
                Exp = 5;
                Money = 5;
                Name = "Bandit";
            }

            public void Attack(player player)
            {
                player.TakeDamage(Damage);
            }
        }

        public class BigFireDragon : Enemy
        {
            public BigFireDragon()
            {
                Health = 200;
                Damage = 80;
                Exp = 200;
                Money = 100;
                Name = "Big Fire Dragon";
            }
            public void Attack(player player)
            {
                player.TakeDamage(Damage);
            }
        }

        public class KingDragon : Enemy
        {
            public KingDragon()
            {
                Health = 1000;
                Damage = 280;
                Exp = 1000;
                Name = "King Dragon";
            }
            public void Attack(player player)
            {
                player.TakeDamage(Damage);
            }
        }

        public class CubFireDragon : Enemy
        {
            public CubFireDragon()
            {
                Health = 100;
                Damage = 30;
                Exp = 50;
                Name = "Cub Fire Dragon";
            }
            public void Attack(player player)
            {
                player.TakeDamage(Damage);
            }
        }
    }
}
