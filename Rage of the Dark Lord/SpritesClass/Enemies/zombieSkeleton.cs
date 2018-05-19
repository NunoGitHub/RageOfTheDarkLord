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
    class zombieSkeleton
    {
        public static List<zombieSkeleton> listzombieSkeleton = new List<zombieSkeleton>(new zombieSkeleton[10]);
        private Texture2D zombieSkeletonBarLife;
        public static int index;
        public static Rectangle colzombieSkeleton,SkeletonAttackArea;
        private double time = 0;
        public double ms = 0;
        double rot = 0;
        
        public Rectangle Rectangle { get; set; }
        private Texture2D Texture2D { get; set; }
        private int VelocityX { get; set; }
        private int VelocityY { get; set; }
        private int Direction { get; set; }
        private int Life { get; set; }
        private Color BarColor { get; set; }
        private Color SkeletonColor { get; set; }
        private SpriteEffects SpriteEffects { get; set; }

        public zombieSkeleton(Rectangle rectangle, Texture2D texture, int velocityX, int velocityY, int direction, int life, Color barColor, Color skeletonColor, SpriteEffects spriteEffects)
        {
            Rectangle = rectangle;
            Texture2D = texture;
            VelocityX = velocityX;
            VelocityY = velocityY;
            Direction = direction;
            Life = life;
            BarColor = barColor;
            SkeletonColor = skeletonColor;
            SpriteEffects = spriteEffects;
            

        }
        public zombieSkeleton() { }
        public void Insert(GraphicsDeviceManager graphics)
        {
            // listzombieSkeleton.Insert(0, new zombieSkeleton(new Rectangle(3900, 10, 50, 50), new Texture2D(graphics.GraphicsDevice, 50, 50), 1, 0, 1, 100, Color.Transparent, Color.White, SpriteEffects.None));
            listzombieSkeleton.Insert(0, new zombieSkeleton(new Rectangle(-100, 420, 50, 30), new Texture2D(graphics.GraphicsDevice, 50, 50), 1, 0, 1, 100, Color.Transparent, Color.White, SpriteEffects.None));
            zombieSkeletonBarLife = new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            zombieSkeletonBarLife.SetData(new Color[] { Color.Red });

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 1; i++)
            {
                if (listzombieSkeleton[i] != null)
                {
                    spriteBatch.Draw(listzombieSkeleton[i].Texture2D, listzombieSkeleton[i].Rectangle, null, listzombieSkeleton[i].SkeletonColor, 0, new Vector2(listzombieSkeleton[i].Rectangle.Width / 2, listzombieSkeleton[i].Rectangle.Height / 2), listzombieSkeleton[i].SpriteEffects, 0f);
                    spriteBatch.Draw(zombieSkeletonBarLife, DrawBarLife(i), listzombieSkeleton[i].BarColor);
                }

            }
        }
        public void LoadContent(ContentManager Content)
        {
            for (int i = 0; i < 1; i++)
            {
                listzombieSkeleton[i].Texture2D = Content.Load<Texture2D>("ZombieSkeleton");
            }

        }
        public void Move()
        {
            double angle = Math.PI * 6 / 180.0;
            rot += Math.Sin(angle);
            if (rot > 3)
            {
              rot = rot * -1;
            }if(rot<=-3 && listzombieSkeleton[0]!=null) listzombieSkeleton[0].Rectangle = new Rectangle(listzombieSkeleton[0].Rectangle.X + (listzombieSkeleton[0].VelocityX * listzombieSkeleton[0].Direction), 451, listzombieSkeleton[0].Rectangle.Width, listzombieSkeleton[0].Rectangle.Height);
           
            if (listzombieSkeleton[0] != null)  
            {
 
                if (listzombieSkeleton[0].Rectangle.X <= -100) { listzombieSkeleton[0].Direction = 1; listzombieSkeleton[0].SpriteEffects = SpriteEffects.None; }
                if (listzombieSkeleton[0].Rectangle.X >= 100) { listzombieSkeleton[0].Direction = -1; listzombieSkeleton[0].SpriteEffects = SpriteEffects.FlipHorizontally; }
                listzombieSkeleton[0].Rectangle = new Rectangle(listzombieSkeleton[0].Rectangle.X + (listzombieSkeleton[0].VelocityX * listzombieSkeleton[0].Direction), listzombieSkeleton[0].Rectangle.Y+ (int)rot , listzombieSkeleton[0].Rectangle.Width, listzombieSkeleton[0].Rectangle.Height);
               
            }
          
        }
        public void Attack() {



        }
        public void SkeletonLife()
        {
            if (Ecir.cameraMove.X >= -50 && Ecir.cameraMove.X <= 100) index = 0;
            

            if (listzombieSkeleton[index] != null)
            {
                colzombieSkeleton = new Rectangle(listzombieSkeleton[index].Rectangle.X - 60, listzombieSkeleton[index].Rectangle.Y - 25, 150, 75);

                if (listzombieSkeleton[index].Direction == -1) colzombieSkeleton = new Rectangle(listzombieSkeleton[index].Rectangle.X - 20, listzombieSkeleton[index].Rectangle.Y, 30, 75);
                if (listzombieSkeleton[index].Direction == 1) SkeletonAttackArea = new Rectangle(listzombieSkeleton[index].Rectangle.X + 20, listzombieSkeleton[index].Rectangle.Y, 30, 75);

                if (colzombieSkeleton.Intersects(Ecir.cameraMove) && listzombieSkeleton[index].Rectangle.X >= Ecir.cameraMove.X && Ecir.directionPositive == true && Ecir.EcirAttack() == 1 || colzombieSkeleton.Intersects(Ecir.cameraMove) && listzombieSkeleton[index].Rectangle.X <= Ecir.cameraMove.X && Ecir.directionNegative == true && Ecir.EcirAttack() == 1)
                {
                    if (listzombieSkeleton[index].Life > 90)
                    {
                        listzombieSkeleton[index].Life = 50;
                        time = 0;
                    }
                    if (time >= 1 && listzombieSkeleton[index].Life == 50)
                    {
                        listzombieSkeleton[index].Life = 0;
                        listzombieSkeleton[index] = null;
                    }

                }
            }
        }
        public void SkeletonChangeColor()
        {
           
            if (listzombieSkeleton[index] != null)
            {
                if (time >= 0 && listzombieSkeleton[index].Life == 50 && time <= 1)
                {
                    listzombieSkeleton[index].BarColor = Color.Red;//faz aparecer a barra de vida
                    listzombieSkeleton[index].SkeletonColor = Color.Red;//cor do Skeleton
                }
                if (time >= 1 && listzombieSkeleton[index].Life == 50)
                {
                    listzombieSkeleton[index].BarColor = Color.Transparent;
                    listzombieSkeleton[index].SkeletonColor = Color.White;
                }
               
            }
            
        }
        public Rectangle DrawBarLife(int index)
        {

            if (index == 0) return new Rectangle(listzombieSkeleton[0].Rectangle.X - 3, listzombieSkeleton[0].Rectangle.Y - 15, (int)(listzombieSkeleton[0].Life * 0.2), 5);
          
            return Rectangle;

        }
        public void UpdateTime(double deltaTime, double totalms)//contador de segundos
        {
            time += deltaTime;
            ms += totalms;
        }
        public void Update()
        {
            Move();
            SkeletonLife();
            SkeletonChangeColor();

        }
    }
}
