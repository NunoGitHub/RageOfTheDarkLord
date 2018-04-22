﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Rage_of_the_Dark_Lord.SpritesClass.Map;
using Rage_of_the_Dark_Lord.SpritesClass.Caracter;

namespace Rage_of_the_Dark_Lord.SpritesClass.Enemies
{
    class Zombie
    {

        public Rectangle Rectangle { get; set; }
        public Texture2D Texture { get; set; }
        public int VelocityX { get; set; }
        public int Direction { get; set; }
        public static Rectangle zombieRectangle ;
        public static int zombieLife = 100;
        public bool attack = true;
        Rectangle zombieColision;
        double time = 0;
    
        Color color= new Color();
        




        public Zombie(Texture2D texture, Rectangle rec, int velocityX, int direction)
        {
            this.Rectangle = rec;
            this.Texture = texture;
            this.VelocityX = velocityX;
            this.Direction = direction;
            
        }

        public Zombie() { }
        public void UpdateTimer(double deltaTime)//contador de segundos
        {
            time +=deltaTime;
            
            
           // Debug.WriteLine("Timer: " + time);
        }

        public void ZombieMove() {
           zombieRectangle= this.Rectangle = new Rectangle(this.Rectangle.X + (this.VelocityX*this.Direction),this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
        }

        public void ZombieChageDirection() {
            if (this.Rectangle.Intersects(Terrain1.listTerrain[4].Rectangle)==true) {
                this.Direction = -1;
            }
            if (this.Rectangle.Intersects(Terrain1.listTerrain[1].Rectangle) == true)
            {
                this.Direction = 1;
            }

        }

        /*   public void ZombieLife() {
               zombieColision = new Rectangle(zombieRectangle.X - 60, zombieRectangle.Y - 25, 120, 60);
               //////ataca pela esquerda
               if (zombieColision.Intersects(Ecir.cameraMove) && zombieRectangle.X >= Ecir.cameraMove.X && Ecir.directionPositive==true /* && Ecir.direction>0 */ /*&& zombieRectangle.X <= Ecir.cameraMove.X + 60 *///&& Ecir.EcirAtack() == true && attack==true)
                /* {
                    
                    zombieLife = zombieLife - 50;
                     attack = false;
                   }
                    if (Ecir.EcirAtack() == false) {
                      attack = true;
                    }
                    //////ataca pela direita
               if (zombieColision.Intersects(Ecir.cameraMove) && zombieRectangle.X <= Ecir.cameraMove.X && Ecir.directionNegative == true /* && Ecir.direction>0 */ /*&& zombieRectangle.X <= Ecir.cameraMove.X + 60 *///&& Ecir.EcirAtack() == true && attack == true)
                /*{
                              zombieLife = zombieLife - 50;
                              attack = false;
                           }
                     if (Ecir.EcirAtack() == false)
                    {
                         attack = true;
                    }

                     if (zombieLife == 0)
                      {
                           Console.WriteLine("Zombie is destroyed");
                     }
                       Console.WriteLine("Zombie life=" + zombieLife);

                   }
            }*/

    /*    public int zzz()
        {
            int auxTimeNow = DateTime.Now.Second;
            int auxt = 500;
          
            
          
            
            while (Ecir.EcirAtack() == 1 && zombieLife==100)
            {
                int i = 0;
                ZombieLife(i);
               
                Console.WriteLine("Zombie life=" + zombieLife);
                i++;
                return zombieLife;
            }

           
            if (Ecir.EcirAtack()==1 && zombieLife == 50 )
            {
                while (auxt != 0)
                {
                    auxt--;
                   
                    int auxTimeNowLater = DateTime.Now.Second - DateTime.Now.Second + auxt;
                    Console.WriteLine("Timeee=" + auxTimeNowLater);

                }
                if (auxt == 0)
                {
                    ZombieLife(1);
                   
                    Console.WriteLine("Zombie life=" + zombieLife);

                    return zombieLife;
                }

            }
            return 0;
        }*/

            public int ZombieLife()
            {
            zombieColision = new Rectangle(zombieRectangle.X - 60, zombieRectangle.Y - 25, 120, 60);
           
            //////Ecir ataca pela direita
            if (zombieColision.Intersects(Ecir.cameraMove) && zombieRectangle.X >= Ecir.cameraMove.X && Ecir.directionPositive == true && Ecir.EcirAttack() == 1 )
            {
                if ( zombieLife!=50 && zombieLife!=0)
                {
                    time = 0;
                    zombieLife =50;
                    return zombieLife;
                    
                }
                if (  time >=1)
                {
                    zombieLife = 0;
                    return zombieLife;
                }
                return zombieLife;
            }

            //////Ecir ataca pela esquerda
            if (zombieColision.Intersects(Ecir.cameraMove) && zombieRectangle.X <= Ecir.cameraMove.X && Ecir.directionNegative == true && Ecir.EcirAttack() == 1)
            {
                if ( zombieLife != 50 && zombieLife != 0)
                {
                    time = 0;

                    zombieLife = 50;
                    ZombieColor();
                    return zombieLife;

                }
                if (time >= 1)
                {
                    zombieLife = 0;
                    return zombieLife;
                }
                return zombieLife;
            }
           
          //  Console.WriteLine("Zombie life=" + zombieLife);
            return zombieLife;
        }

        public Color ZombieColor() {//muda a cor do zombie quando leva dano do jogador e muda de cor da barra de vida do zombie para que a vida  do zombie só apareça quado leva dano
               
            if (time >= 0 && zombieLife==50 && time <= 1) {
                color = Color.Red;
                return Color.Red;
            }
            if (time >= 0 && zombieLife == 50) {
                color = Color.Transparent;
                return Color.White;
            }
            if (time >= 0 && zombieLife == 0)
            {
                color =Color.Red;
                return Color.Red;
            }
            return Color.White;

        }

        public bool DestroyZombie() {// se a vida do zombie chegar a 0 passa a true se for diferente de 0 é falso

            if (zombieLife == 0) {
                return true;
            }

            return false;
        }
        public Rectangle ZombieBarLife() {//barra da vida do zombie zombie

            return new Rectangle(this.Rectangle.X - 2, this.Rectangle.Y - 10, (int)(zombieLife*0.2), 5);

        }
        public Color ColorBar() {//cor da barra do zombie

            return color;
        }
    }
}
