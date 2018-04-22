using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Rage_of_the_Dark_Lord.SpritesClass.Caracter;
namespace Rage_of_the_Dark_Lord.SpritesClass.Enemies
{
    class HollowKnight
    {

        public static List<HollowKnight> listHollowKnight = new List<HollowKnight>(new HollowKnight[100]);
        public static int index;//indice do hollow knight
        double time = 0;
        Texture2D HollowKnightBarLife;
        public static  Rectangle hollowKnightCol, hollowAttackArea;

        public Rectangle Rectangle { get; set; }
        public Texture2D Texture { get; set; }
        public int VelocityX { get; set; }
        public int Direction { get; set; }
        public int Life { get; set; }
        public Color Color { get; set; }
        public Color KnightColor { get; set; }
        //color = hollowknight Bar life
        public HollowKnight(Rectangle rect, Texture2D texture, int velocityX, int direction, int life, Color color, Color knightColor) {
            Rectangle = rect;
            Texture = texture;
            VelocityX = velocityX;
            Direction = direction;
            Life = life;
            Color= color;
            KnightColor = knightColor;

        }

        public HollowKnight() { }

        public void InsertHollowKnight(GraphicsDeviceManager graphics) {

            listHollowKnight.Insert(0, new HollowKnight(new Rectangle(840, 402, 65, 65), new Texture2D(graphics.GraphicsDevice, 50, 50),2,1,200,Color.Transparent,Color.White));
            HollowKnightBarLife = new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            HollowKnightBarLife.SetData(new Color[] { Color.Red });

            listHollowKnight.Insert(1, new HollowKnight(new Rectangle(1498, 402, 65, 65), new Texture2D(graphics.GraphicsDevice, 50, 50), 2, 1, 200,Color.Transparent,Color.White));

        }
        public void Draw(SpriteBatch spriteBatch) {
           
            if (listHollowKnight[0] != null)
            {
                spriteBatch.Draw(listHollowKnight[0].Texture, listHollowKnight[0].Rectangle, listHollowKnight[0].KnightColor);
                spriteBatch.Draw(HollowKnightBarLife, HollowKnightDrawBarLife(0), listHollowKnight[0].Color);
            }
            if (listHollowKnight[1] != null )
            {
                spriteBatch.Draw(listHollowKnight[1].Texture, listHollowKnight[1].Rectangle, listHollowKnight[1].KnightColor);
                spriteBatch.Draw(HollowKnightBarLife, HollowKnightDrawBarLife(1), listHollowKnight[1].Color);
            }
            //all
        }
        public void LoadContent(ContentManager Content) {

            listHollowKnight[0].Texture = Content.Load<Texture2D>("HollowKnight");
            listHollowKnight[1].Texture = Content.Load<Texture2D>("HollowKnight");
        }

        public void HollowKnightMove()//Movimento do hollow knight
        {
            //Primeiro hollow knight
            if (listHollowKnight[0] != null)
            {
                if (listHollowKnight[0].Rectangle.X <= 820) listHollowKnight[0].Direction = 1;
                if (listHollowKnight[0].Rectangle.X >= 1220) listHollowKnight[0].Direction = -1;
                listHollowKnight[0].Rectangle = new Rectangle(listHollowKnight[0].Rectangle.X + (listHollowKnight[0].VelocityX * listHollowKnight[0].Direction), listHollowKnight[0].Rectangle.Y, listHollowKnight[0].Rectangle.Width, listHollowKnight[0].Rectangle.Height);
            }
            if (listHollowKnight[1] != null)
            {
                if (listHollowKnight[1].Rectangle.X <= 1498) listHollowKnight[1].Direction = 1;
                if (listHollowKnight[1].Rectangle.X >= 1826) listHollowKnight[1].Direction = -1;
                listHollowKnight[1].Rectangle = new Rectangle(listHollowKnight[1].Rectangle.X + (listHollowKnight[1].VelocityX * listHollowKnight[1].Direction), listHollowKnight[1].Rectangle.Y, listHollowKnight[1].Rectangle.Width, listHollowKnight[1].Rectangle.Height);
            }

        }

        public void HollowKnightLife() {

            if (Ecir.cameraMove.X >= 820 && Ecir.cameraMove.X <= 1220) index = 0;//define os indices do hollow knight  num determinado intervalo de distancia
            if (Ecir.cameraMove.X >= 1498 && Ecir.cameraMove.X <= 1826) index = 1;
            if (listHollowKnight[index] != null)
            {
                hollowKnightCol = new Rectangle(listHollowKnight[index].Rectangle.X - 60, listHollowKnight[index].Rectangle.Y - 25, 150, 75);

                if (listHollowKnight[index].Direction== -1) hollowAttackArea = new Rectangle(listHollowKnight[index].Rectangle.X - 10, listHollowKnight[index].Rectangle.Y , 30, 75);//knight ataca pela esquerda
                if (listHollowKnight[index].Direction == 1) hollowAttackArea = new Rectangle(listHollowKnight[index].Rectangle.X +60, listHollowKnight[index].Rectangle.Y , 30, 75);//knight ataca pela direita
                //Ecir ataca pela direita e esquerda
                if (hollowKnightCol.Intersects(Ecir.cameraMove) && listHollowKnight[index].Rectangle.X >= Ecir.cameraMove.X && Ecir.directionPositive == true && Ecir.EcirAttack() == 1 || hollowKnightCol.Intersects(Ecir.cameraMove) && listHollowKnight[index].Rectangle.X <= Ecir.cameraMove.X && Ecir.directionNegative == true && Ecir.EcirAttack() == 1)
                {
                    if (listHollowKnight[index].Life > 150)
                    {
                        listHollowKnight[index].Life = 150;
                        time = 0;
                    }
                    if (time >= 1 && listHollowKnight[index].Life == 150)
                    {
                        listHollowKnight[index].Life = 100;
                        time = 0;
                    }
                    if (time >= 1 && listHollowKnight[index].Life == 100)
                    {
                        listHollowKnight[index].Life = 50;
                        time = 0;

                    }
                    if (time >= 1 && listHollowKnight[index].Life == 50)
                    {
                        listHollowKnight[index].Life = 0;
                        listHollowKnight[index] = null;

                    }


                }
            }
        }
        public void HollowKnightColor() {
            if (listHollowKnight[index] != null)
            {
                if (time >= 0 && listHollowKnight[index].Life == 150 && time <= 1)
                {
                    listHollowKnight[index].Color = Color.Red;//faz aparecer a barra de vida
                    listHollowKnight[index].KnightColor = Color.Red;//cor do hollow knight
                }
                if (time >= 1 && listHollowKnight[index].Life == 150)
                {
                    listHollowKnight[index].Color = Color.Transparent;
                    listHollowKnight[index].KnightColor = Color.White;
                }
                if (time >= 0 && listHollowKnight[index].Life == 100 && time <= 1)
                {
                    listHollowKnight[index].Color = Color.Red;
                    listHollowKnight[index].KnightColor=Color.Red;
                }
                if (time >= 1 && listHollowKnight[index].Life == 100)
                {
                    listHollowKnight[index].Color = Color.Transparent;
                    listHollowKnight[index].KnightColor = Color.White;
                }
                if (time >= 0 && listHollowKnight[index].Life == 50 && time <= 1)
                {
                    listHollowKnight[index].Color = Color.Red;
                    listHollowKnight[index].KnightColor = Color.Red;
                }
                if (time >= 1 && listHollowKnight[index].Life == 50)
                {
                    listHollowKnight[index].Color = Color.Transparent;
                    listHollowKnight[index].KnightColor = Color.White;
                }
            }
        }
        public Rectangle HollowKnightDrawBarLife(int index)//barra da vida do zombie zombie
        {
            if(index==0) return new Rectangle(listHollowKnight[0].Rectangle.X + 7, listHollowKnight[0].Rectangle.Y - 10, (int)(listHollowKnight[0].Life * 0.3), 5);
            if (index == 1) return new Rectangle(listHollowKnight[1].Rectangle.X + 7, listHollowKnight[1].Rectangle.Y - 10, (int)(listHollowKnight[1].Life * 0.3), 5);

            return Rectangle;
        }
        public void UpdateTime(double deltaTime)//contador de segundos
        {
            time += deltaTime;   
        }
        public void Update() {
            HollowKnightMove();
            HollowKnightLife();
            HollowKnightColor();

        }


    }
}
