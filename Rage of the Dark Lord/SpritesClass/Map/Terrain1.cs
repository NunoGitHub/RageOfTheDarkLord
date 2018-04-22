using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace Rage_of_the_Dark_Lord.SpritesClass.Map
{
    class Terrain1
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private static Rectangle staticRectangle;
        public static List<Terrain1> listTerrain = new List<Terrain1>(new Terrain1[100]);


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
            listTerrain.Insert(13, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1900, 269, 201, 12)));
        }

      public  List<Terrain1> ReturnTerrain( ) {
          
            return  listTerrain;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(listTerrain[0].Texture, listTerrain[0].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[1].Texture, listTerrain[1].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[2].Texture, listTerrain[2].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[3].Texture, listTerrain[3].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[4].Texture, listTerrain[4].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[5].Texture, listTerrain[5].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[6].Texture, listTerrain[6].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[7].Texture, listTerrain[7].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[8].Texture, listTerrain[8].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[9].Texture, listTerrain[9].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[10].Texture, listTerrain[10].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[11].Texture, listTerrain[11].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[12].Texture, listTerrain[12].Rectangle, Color.White);
            spriteBatch.Draw(listTerrain[13].Texture, listTerrain[13].Rectangle, Color.White);
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

        }

    }
}
