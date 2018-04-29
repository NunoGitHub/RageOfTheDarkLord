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
    class SpikesTrap
    {
        public static List<SpikesTrap> listSpikesTrap = new List<SpikesTrap>(new SpikesTrap[100]);
       
        public Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }

        public SpikesTrap(Texture2D texture, Rectangle rectangle)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;

        }
        public SpikesTrap() { }

        public void InsertSpikes(GraphicsDeviceManager graphics)
        {
           
            listSpikesTrap.Insert(0, new SpikesTrap(new Texture2D(graphics.GraphicsDevice, 100, 100), new Rectangle(680, 480, 50, 30)));
            listSpikesTrap.Insert(1, new SpikesTrap(new Texture2D(graphics.GraphicsDevice, 100, 100), new Rectangle(1445, 470, 50, 30)));
            listSpikesTrap.Insert(2, new SpikesTrap(new Texture2D(graphics.GraphicsDevice, 100, 100), new Rectangle(2300, 310, 50, 30)));
            listSpikesTrap.Insert(3, new SpikesTrap(new Texture2D(graphics.GraphicsDevice, 100, 100), new Rectangle(2350, 310, 50, 30)));
        }

        public void Draw(SpriteBatch spriteBatch) {
            for (int i = 0; i < 4; i++) {
                spriteBatch.Draw(listSpikesTrap[i].Texture, listSpikesTrap[i].Rectangle, Color.White);
            }
           
       
        }
        public void LoadContent(ContentManager Content) {
            for (int i = 0; i < 4; i++)
            {
                listSpikesTrap[i].Texture = Content.Load<Texture2D>("spikes");
            }

        }


    }
}
