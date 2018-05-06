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
       
        private static Rectangle staticRectangle;
        public static List<Terrain1> listTerrain = new List<Terrain1>(new Terrain1[100]);
        private Color color;
        int vel;


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
            listTerrain.Insert(1, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(0, 500, 200, 100)));
            listTerrain.Insert(2, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(-200, 500, 200, 100)));
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
            //churge
            listTerrain.Insert(23, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1900, 282, 200, 190)));
            //construction

            listTerrain.Insert(24, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2300, 340, 200, 90)));
            listTerrain.Insert(25, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2402, 300, 200, 100)));
            listTerrain.Insert(26, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2702, 300, 150, 70)));
            listTerrain.Insert(27, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2946, 300, 150, 70)));
            listTerrain.Insert(28, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3146, 300, 150, 70)));
            listTerrain.Insert(29, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3400, 55, 200, 100)));//parte de cima
            listTerrain.Insert(30, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3400, 146, 200, 60)));
            listTerrain.Insert(31, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3400, 206, 200, 60)));
            listTerrain.Insert(32, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3400, 266, 200, 60)));
            listTerrain.Insert(33, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3400, 326, 200, 60)));
            listTerrain.Insert(34, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3400, 386, 200, 60)));
            listTerrain.Insert(35, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3600, 55, 200, 100)));//parte de cima
            listTerrain.Insert(36, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3600, 146, 200, 60)));
            listTerrain.Insert(37, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3600, 206, 200, 60)));
            listTerrain.Insert(38, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3600, 266, 200, 60)));
            listTerrain.Insert(39, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3600, 326, 200, 60)));
            listTerrain.Insert(40, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3600, 386, 200, 60)));
            listTerrain.Insert(41, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3800, 55, 200, 100)));//parte de cima
            listTerrain.Insert(42, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3800, 146, 200, 60)));
            listTerrain.Insert(43, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3800, 206, 200, 60)));
            listTerrain.Insert(44, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3800, 266, 200, 60)));
            listTerrain.Insert(45, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3800, 326, 200, 60)));
            listTerrain.Insert(46, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(3800, 386, 200, 60)));
            listTerrain.Insert(47, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4000, 55, 200, 100)));//parte de cima
            listTerrain.Insert(48, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4000, 146, 200, 60)));
            listTerrain.Insert(49, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4000, 206, 200, 60)));
            listTerrain.Insert(50, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4000, 266, 200, 60)));
            listTerrain.Insert(51, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4000, 326, 200, 60)));
            listTerrain.Insert(52, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4000, 386, 200, 60)));
            listTerrain.Insert(53, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4200, 55, 200, 100)));//parte de cima
            listTerrain.Insert(54, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4200, 146, 200, 60)));
            listTerrain.Insert(55, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4200, 206, 200, 60)));
            listTerrain.Insert(56, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4200, 266, 200, 60)));
            listTerrain.Insert(57, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4200, 326, 200, 60)));
            listTerrain.Insert(58, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(4200, 386, 200, 60)));
            //reconstruçao 1º parte
            listTerrain.Insert(59, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(-400, 600, 200, 60)));
            listTerrain.Insert(60, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(-400, 540, 200, 60)));
            listTerrain.Insert(61, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(-400, 500, 200, 100)));
            listTerrain.Insert(62, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(-200, 600, 200, 60)));
            listTerrain.Insert(63, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(-100, 600, 200, 60)));
            listTerrain.Insert(64, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(0, 600, 200, 60)));
            listTerrain.Insert(65, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(600, 600, 200, 60)));
            listTerrain.Insert(66, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(800, 600, 200, 60)));
            listTerrain.Insert(67, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1000, 600, 200, 60)));
            listTerrain.Insert(68, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1200, 550, 200, 60)));
            listTerrain.Insert(69, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1400, 550, 200, 60)));
            listTerrain.Insert(70, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1600, 550, 200, 60)));
            listTerrain.Insert(71, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1800, 550, 200, 60)));
            listTerrain.Insert(72, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2000, 550, 200, 60)));
            listTerrain.Insert(73, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2200, 550, 200, 60)));
            listTerrain.Insert(74, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2300, 450, 200, 60)));//
            listTerrain.Insert(75, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2300, 390, 200, 60)));
            listTerrain.Insert(76, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2300, 510, 200, 60)));
            listTerrain.Insert(77, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2300, 550, 200, 60)));
            listTerrain.Insert(78, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2402, 390, 200, 60)));//
            listTerrain.Insert(79, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2402, 450, 200, 60)));
            listTerrain.Insert(80, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2402, 510, 200, 60)));
            listTerrain.Insert(81, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(2402, 550, 200, 60)));

            //listTerrain.Insert(68, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1200, 600, 200, 60)));
            /*listTerrain.Insert(69, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1400, 600, 200, 60)));
            listTerrain.Insert(70, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(1600, 600, 200, 60)));
            /*listTerrain.Insert(69, new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(600, 1400, 200, 60)));*/






        }
        public void Move() {//faz parte do terreno mover-se
            
            if (listTerrain[28].Rectangle.Y <= 40) vel=1;
            if ( listTerrain[28].Rectangle.Y >= 300) vel=-1;
                listTerrain[28].Rectangle = new Rectangle(listTerrain[28].Rectangle.X, listTerrain[28].Rectangle.Y + vel, listTerrain[28].Rectangle.Width, listTerrain[28].Rectangle.Height);
        }
        public void Update() {
            Move();

        }

      public  List<Terrain1> ReturnTerrain( ) {
          
            return  listTerrain;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 82; i++)
            {
                if(i!=17 && i!=16 && i != 18)
                spriteBatch.Draw(listTerrain[i].Texture, listTerrain[i].Rectangle, Color.White);
            }


            if (Ecir.cameraMove.X>=1877 && Ecir.cameraMove.Y>=282 && Ecir.cameraMove.X<=2100)
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
            listTerrain[23].Texture = Content.Load<Texture2D>("insideChurch");
            listTerrain[24].Texture = Content.Load<Texture2D>("UnderGroudTerrain");
            listTerrain[25].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[26].Texture = Content.Load<Texture2D>("floatTerrain");
            listTerrain[27].Texture = Content.Load<Texture2D>("floatTerrain");
            listTerrain[28].Texture = Content.Load<Texture2D>("floatTerrain");
            listTerrain[29].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[30].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[31].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[32].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[33].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[34].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[35].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[36].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[37].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[38].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[39].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[40].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[41].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[42].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[43].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[44].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[45].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[46].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[47].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[48].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[49].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[50].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[51].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[52].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[53].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[54].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[55].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[56].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[57].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[58].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[59].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[60].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[61].Texture = Content.Load<Texture2D>("terrain1");
            listTerrain[62].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[63].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
           listTerrain[64].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
           listTerrain[65].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[66].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[67].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[68].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[69].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[70].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[71].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[72].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[73].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[74].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[75].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[76].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[77].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[78].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[79].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[80].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[81].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
           
            //listTerrain[68].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            /*listTerrain[69].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[70].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");*/
            /*listTerrain[66].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[67].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[68].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");
            listTerrain[69].Texture = Content.Load<Texture2D>("UnderGroundTerrain2");*/








        }

    }
}
