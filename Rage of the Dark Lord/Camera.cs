using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rage_of_the_Dark_Lord.SpritesClass.Caracter;

namespace Rage_of_the_Dark_Lord
{
    class Camera
    {

        public int PX { get; set; }
        public int PY { get; set; }

        bool cameraAllwaysMove = false;
        public Camera(int PositionX, int PositionY) {
            this.PX = PositionX;
            this.PY = PositionY;
        }

        public Matrix GetTransform()  
        {
            Matrix translationMatrix = Matrix.CreateTranslation(new Vector3(0,0, 0));
              if(Ecir.cameraMove.X>= 3832) translationMatrix = Matrix.CreateTranslation(new Vector3(-3654, 444, 0));

            if (Ecir.cameraMove.X >= (740 / 2)- 190 &&  Ecir.cameraMove.X<=3832)
            {
                translationMatrix = Matrix.CreateTranslation(new Vector3(-1 * (Ecir.cameraMove.X)+180, -1 * (Ecir.cameraMove.Y)+ 451, 0));//camara move-se com a personagem
                //translationMatrix = Matrix.CreateTranslation(new Vector3())

                cameraAllwaysMove = true;
            }
           /* if (cameraAllwaysMove == true && Ecir.cameraMove.X <= (740 / 2) - 160) {
                translationMatrix = Matrix.CreateTranslation(new Vector3(-1 * (Ecir.cameraMove.X) + 370 - 190, -1 * (Ecir.cameraMove.Y) + 451, 0));
            }*/
            Matrix rotationMatrix = Matrix.CreateRotationZ(0);
            Matrix scaleMatrix = Matrix.CreateScale(new Vector3(1.9f, 1.9f, 0));//Zoom//1,14//1.9
            Matrix originMatrix = Matrix.CreateTranslation(new Vector3((1280/2),-390, 0));//200,0 //<-metade do viewport
            return translationMatrix*  scaleMatrix * originMatrix * rotationMatrix;
        }
        public Vector3 GetScreenScale(GraphicsDevice graphicsDevice)// resolução escala da camara
        {
            float scaleX = ((float)graphicsDevice.Viewport.Width / (float)1280);
            float scaleY = (float)graphicsDevice.Viewport.Height / (float)600;
            return new Vector3(scaleX, scaleY, 1.0f);
        }

    }
}
