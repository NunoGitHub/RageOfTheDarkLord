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
    class Terrain1
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private static Rectangle staticRectangle;
        public static List<Terrain1> listTerrain = new List<Terrain1>(new Terrain1[100]);
        private Color color;


        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }

        public Terrain1(Texture2D texture, Rectangle rec)
        {
            this.Rectangle = rec;
            this.Texture = texture;
            staticRectangle = rec;
        }
     

        public Rectangle Terrain1Y()
        {

            return staticRectangle;
        }
        public Terrain1() { }
     

       public void InsertTerrain(GraphicsDeviceManager graphics)
        {
            listTerrain.Insert(0, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(200, 530, 200, 100)));
            listTerrain.Insert(1, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(0, 600 - 100, 200, 100)));
            listTerrain.Insert(2, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(-200, 600-100, 200, 100)));
            listTerrain.Insert(3, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(400, 530, 200, 100)));
            listTerrain.Insert(4, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(600, 500, 200, 100)));
            listTerrain.Insert(5, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(800, 500, 200, 100)));
            listTerrain.Insert(6, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1000, 500, 200, 100)));
            listTerrain.Insert(7, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(840, 455, 200, 100)));
            listTerrain.Insert(8, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1040, 455, 200, 100)));
            listTerrain.Insert(9, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1240, 455, 200, 100)));
            listTerrain.Insert(10, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1440, 500, 200, 100)));
            listTerrain.Insert(11, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1500, 455, 200, 100)));
            listTerrain.Insert(12, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1700, 455, 200, 100)));
            listTerrain.Insert(13, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1899, 269, 201, 13)));
            listTerrain.Insert(14, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2099, 269, 201, 13)));
            listTerrain.Insert(15, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1900, 455, 200, 100)));// listTerrain.Insert(15, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1900, 465, 200, 90)));
            //hide Terrain
            listTerrain.Insert(16, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1900, 390, 200, 90)));
            listTerrain.Insert(17, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1900, 320, 200, 90)));
            listTerrain.Insert(18, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1900, 278, 200, 90)));



            listTerrain.Insert(19, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2100, 455, 200, 100)));
            listTerrain.Insert(20, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2100, 390, 200, 90)));
            listTerrain.Insert(21, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2100, 320, 200, 90)));
            listTerrain.Insert(22, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2100, 278, 200, 90)));



        }

      public  List<Terrain1> ReturnTerrain( ) {
          
            return  listTerrain;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 23; i++)
            {
                if(i!=17 && i!=16 && i != 18)
                spriteBatch.Draw(listTerrain[i].Texture, listTerrain[i].Rectangle, Color.White);
            }


            if (/*Ecir.cameraMove.Intersects(listTerrain[15].Rectangle) ||*/ Ecir.cameraMove.X>=1877 && Ecir.cameraMove.Y>=282 && Ecir.cameraMove.X<=2100)
            {
                color = Color.Transparent;
            }
            else {
               color= Color.White;
            }
            spriteBatch.Draw(listTerrain[16].Texture, listTerrain[16].Rectangle, color);
            spriteBatch.Draw(listTerrain[17].Texture, listTerrain[17].Rectangle, color);
            spriteBatch.Draw(listTerrain[18].Texture, listTerrain[18].Rectangle, color);
            Console.WriteLine("Y==" + Ecir.cameraMove.Y);
            
        }

        public void LoadContent(ContentManager Content)
        {
            listTerrain[0].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[1].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[2].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[3].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[4].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[5].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[6].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[7].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[8].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[9].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[10].Texture = Content.Load<Texture2D>("UnderGroudTerrain");
            listTerrain[11].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[12].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[13].Texture = Content.Load<Texture2D>("topTerrain");
            listTerrain[14].Texture = Content.Load<Texture2D>("topTerrain");
            listTerrain[15].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[16].Texture = Content.Load<Texture2D>("UnderGroudTerrain");
            listTerrain[17].Texture = Content.Load<Texture2D>("UnderGroudTerrain");
            listTerrain[18].Texture = Content.Load<Texture2D>("UnderGroudTerrain");
            listTerrain[19].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[20].Texture = Content.Load<Texture2D>("UnderGroudTerrain");
            listTerrain[21].Texture = Content.Load<Texture2D>("UnderGroudTerrain");
            listTerrain[22].Texture = Content.Load<Texture2D>("UnderGroudTerrain");

        }

    }
}
