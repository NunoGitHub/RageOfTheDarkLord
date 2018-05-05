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
    class Ogre
    {
        public static List<Ogre> listOgre = new List<Ogre>(new Ogre[10]);
        private Texture2D OgreBarLife;
        public static int index ;
        private double time = 0;
        public static Rectangle ogreCol, ogreAttackArea;
        private Rectangle Rectangle { get; set; }
        private Texture2D Texture { get; set; }
        public int VelocityX { get; set; }
        private int Direction { get; set; }
        private int Life { get; set; }
        private Color Color { get; set; }
        private Color OgreColor { get; set; }
        private SpriteEffects SpriteEffects { get; set; }

        public Ogre(Rectangle rectangle, Texture2D texture, int velocityX, int direction, int life, Color color, Color ogreColor, SpriteEffects spriteEffects)
        {
            Rectangle = rectangle;
            Texture = texture;
            VelocityX = velocityX;
            Direction = direction;
            Life = life;
            Color = color;
            OgreColor = ogreColor;
            SpriteEffects = SpriteEffects;

        }
        public Ogre() { }

        public void Insert(GraphicsDeviceManager graphics)
        {
            listOgre.Insert(0, new Ogre(new Rectangle(2099, 232, 50, 50), new Texture2D(graphics.GraphicsDevice, 50, 50), 1, 1, 300, Color.Transparent, Color.White, SpriteEffects.None));
            OgreBarLife=new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            OgreBarLife.SetData(new Color[] { Color.Red });

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (listOgre[0] != null)
            {
                //spriteBatch.Draw(listOgre[0].Texture, listOgre[0].Rectangle, listOgre[0].OgreColor);
                spriteBatch.Draw(listOgre[0].Texture, listOgre[0].Rectangle, null, listOgre[0].OgreColor, 0, new Vector2(listOgre[0].Rectangle.Width / 2, listOgre[0].Rectangle.Height / 2), listOgre[0].SpriteEffects, 0f);
                spriteBatch.Draw(OgreBarLife, DrawBarLife(0), listOgre[0].Color);
            }
        }        
        public void LoadContent(ContentManager Content)
        {

            listOgre[0].Texture = Content.Load<Texture2D>("Ogre");
           
        }

        public void Move() {
            if (listOgre[0] != null)
            {
                if (listOgre[0].Rectangle.X <= 1899) { listOgre[0].Direction = 1; listOgre[0].SpriteEffects = SpriteEffects.None; }
                if (listOgre[0].Rectangle.X >= 2270) { listOgre[0].Direction = -1; listOgre[0].SpriteEffects = SpriteEffects.FlipHorizontally; }
                listOgre[0].Rectangle = new Rectangle(listOgre[0].Rectangle.X + (listOgre[0].VelocityX * listOgre[0].Direction), listOgre[0].Rectangle.Y, listOgre[0].Rectangle.Width, listOgre[0].Rectangle.Height);
            }

        }
        public void OgreLife()
        {
            if (Ecir.cameraMove.X >= 1899 && Ecir.cameraMove.X >= 2270) index = 0;

            if (listOgre[index] != null)
            {
                ogreCol = new Rectangle(listOgre[index].Rectangle.X - 60, listOgre[index].Rectangle.Y - 25, 150, 75);

                if (listOgre[index].Direction == -1) ogreAttackArea = new Rectangle(listOgre[index].Rectangle.X - 20, listOgre[index].Rectangle.Y, 30, 75);
                if (listOgre[index].Direction == 1) ogreAttackArea = new Rectangle(listOgre[index].Rectangle.X + 20, listOgre[index].Rectangle.Y, 30, 75);

                if (ogreCol.Intersects(Ecir.cameraMove) && listOgre[index].Rectangle.X >= Ecir.cameraMove.X && Ecir.directionPositive == true && Ecir.EcirAttack() == 1 || ogreCol.Intersects(Ecir.cameraMove) && listOgre[index].Rectangle.X <= Ecir.cameraMove.X && Ecir.directionNegative == true && Ecir.EcirAttack() == 1)
                {
                    if (listOgre[index].Life > 250)
                    {
                        listOgre[index].Life = 250;
                        time = 0;
                    }
                    if (time >= 1 && listOgre[index].Life == 250)
                    {
                        listOgre[index].Life = 150;
                        time = 0;
                    }
                    if (time >= 1 && listOgre[index].Life == 150)
                    {
                        listOgre[index].Life = 100;
                        time = 0;

                    }
                    if (time >= 1 && listOgre[index].Life == 100)
                    {
                        listOgre[index].Life = 50;
                        time = 0;

                    }
                    if (time >= 1 && listOgre[index].Life == 50)
                    {
                        listOgre[index].Life = 0;
                        listOgre[index] = null;

                    }

                }
            }
        }

        public void OgreChangeColor()
        {
           
            if (listOgre[index] != null)
            {
                if (time >= 0 && listOgre[index].Life == 250 && time <= 1)
                {
                    listOgre[index].Color = Color.Red;//faz aparecer a barra de vida
                    listOgre[index].OgreColor = Color.Red;//cor do ogre
                }
                if (time >= 1 && listOgre[index].Life == 250)
                {
                    listOgre[index].Color = Color.Transparent;
                    listOgre[index].OgreColor = Color.White;
                }
                if (time >= 0 && listOgre[index].Life == 200 && time <= 1)
                {
                    listOgre[index].Color = Color.Red;
                    listOgre[index].OgreColor = Color.Red;
                }
                if (time >= 1 && listOgre[index].Life == 200)
                {
                    listOgre[index].Color = Color.Transparent;
                    listOgre[index].OgreColor = Color.White;
                }
                if (time >= 0 && listOgre[index].Life == 150 && time <= 1)
                {
                    listOgre[index].Color = Color.Red;
                    listOgre[index].OgreColor = Color.Red;
                }
                if (time >= 1 && listOgre[index].Life == 150)
                {
                    listOgre[index].Color = Color.Transparent;
                    listOgre[index].OgreColor = Color.White;
                }
                if (time >= 0 && listOgre[index].Life == 100 && time <= 1)
                {
                    listOgre[index].Color = Color.Red;
                    listOgre[index].OgreColor = Color.Red;
                }
                if (time >= 1 && listOgre[index].Life == 100)
                {
                    listOgre[index].Color = Color.Transparent;
                    listOgre[index].OgreColor = Color.White;
                }

                if (time >= 0 && listOgre[index].Life == 50 && time <= 1)
                 {
                     listOgre[index].Color = Color.Red;
                     listOgre[index].OgreColor = Color.Red;
                }
                if (time >= 1 && listOgre[index].Life == 50)
                 {
                     listOgre[index].Color = Color.Transparent;
                     listOgre[index].OgreColor = Color.White;
                 }
            }
            
        }
        public Rectangle DrawBarLife(int index) {
        if (index == 0) return new Rectangle(listOgre[0].Rectangle.X-3, listOgre[0].Rectangle.Y - 15, (int)(listOgre[0].Life * 0.2), 5);
        return Rectangle; 

        }
        public void UpdateTime(double deltaTime)//contador de segundos
        {
            time += deltaTime;
        }
        public void Update() {
            Move();
            OgreLife();
            OgreChangeColor();
            

        }
    }
}
