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
        public FireBall(Texture2D texture2D, Rectangle rectangle) {
            Texture2D = texture2D;
            Rectangle = rectangle; 
        }
        public FireBall() { }

        public void CreateFireBall(GraphicsDeviceManager graphics) {
            if (Ecir.cameraMove.Intersects(zombieSkeleton.rectangleAttack) && time>2.5 && zombieSkeleton.listzombieSkeleton[zombieSkeleton.index]!=null) {//se o ecir entrar dentro do rectangulo de atack aciona o contador de bolas de fogo que começa a dispara-las
                time = 0;
                count ++;
                ListFireBall.Insert(count,new FireBall(new Texture2D(graphics.GraphicsDevice, 100, 100), new Rectangle(zombieSkeleton.listzombieSkeleton[zombieSkeleton.index].Rectangle.X, zombieSkeleton.listzombieSkeleton[zombieSkeleton.index].Rectangle.Y, 10, 10)));    
             }
           
            if (count > -1 && ListFireBall[count]!=null )
                ListFireBall[count].Texture2D = content.Load<Texture2D>("fireBall");
            
        }
        public void LoadContent(ContentManager Content)
        {
            content = Content;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (count > -1)
                for (int i = 0; i < count+1; i++)
                {   if(ListFireBall[i]!=null)
                    spriteBatch.Draw(ListFireBall[i].Texture2D, ListFireBall[i].Rectangle, Color.White);

                }
        }
        public void Move() {//bola de fogo persegue o ecir
            if (count > -1)
                for (int i = 0; i < count+1; i++)
                {
                    if (ListFireBall[i] != null)
                    {
                        if (Ecir.cameraMove.X + 10 > ListFireBall[i].Rectangle.X)
                            ListFireBall[i].Rectangle = new Rectangle(ListFireBall[i].Rectangle.X + 2, ListFireBall[i].Rectangle.Y, ListFireBall[i].Rectangle.Width, ListFireBall[i].Rectangle.Height);
                        if (Ecir.cameraMove.X + 10 < ListFireBall[i].Rectangle.X)
                            ListFireBall[i].Rectangle = new Rectangle(ListFireBall[i].Rectangle.X - 2, ListFireBall[i].Rectangle.Y, ListFireBall[i].Rectangle.Width, ListFireBall[i].Rectangle.Height);
                        if (Ecir.cameraMove.Y + 20 > ListFireBall[i].Rectangle.Y)
                            ListFireBall[i].Rectangle = new Rectangle(ListFireBall[i].Rectangle.X, ListFireBall[i].Rectangle.Y + 1, ListFireBall[i].Rectangle.Width, ListFireBall[i].Rectangle.Height);
                        if (Ecir.cameraMove.Y + 20 < ListFireBall[i].Rectangle.Y)
                            ListFireBall[i].Rectangle = new Rectangle(ListFireBall[i].Rectangle.X, ListFireBall[i].Rectangle.Y - 1, ListFireBall[i].Rectangle.Width, ListFireBall[i].Rectangle.Height);
                    }
                }
        }
        public void Destroy()
        {
            if (count > -1)
                for (int i = 0; i < count + 1; i++)
                {   if(ListFireBall[i]!=null)
                    if (ListFireBall[i].Rectangle.Intersects(zombieSkeleton.rectangleAttack) == false)//bola de fogo desaparece do jogo se sair do rectangleAttack
                        ListFireBall[i] = null;
                    if (ListFireBall[i] != null)
                        if (Ecir.cameraMove.Intersects(ListFireBall[i].Rectangle))//tira vida ao ecir
                        {
                        Ecir.life = Ecir.life - 20;
                        ListFireBall[i] = null;
                        }
                }
        }
        public void UpdateTime(double deltaTime) {

            time += deltaTime;
        }

        public void Update() {
        
            Move();
            Destroy();
        }
    }
}
