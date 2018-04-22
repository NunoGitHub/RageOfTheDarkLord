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

namespace Rage_of_the_Dark_Lord.SpritesClass.Map
{
    class Stairs
    {
        public static List<Stairs> listStairs = new List<Stairs>(new Stairs[5]);
       static public bool climbStairs = false;
        public static int  indexStairs=-1;
        public Rectangle Rectangle { get; set; }
        private Texture2D Texture2D { get; set; }

        public Stairs(Rectangle rectangle, Texture2D texture2D)
        {

            Rectangle = rectangle;
            Texture2D = texture2D;

        }
        public Stairs() { }
        public void InsertStairs(GraphicsDeviceManager graphics)
        {
            listStairs.Insert(0, new Stairs(new Rectangle(1842, 270, 150, 210), new Texture2D(graphics.GraphicsDevice, 100, 100)));
            listStairs.Insert(1, new Stairs(new Rectangle(1842, 176, 150, 210), new Texture2D(graphics.GraphicsDevice, 100, 100)));
          //Y=-94
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(listStairs[0].Texture2D, listStairs[0].Rectangle, Color.White);
            spriteBatch.Draw(listStairs[1].Texture2D, listStairs[1].Rectangle, Color.White);
           
        }
        public void LoadContent(ContentManager Content)
        {
            listStairs[0].Texture2D = Content.Load<Texture2D>("stairs");
            listStairs[1].Texture2D = Content.Load<Texture2D>("stairs");
           
        }
        public void ClimbStairs() {
            if (listStairs[0].Rectangle.Intersects(Ecir.cameraMove)) indexStairs = 0;
            if (listStairs[1].Rectangle.Intersects(Ecir.cameraMove)) indexStairs = 1;



            if (Ecir.cameraMove.X >= 1866 && Ecir.cameraMove.X <= 1888)
            {
                if ( Keyboard.GetState().IsKeyDown(Keys.Up) == true && Ecir.cameraMove.Intersects(listStairs[indexStairs].Rectangle) == true || Ecir.cameraMove.Intersects(listStairs[1].Rectangle) == true )
                {
                    climbStairs = true;
                }
                // else { climbStairs = false; }
                if (Ecir.cameraMove.Intersects(listStairs[0].Rectangle) == false && Ecir.cameraMove.Intersects(listStairs[1].Rectangle) == false ) { climbStairs = false; }
            }
            else {climbStairs = false;}
           /* if (Ecir.cameraMove.Intersects(listStairs[0].Rectangle) == false && Ecir.cameraMove.Intersects(listStairs[1].Rectangle) == false) climbStairs = false;*/
            Console.WriteLine("Y==" + Ecir.cameraMove.Y);
            Console.WriteLine("x==" + Ecir.cameraMove.X);
        }

        public void Update() {

            ClimbStairs();
        }

    }
}
