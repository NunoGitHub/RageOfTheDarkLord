using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Rage_of_the_Dark_Lord.SpritesClass.Map;
using Rage_of_the_Dark_Lord.SpritesClass.Enemies;

namespace Rage_of_the_Dark_Lord.SpritesClass.Caracter
{
   public class Ecir
    {
       
        private bool clickedJump = false;
        Terrain1 terrain1 = new Terrain1();
        private bool jump = false, takeLife = true, takeLifeOgre=true, countTime = false, countTimeOgre=false, colision=true;
        private int count = 2, changeColor=0;
        private bool reverse = false, hollowKnightTouch = true, dontJump=false, ogreTouch=true;
        int indexTerrain = 0, indexSpike, jumpHeight=135;
        public static Rectangle cameraMove;
        int life  = 100;
        bool ZombieNotTouch = true, lateralColision=false, barAlwaysMove=false, ecirNotToutcSpike=true, killTime=false;
        public static bool directionPositive = false, directionNegative = false;
        Color color = Color.White;
         double time = 0;



        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Direction { get; set; }

        public Ecir(Texture2D texture, Rectangle rec, Vector2 velocity, Vector2 direction)
        {
            this.Texture = texture;
            this.Rectangle = rec;
            this.Velocity = velocity;
            this.Direction = direction;
           
        }
        public Ecir()
        {
        }
        public Ecir(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public Rectangle EcirVelocity(int velocityX, int velocityY)
        {       
                 this.Rectangle = new Rectangle(this.Rectangle.X +velocityX, this.Rectangle.Y +velocityY, this.Rectangle.Width, this.Rectangle.Height);
            cameraMove=this.Rectangle;
            return this.Rectangle;
        }
        public Rectangle EcirJump(int velocityX, int velocityY)
        {
             this.Rectangle = new Rectangle(this.Rectangle.X + velocityX, this.Rectangle.Y-velocityY, this.Rectangle.Width, this.Rectangle.Height);

            cameraMove=this.Rectangle;
            return this.Rectangle;
        }

        public void EcirMove(int velocityX, int velocityY) {

           

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && lateralColision==false)
            {
                directionNegative = false;
                directionPositive = true;
                EcirVelocity(velocityX, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && lateralColision==false)
            {
                directionPositive = false;
                directionNegative = true;
                EcirVelocity(velocityX*-1, 0);
            }
            
            /* Faz a personagem saltar usando o metodo Gravity e depois cair terrain 1*/
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && clickedJump == false)
            {
                jump = true;
            }
            if (jump == true)
            {
                int i = 0;
                    
                while (i < 2 && this.Rectangle.Y >= Terrain1.listTerrain[indexTerrain].Rectangle.Y - jumpHeight && reverse== false && Stairs.climbStairs==false)//reverse quando inverte o sentido, saltar
                {
                    Gravity(-1, 1.5f);
                    i++;
                  
                }     
               
            }
            if (Stairs.climbStairs == true )
            {//a subir as escadas
                jumpHeight = 0;
                if (Keyboard.GetState().IsKeyUp(Keys.Up) == true)
                    Gravity(-1, 1.5f);//Quando solto a tecla Tira a gravidade  não desce
                if (Keyboard.GetState().IsKeyDown(Keys.Up)) Gravity(-1, 2f);//sobe as escadas
                if (Keyboard.GetState().IsKeyDown(Keys.Down)) {  Gravity(1, 1f);  }//desce
                //if (Keyboard.GetState().IsKeyDown(Keys.Down) ) Gravity(1, 2f);

                    if (this.Rectangle.Y <= 216) { Stairs.climbStairs = false; jump = true; /*Gravity(1, 2f);*/ }// não deixa subir mais
                if (this.Rectangle.Y >= 216 ) jump = true;//faz que não suba infinitamente quando sobe e desce das escadas sem tocar no terrain
                if (jump == true && (Keyboard.GetState().IsKeyDown(Keys.Down)) && Stairs.climbStairs==true) {
                    jump = false;  }
                
            }
            if (jumpHeight == 0 && Stairs.climbStairs == false) {//ao cair das escadas retiro a gravidade excessiva
                //indexTerrain = 12;
               Gravity(-1, 2.5f);
               /* if (this.Rectangle.X >= 1850)
                {
                    Gravity(1, 2f);  jump = true;
                }*/
            }
            int j = 0;
            while (j < count && this.Rectangle.Y<= Terrain1.listTerrain[indexTerrain].Rectangle.Y - jumpHeight && jump==true && Stairs.climbStairs==false)//cair
            {

                reverse = true;
                Gravity(1, 1.5f);
                j++;
            }

        }
        public void Gravity(int onOff, float gravytY) {

            EcirVelocity(0, (int)(2 * onOff * gravytY));
        }


        //Define  Quando esta a colidir com o terreno e define os bool dos saltos para para o ecirMove
        public void TerrainColisions()
        {
            if (colision == true)
            {
                for (int i = 0; i < 20; i++)
                {
                    if ( i != 13 || i != 15 || i != 18 || i != 16 || i != 17)
                    {
                        colision = true;
                    }
                    else { colision = false; }
                   
                    if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[i].Rectangle) == true) indexTerrain = i;
                    Console.WriteLine("index="+i);

                }
            }
           /* if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[0].Rectangle) == true) indexTerrain = 0;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[1].Rectangle) == true) indexTerrain = 1;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[2].Rectangle) == true) indexTerrain = 2;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[3].Rectangle) == true) indexTerrain = 3;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[4].Rectangle) == true) indexTerrain = 4;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[5].Rectangle) == true) indexTerrain = 5;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[6].Rectangle) == true) indexTerrain = 6;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[7].Rectangle) == true) indexTerrain = 7;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[8].Rectangle) == true) indexTerrain = 8;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[9].Rectangle) == true) indexTerrain = 9;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[10].Rectangle) == true) indexTerrain = 10;
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[11].Rectangle) == true) indexTerrain = 11;*/
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[12].Rectangle) == true) { jump = true; indexTerrain = 12; }
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[13].Rectangle) == true && Stairs.climbStairs == false) { indexTerrain = 13; jumpHeight = 135; }
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[14].Rectangle) == true) { indexTerrain = 14;colision = true; }
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[15].Rectangle) == true && Stairs.climbStairs == false) { indexTerrain = 15; jumpHeight = 135; }
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[13].Rectangle) == true && Stairs.climbStairs == true || Stairs.climbStairs == false && jumpHeight == 0) { indexTerrain = 12; }//para poder descer/ ao cair pela esquerda cai até ao terrain index 12
            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[18].Rectangle) == true || this.Rectangle.Intersects(terrain1.ReturnTerrain()[17].Rectangle) == true || this.Rectangle.Intersects(terrain1.ReturnTerrain()[16].Rectangle) == true) indexTerrain = 15;
           // if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[19].Rectangle) == true) colision=true;

                /*
                if (dontJump == false)
                {
                    if (this.Rectangle.X >= 1890 && this.Rectangle.X <= 2101 && this.Rectangle.Y >= 220) { indexTerrain = 13; Stairs.climbStairs = false; }
                    if (Keyboard.GetState().IsKeyDown(Keys.Down) == true && this.Rectangle.X >= 1866 && this.Rectangle.X <= 1888 && this.Rectangle.Intersects(Stairs.listStairs[Stairs.indexStairs].Rectangle) == true) { indexTerrain = 12; jump = true; }//para poder dexer a escada
                    if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[14].Rectangle) == true) indexTerrain = 14;
                    // if (this.Rectangle.Y >= 220) Stairs.climbStairs = false;}

                }
                if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[15].Rectangle) == true && dontJump!=false) {
                    indexTerrain = 15;/* Stairs.climbStairs = false; jump = true;*/ /*jumpHeight = 135;*/ /*dontJump = true; }
                if (Stairs.climbStairs==true ) {
                    dontJump = false; }*/



                //spike colisions

                if (this.Rectangle.Intersects(SpikesTrap.listSpikesTrap[0].Rectangle) == true)
            { indexSpike = 0; }
            if (this.Rectangle.Intersects(SpikesTrap.listSpikesTrap[1].Rectangle) == true)
            { indexSpike = 1; }

            if (this.Rectangle.Intersects(terrain1.ReturnTerrain()[indexTerrain].Rectangle)==true )
            {
               
                clickedJump = false;
                Gravity(0, 0.5f);
                reverse = false;
                jump = false;
                jumpHeight = 135;
              
            }
           else {
                clickedJump = true;
                Gravity(1, 1.5f);
            }
            // lateral colisions 
            Rectangle lateralTerrain1_1 = new Rectangle(200, 502, 0, 100);
            Rectangle lateralTerrain1_4 = new Rectangle(600, 502, 0, 100);
            Rectangle lateralTerrain1_7 = new Rectangle(840, 456, 0, 100);
            Rectangle lateralTerrain1_9 = new Rectangle(1440, 456, 0, 100);
            Rectangle lateralTerrain1_11 = new Rectangle(1500, 456, 0, 100);
            Rectangle lateralTerrain1_13 = new Rectangle(1903, 272, 0, 10);
            Rectangle lateralTerrain1_20 = new Rectangle(2100, 278, 0, 400);
            if (this.Rectangle.Intersects(lateralTerrain1_1))EcirVelocity(2, 0);/* this.Rectangle.X<=198 && this.Rectangle.X>=194 && this.Rectangle.Y>=481)*/
            if (this.Rectangle.Intersects(lateralTerrain1_4)) EcirVelocity(-2, 0);/*this.Rectangle.X>=570 && this.Rectangle.X<=575 && this.Rectangle.Y>=481*/
            if(this.Rectangle.Intersects(lateralTerrain1_7)) EcirVelocity(-2,0);
            if (this.Rectangle.Intersects(lateralTerrain1_9)) EcirVelocity(2, 0);
            if (this.Rectangle.Intersects(lateralTerrain1_11)) EcirVelocity(-2, 0);
            if (this.Rectangle.Intersects(lateralTerrain1_13)) EcirVelocity(-2, 0);
            if (this.Rectangle.Intersects(lateralTerrain1_20)) EcirVelocity(-2, 0);

        }

       public void EcirLife() {//vida do ecir, este sofre dano pelos inimigos

            //Zombie takes ecir life////////////////////////////////////////////
            if (Zombie.zombieLife != 0)//pois mesmo invisivel continuava a tirar vida ao ecir porque guardava a ultima posição
            {
                if (this.Rectangle.Intersects(Zombie.zombieRectangle) == true && ZombieNotTouch == true)
                {
                    color = Color.Red;
                    life = life - 20;
                    ZombieNotTouch = false;
                }
                if (this.Rectangle.Intersects(Zombie.zombieRectangle) == false && ZombieNotTouch == false )
                {
                    ZombieNotTouch = true;
                    color = Color.White;
                }
            }
               
            //Hollow knight takes ecir life
            if (HollowKnight.listHollowKnight[HollowKnight.index] != null)
            {
                if (this.Rectangle.Intersects(HollowKnight.hollowAttackArea) && hollowKnightTouch == true)
                {   if(countTime==false)
                    time = 0;
                    killTime = true;
                    countTime = true;
                    HollowKnight.listHollowKnight[HollowKnight.index].VelocityX = 0;
                    if (time >= 1 && takeLife==true)// Hollow knight para e ataca
                    {
                        color = Color.Red;
                        life = life - 40;
                        takeLife = false;

                    }
                    if (time >= 1.5)
                    {//Hollow knight continua a andar depois do ataque
                        HollowKnight.listHollowKnight[HollowKnight.index].VelocityX = 2;
                        hollowKnightTouch = false;
                        time = 0;
                        killTime = false;
                        takeLife = true;
                    }
                }
                if (time >= 1.5)//quando para para atacar mas o jogador foge então o encir continua a andar
                {
                    HollowKnight.listHollowKnight[HollowKnight.index].VelocityX = 2;
                    hollowKnightTouch = false; 
                   // killTime = false;
                    takeLife = true;
                    countTime = false;
                }
                if (this.Rectangle.Intersects(HollowKnight.hollowAttackArea) == false && hollowKnightTouch == false)
                {
                    hollowKnightTouch = true;
                    if(time < 1.6) {
                        if (changeColor != 1) 
                        color = Color.White;
                    }
                    
                    HollowKnight.listHollowKnight[HollowKnight.index].VelocityX = 2;
                    takeLife = true;
                  //  countTime = false;


                }
                //Ecir fall in Spiketrap 

                if (this.Rectangle.Intersects(SpikesTrap.listSpikesTrap[indexSpike].Rectangle) == true && ecirNotToutcSpike == true)
                {
                    changeColor = 1;
                    color = Color.Red;
                    life = life - 50;
                    ecirNotToutcSpike = false;

                }
                if (this.Rectangle.Intersects(SpikesTrap.listSpikesTrap[indexSpike].Rectangle) == false && ecirNotToutcSpike == false)
                {
                    ecirNotToutcSpike = true;
                    changeColor = 2;
                    color = Color.White;
                }
            }
            Console.WriteLine("Time=" + time);
            /// Ogre takes Ecir life

            if (Ogre.listOgre[Ogre.index] != null)
            {
                if (this.Rectangle.Intersects(Ogre.ogreAttackArea) && ogreTouch == true)
                {   if (countTimeOgre == false)
                    time = 0;
                    killTime = true;
                    countTimeOgre = true;
                    Ogre.listOgre[Ogre.index].VelocityX = 0;
                    if (time >= 1.6 && takeLifeOgre == true)// ogre  para e ataca
                    {
                        color = Color.Red;
                        life = life - 60;
                        takeLifeOgre = false;
                        

                    }
                    if (time >= 2)
                    {//Ogre  continua a andar depois do ataque
                        Ogre.listOgre[Ogre.index].VelocityX = 1;
                        ogreTouch = false;
                        time = 0;
                        killTime = false;
                        takeLifeOgre = true;
                    }
                }
                if (time >= 2)//quando para para atacar mas o jogador foge então o encir continua a andar
                {
                    Ogre.listOgre[Ogre.index].VelocityX = 1;
                    ogreTouch = false;
                    countTimeOgre = false;
                    // killTime = false;
                    takeLifeOgre = true;
                }
                if (this.Rectangle.Intersects(Ogre.ogreAttackArea) == false && ogreTouch == false)
                {
                    ogreTouch = true;
                    if (changeColor != 1)
                        color = Color.White;
                    Ogre.listOgre[Ogre.index].VelocityX = 1;
                    takeLifeOgre = true;

                }
                
            }

            //////////////////////////////////////////////
            

        }

        public bool EcirDestroy() {//se a vida do Ecir chegar a 0 passa a true se for diferente de 0 é falso
            if (life == 0) {

                return true;
            }
            return false;
        }
        
        public static  int EcirAttack() {
            
            if (Keyboard.GetState().IsKeyUp(Keys.Space)) {
               
                
                return 0;//false

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {

                return 1;//true

            }
            return 2;//nada


        }

        public Rectangle BarLifeEcir() {//barra de vida do ecir
            if (this.Rectangle.X <= (740 / 2) - 190 && barAlwaysMove==false)
            {
                return new Rectangle(-335, 210, life, 15);
            }
            else
            {
                barAlwaysMove = true;
                return new Rectangle(this.Rectangle.X - 515, this.Rectangle.Y - 241, life, 15);
            }
     
        }
        public Color EcirColor() { return color;}
        public void UpdateTime(double deltaTime)//contador de segundos
        {
            if(killTime == true)
            time += deltaTime;
        }

    }
}
