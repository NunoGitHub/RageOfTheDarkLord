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

        public static List<HollowKnight> listHollowKnight = new List<HollowKnight>(new HollowKnight[10]);
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
        public SpriteEffects SpriteEffects { get; set; }
        
        public HollowKnight(Rectangle rect, Texture2D texture, int velocityX, int direction, int life, Color color, Color knightColor, SpriteEffects spriteEffects) {
            Rectangle = rect;
            Texture = texture;
            VelocityX = velocityX;
            Direction = direction;
            Life = life;
            Color= color;
            KnightColor = knightColor;
            SpriteEffects = SpriteEffects;

        }

        public HollowKnight() { }

        public void InsertHollowKnight(GraphicsDeviceManager graphics) {

            listHollowKnight.Insert(0, new HollowKnight(new Rectangle(840, 405, 65, 65), new Texture2D(graphics.GraphicsDevice, 50, 50),2,1,200,Color.Transparent,Color.White, SpriteEffects.FlipHorizontally));
            HollowKnightBarLife = new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            HollowKnightBarLife.SetData(new Color[] { Color.Red });
            listHollowKnight.Insert(1, new HollowKnight(new Rectangle(1498, 405, 65, 65), new Texture2D(graphics.GraphicsDevice, 50, 50), 2, 1, 200,Color.Transparent,Color.White, SpriteEffects.FlipHorizontally));
            listHollowKnight.Insert(2, new HollowKnight(new Rectangle(2396, 251, 65, 65), new Texture2D(graphics.GraphicsDevice, 50, 50), 2, 1, 200, Color.Transparent, Color.White, SpriteEffects.FlipHorizontally));
            listHollowKnight.Insert(3, new HollowKnight(new Rectangle(3755, 5, 65, 65), new Texture2D(graphics.GraphicsDevice, 50, 50), 2, 1, 200, Color.Transparent, Color.White, SpriteEffects.FlipHorizontally));

        }
        public void Draw(SpriteBatch spriteBatch) { 

            for(int i=0; i<4; i++)
            {
                if (listHollowKnight[i] != null)
                {
                    spriteBatch.Draw(listHollowKnight[i].Texture, listHollowKnight[i].Rectangle, null, listHollowKnight[i].KnightColor, 0, new Vector2(listHollowKnight[i].Rectangle.Width / 2, listHollowKnight[i].Rectangle.Height / 2), listHollowKnight[i].SpriteEffects, 0f);
                    spriteBatch.Draw(HollowKnightBarLife, HollowKnightDrawBarLife(i), listHollowKnight[i].Color);
                }
            }
          
        }
        public void LoadContent(ContentManager Content) {
            for(int i=0; i < 4; i++)
            {
                listHollowKnight[i].Texture = Content.Load<Texture2D>("HollowKnight");
     
            }

        }

        public void HollowKnightMove()//Movimento do hollow knight
        {
            //Primeiro hollow knight
            if (listHollowKnight[0] != null)
            {
                if (listHollowKnight[0].Rectangle.X <= 820) { listHollowKnight[0].Direction = 1; listHollowKnight[0].SpriteEffects= SpriteEffects.FlipHorizontally;}
                if (listHollowKnight[0].Rectangle.X >= 1220) { listHollowKnight[0].Direction = -1; listHollowKnight[0].SpriteEffects = SpriteEffects.None; }
                listHollowKnight[0].Rectangle = new Rectangle(listHollowKnight[0].Rectangle.X + (listHollowKnight[0].VelocityX * listHollowKnight[0].Direction), listHollowKnight[0].Rectangle.Y, listHollowKnight[0].Rectangle.Width, listHollowKnight[0].Rectangle.Height);
            }
            if (listHollowKnight[1] != null)
            {
                if (listHollowKnight[1].Rectangle.X <= 1498) { listHollowKnight[1].Direction = 1; listHollowKnight[1].SpriteEffects = SpriteEffects.FlipHorizontally; }
                if (listHollowKnight[1].Rectangle.X >= 1826) { listHollowKnight[1].Direction = -1; listHollowKnight[1].SpriteEffects = SpriteEffects.None; }
                listHollowKnight[1].Rectangle = new Rectangle(listHollowKnight[1].Rectangle.X + (listHollowKnight[1].VelocityX * listHollowKnight[1].Direction), listHollowKnight[1].Rectangle.Y, listHollowKnight[1].Rectangle.Width, listHollowKnight[1].Rectangle.Height);
            }
            if (listHollowKnight[2] != null)
            {
                if (listHollowKnight[2].Rectangle.X <= 2396) { listHollowKnight[2].Direction = 1; listHollowKnight[2].SpriteEffects = SpriteEffects.FlipHorizontally; }
                if (listHollowKnight[2].Rectangle.X >= 2565) { listHollowKnight[2].Direction = -1; listHollowKnight[2].SpriteEffects = SpriteEffects.None; }
                listHollowKnight[2].Rectangle = new Rectangle(listHollowKnight[2].Rectangle.X + (listHollowKnight[2].VelocityX * listHollowKnight[2].Direction), listHollowKnight[2].Rectangle.Y, listHollowKnight[2].Rectangle.Width, listHollowKnight[2].Rectangle.Height);
            }
            if (listHollowKnight[3] != null)
            {
                if (listHollowKnight[3].Rectangle.X <= 3400) { listHollowKnight[3].Direction = 1; listHollowKnight[3].SpriteEffects = SpriteEffects.FlipHorizontally; }
                if (listHollowKnight[3].Rectangle.X >= 3755) { listHollowKnight[3].Direction = -1; listHollowKnight[3].SpriteEffects = SpriteEffects.None; }
                listHollowKnight[3].Rectangle = new Rectangle(listHollowKnight[3].Rectangle.X + (listHollowKnight[3].VelocityX * listHollowKnight[3].Direction), listHollowKnight[3].Rectangle.Y, listHollowKnight[3].Rectangle.Width, listHollowKnight[3].Rectangle.Height);
            }

        }

        public void HollowKnightLife() {

            if (Ecir.cameraMove.X >= 820 && Ecir.cameraMove.X <= 1228) index = 0;//define os indices do hollow knight  num determinado intervalo de distancia
            if (Ecir.cameraMove.X >= 1498 && Ecir.cameraMove.X <= 1826) index = 1;
            if (Ecir.cameraMove.X >= 2396 && Ecir.cameraMove.X <= 2565) index = 2;
            if (Ecir.cameraMove.X >= 3400 && Ecir.cameraMove.X <= 3755) index = 3;
            if (listHollowKnight[index] != null)
            {
                hollowKnightCol = new Rectangle(listHollowKnight[index].Rectangle.X - 60, listHollowKnight[index].Rectangle.Y - 25, 150, 75);//area de colisão de ataque do ecir

                if (listHollowKnight[index].Direction== -1) hollowAttackArea = new Rectangle(listHollowKnight[index].Rectangle.X - 10, listHollowKnight[index].Rectangle.Y , 30, 75);//knight ataca pela esquerda
                if (listHollowKnight[index].Direction == 1) hollowAttackArea = new Rectangle(listHollowKnight[index].Rectangle.X +40, listHollowKnight[index].Rectangle.Y , 30, 75);//knight ataca pela direita
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
                if (time >= 0.5 && listHollowKnight[index].Life == 150)
                {
                    listHollowKnight[index].Color = Color.Transparent;
                    listHollowKnight[index].KnightColor = Color.White;
                }
                if (time >= 0.5 && listHollowKnight[index].Life == 100 && time <= 1)
                {
                    listHollowKnight[index].Color = Color.Red;
                    listHollowKnight[index].KnightColor=Color.Red;
                }
                if (time >= 0.5 && listHollowKnight[index].Life == 100)
                {
                    listHollowKnight[index].Color = Color.Transparent;
                    listHollowKnight[index].KnightColor = Color.White;
                }
                if (time >= 0 && listHollowKnight[index].Life == 50 && time <= 1)
                {
                    listHollowKnight[index].Color = Color.Red;
                    listHollowKnight[index].KnightColor = Color.Red;
                }
                if (time >= 0.5 && listHollowKnight[index].Life == 50)
                {
                    listHollowKnight[index].Color = Color.Transparent;
                    listHollowKnight[index].KnightColor = Color.White;
                }
            }
        }
        public Rectangle HollowKnightDrawBarLife(int index)//barra da vida do hollowknight
        {
            if(index==0) return new Rectangle(listHollowKnight[0].Rectangle.X + 7, listHollowKnight[0].Rectangle.Y - 10, (int)(listHollowKnight[0].Life * 0.3), 5);
            if (index == 1) return new Rectangle(listHollowKnight[1].Rectangle.X + 7, listHollowKnight[1].Rectangle.Y - 10, (int)(listHollowKnight[1].Life * 0.3), 5);
            if (index == 2) return new Rectangle(listHollowKnight[2].Rectangle.X + 7, listHollowKnight[2].Rectangle.Y - 10, (int)(listHollowKnight[2].Life * 0.3), 5);
            if (index == 3) return new Rectangle(listHollowKnight[3].Rectangle.X + 7, listHollowKnight[3].Rectangle.Y - 10, (int)(listHollowKnight[3].Life * 0.3), 5);

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
