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
    class FireBall
    {
        
        public static List<FireBall> ListFireBall = new List<FireBall>(new FireBall[100]);
        private  int count = -1;
       private Texture2D Texture2D { get; set; }
       private Rectangle Rectangle { get; set; }
       private ContentManager content;
       private  double time = 0;
        bool stopCount = true;

        public FireBall(Texture2D texture2D, Rectangle rectangle) {
            Texture2D = texture2D;
            Rectangle = rectangle; 
        }
        public FireBall() { }

        public void CreateFireBall(GraphicsDeviceManager graphics) {
            if (Keyboard.GetState().IsKeyDown(Keys.M) && time>0.7) {
                time = 0;
                count ++;
                ListFireBall.Insert(count,new FireBall(new Texture2D(graphics.GraphicsDevice, 100, 100), new Rectangle(-200, 451, 10, 10)));
                
             }
           
            if (count > -1)
                ListFireBall[count].Texture2D = content.Load<Texture2D>("fireBall");
            Console.WriteLine("ecir X=" + Ecir.cameraMove.X + "Ecir y=" + Ecir.cameraMove.Y);
        }
        public void LoadContent(ContentManager Content)
        {
            content = Content;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            //spriteBatch.Draw(this.Texture2D, this.Rectangle, Color.White);
            if (count > -1)
                for (int i = 0; i < count+1; i++)
                {
                    spriteBatch.Draw(ListFireBall[i].Texture2D, ListFireBall[i].Rectangle, Color.White);

                }
        }
        public void Move() {
            if (count > -1)
                for (int i = 0; i < count+1; i++)
                {
                    ListFireBall[i].Rectangle = new Rectangle(ListFireBall[i].Rectangle.X + 1, ListFireBall[i].Rectangle.Y, ListFireBall[i].Rectangle.Width, ListFireBall[i].Rectangle.Height);

                }
        }
        public void UpdateTime(double deltaTime) {

            time += deltaTime;
        }

        public void Update() {
        
            Move();
        }
    }
}
