using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

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

        public Ogre(Rectangle rectangle, Texture2D texture, int velocityX, int direction, int life, Color color, Color ogreColor)
        {
            Rectangle = rectangle;
            Texture = texture;
            VelocityX = velocityX;
            Direction = direction;
            Life = life;
            Color = color;
            OgreColor = ogreColor;

        }
        public Ogre() { }

        public void Insert(GraphicsDeviceManager graphics)
        {
            listOgre.Insert(0, new Ogre(new Rectangle(2099, 223, 50, 50), new Texture2D(graphics.GraphicsDevice, 50, 50), 1, 1, 300, Color.Transparent, Color.White));
            OgreBarLife=new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            OgreBarLife.SetData(new Color[] { Color.Red });

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(listOgre[0].Texture, listOgre[0].Rectangle, listOgre[0].OgreColor);
            //.Draw(OgreBarLife,)

        }
        public void LoadContent(ContentManager Content)
        {

            listOgre[0].Texture = Content.Load<Texture2D>("Ogre");
           
        }

        public void Move() {
            if (listOgre[0].Rectangle.X <= 1899) listOgre[0].Direction = 1;
            if (listOgre[0].Rectangle.X >= 2270) listOgre[0].Direction = -1;
            listOgre[0].Rectangle = new Rectangle(listOgre[0].Rectangle.X + (listOgre[0].VelocityX * listOgre[0].Direction), listOgre[0].Rectangle.Y, listOgre[0].Rectangle.Width, listOgre[0].Rectangle.Height);


        }
        public void OgreLife()
        {
            if (listOgre[0].Rectangle.X >= 1899 && listOgre[0].Rectangle.X <= 2270) index = 0;
            if (listOgre[index] != null)
            {
                ogreCol = new Rectangle(listOgre[index].Rectangle.X - 60, listOgre[index].Rectangle.Y - 25, 150, 75);

                if (listOgre[index].Direction == -1) ogreAttackArea = new Rectangle(listOgre[index].Rectangle.X - 20, listOgre[index].Rectangle.Y, 30, 75);
                if (listOgre[index].Direction == 1) ogreAttackArea = new Rectangle(listOgre[index].Rectangle.X + 20, listOgre[index].Rectangle.Y, 30, 75);
            }
        }
        public void UpdateTime(double deltaTime)//contador de segundos
        {
            time += deltaTime;
        }
        public void Update() {
            Move();
            OgreLife();


        }
    }
}
