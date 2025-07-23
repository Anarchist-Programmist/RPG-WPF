using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace rpg.Characters
{
    public class player : INotifyPropertyChanged
    {
        private int MaxHp = 100;
        private int minXp = 25;
        private int hp;
        private int attack;
        private int mana;
        private int xp;
        private int gold;
        private int level;


        public int MinXp
        {
            get => minXp;
            set { minXp = value; OnPropertyChanged("MinXp"); }
        }

        public int HP
        {
            get => hp;
            set { hp = value; OnPropertyChanged("HP"); }
        }

        public int Attack
        {
            get => attack;
            set { attack = value; OnPropertyChanged("Attack"); }
        }

        public int Mana
        {
            get => mana;
            set { mana = value; OnPropertyChanged("Mana"); }
        }

        public int XP
        {
            get => xp;
            set { xp = value; OnPropertyChanged("XP"); }
        }

        public int Gold
        {
            get => gold;
            set { gold = value; OnPropertyChanged("Gold"); }
        }

        public int Level
        {
            get => level;
            set { level = value; OnPropertyChanged("Level"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public class Warrior : player
        {
            public Warrior()
            {
                HP = 100;
                Mana = 100;
                Attack = 5;
                Level = 1;
                XP = 0;
                Gold = 0;
            }
        }

        public class Archer : player
        {
            public Archer()
            {
                HP = 50;
                Mana = 100;
                Attack = 15;
                Level = 1;
                XP = 0;
                Gold = 0;
            }
        }

        public void TakeDamage(int Damage)
        {
            HP = HP - Damage;
        }

        public int DamageHero()
        {
            return Attack;
        }

        public void TakeMoney(int money)
        {
            Gold += money;
        }

        public void TakeXP(int exp)
        {
            XP += exp;
            while (XP >= minXp)
            {
                XP -= minXp;
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Level++;
            HP += 15;
            MaxHp += 15;
            minXp += 10;
            Mana += 15;
            Gold += 5;
            Attack += 2;
        }

        public void Regen()
        {
            if (Gold <= 0)
            {
                MessageBox.Show("Недостаточно золота");
                Gold = Gold;
            }
            else if (HP >= MaxHp)
            {
                MessageBox.Show("У вас полное HP");
                Gold = Gold;
            }
            else if (HP <= MaxHp - 10)
            {
                HP += 10;
                Gold -= 1;
            }
            else if (HP >= MaxHp - 10 && HP != MaxHp)
            {
                HP += MaxHp - HP;
                Gold -= 1;
            }

        }
    }
}
