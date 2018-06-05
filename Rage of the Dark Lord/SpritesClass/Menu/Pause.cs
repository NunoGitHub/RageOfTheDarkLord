using System;
using System.Collections.Generic;
using  Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Rage_of_the_Dark_Lord.SpritesClass.Caracter;

namespace Rage_of_the_Dark_Lord.SpritesClass.Menu
{
    class Pause
    {
        Texture2D resume;
        // Rectangle restart;
        MouseState previousState;
        int inside = 0;
        Point mousePoint;
        Color color = Color.White;
        int posX, posy;

        private Texture2D Texture2D;
        private Rectangle Rectangle { get; set; }
        public Pause(Rectangle rectangle)
        {

            Rectangle = rectangle;

        }
        public Pause() { }
        public void Insert(GraphicsDeviceManager graphics)
        {
            Texture2D = new Texture2D(graphics.GraphicsDevice, 1280, 600);
            resume = new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Ecir.cameraMove.X <= (740 / 2) - 190)
            {
                Rectangle pauseRectangle = new Rectangle(425, 75, 365, 50);
                spriteBatch.Draw(Texture2D, new Rectangle(-337, 205, 1080, 400), Color.White);

                if (pauseRectangle.Contains(mousePoint) && inside == 1)
                {
                    spriteBatch.Draw(resume, new Rectangle(20, 254, 365, 32), color);

                    resume.SetData(new Color[] { Color.Red * 0.5f });

                }
                if (pauseRectangle.Contains(mousePoint) && inside == 2)
                {
                    Game1.pause = false;
                }
            }
            if (Ecir.cameraMove.X > (740 / 2) - 190)
            {
                spriteBatch.Draw(Texture2D, new Rectangle(posX - 519, posy - 250, 1080, 400), Color.White);//desenhar pause menu
                Rectangle pauseRectangle = new Rectangle(posX+516 , posy+543 , 430, 45);//rectangulo ivisivel para o click
                Rectangle restarteRectangle = new Rectangle(posX + 600, posy + 728, 430, 45);
                Rectangle exitRectangle = new Rectangle(posX + 603, posy + 927, 430, 45);
                Console.WriteLine("MousePointX=" + mousePoint.X + "MousePY="+ mousePoint.Y);
                if (pauseRectangle.Contains(mousePoint) && inside == 1)
                {
                    spriteBatch.Draw(resume, new Rectangle(posX-162 , posy-200 , 365, 32), color);//rectangulo vermelho

                    resume.SetData(new Color[] { Color.Red * 0.5f });
                   
                }
                if (pauseRectangle.Contains(mousePoint) && inside == 2)
                {
                    Game1.pause = false;
                }
                if (restarteRectangle.Contains(mousePoint) && inside == 1)
                {
                    spriteBatch.Draw(resume, new Rectangle(posX - 162, posy-66, 365, 32), color);//rectangulo vermelho

                    resume.SetData(new Color[] { Color.Red * 0.5f });

                }
                if (restarteRectangle.Contains(mousePoint) && inside == 2)
                {
                    Game1.restart=true;
                    Game1.pause = false;
                }
                if (exitRectangle.Contains(mousePoint) && inside == 1)
                {
                    spriteBatch.Draw(resume, new Rectangle(posX - 162, posy+69 , 365, 32), color);//rectangulo vermelho

                    resume.SetData(new Color[] { Color.Red * 0.5f });

                }
                if (exitRectangle.Contains(mousePoint) && inside == 2)
                {
                    Game1.exit = true;
                }

            }






        }
        public void LoadContent(ContentManager Content)
        {
            Texture2D = Content.Load<Texture2D>("MenuPause");
        }
        public void Mouse1(Point p){
            mousePoint = p;



              }
      

        public void Update()
        {
           
            inside = 0;
            MouseState mouse = Mouse.GetState();

            
           
            //mousePoint = new Point(mouse.X, mouse.Y);
          //  Console.WriteLine("X=" + mouse.X + "Y=" + mouse.Y);
           // Console.WriteLine("posx" +posX);
            posX = Ecir.cameraMove.X;
            posy = Ecir.cameraMove.Y;
            if (mouse.LeftButton == ButtonState.Pressed )
            {
                inside = 1;
            }
            if (mouse.LeftButton == ButtonState.Released && previousState.LeftButton==ButtonState.Pressed)
            {
                inside = 2;
            }
            previousState = mouse;
        }
    }
}
