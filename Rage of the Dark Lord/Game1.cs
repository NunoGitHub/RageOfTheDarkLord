using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rage_of_the_Dark_Lord.SpritesClass.Caracter;
using Rage_of_the_Dark_Lord.SpritesClass.Map;
using System;
using System.Collections.Generic;
using Rage_of_the_Dark_Lord.SpritesClass.Enemies;
using Rage_of_the_Dark_Lord.SpritesClass.Menu;
namespace Rage_of_the_Dark_Lord
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        Pause MenuPause = new Pause(new Rectangle(-337, 205, 1080, 400));
        Ecir ecir= new Ecir();
        Zombie zombie = new Zombie();
        Stairs stairs= new Stairs();
        Ogre ogre = new Ogre();
        zombieSkeleton skeleton = new zombieSkeleton();
        FireBall fireBall = new FireBall();
        Camera camera;
        Terrain1 terrain1= new Terrain1();
        HollowKnight hollowKnight = new HollowKnight();
        SpikesTrap spikesTrap = new SpikesTrap();
        int width, height;
        Vector3 screenScale;
        Texture2D ecirBarLife, zombieBarLife;
        public static    bool pause = false, restart = false, exit=false;
        int isPaused = 0;
        KeyboardState keyState, keyStateOld;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter,GraphicsProfile.HiDef, new PresentationParameters());
            Content.RootDirectory = "Content";
            width = graphics.PreferredBackBufferWidth = 1280;
            height = graphics.PreferredBackBufferHeight = 600;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60d);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            MenuPause.Insert(graphics);
            spikesTrap.InsertSpikes(graphics);
            ecir = new Ecir(new Texture2D(graphics.GraphicsDevice, 50, 50), new Rectangle(-200, 400, 30, 50),new Vector2(1,1), new Vector2(1, 1));
            zombie = new Zombie(new Texture2D(graphics.GraphicsDevice, 50, 50), new Rectangle(400, 490, 30, 50), 1, 1,SpriteEffects.None);
            terrain1.InsertTerrain(graphics);
            skeleton.Insert(graphics); 
            hollowKnight.InsertHollowKnight(graphics);
            stairs.InsertStairs(graphics);
            ogre.Insert(graphics);
           
            camera = new Camera(ecir.Rectangle.X, ecir.Rectangle.Y);
            //terrain1 = new Terrain1(new Texture2D(graphics.GraphicsDevice, 400, 400), new Rectangle(0, height - 100, 200, 100));
            base.Initialize();  
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            MenuPause.LoadContent(this.Content);
            spikesTrap.LoadContent(this.Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ecir.Texture = Content.Load<Texture2D>("Ecir");
            zombie.Texture = Content.Load<Texture2D>("Zombie");
            ecirBarLife = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);//Ecir bar life
            ecirBarLife.SetData(new Color[] { Color.Red });
            zombieBarLife = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            zombieBarLife.SetData(new Color[] { Color.Red });
            terrain1.LoadContent(this.Content);
            skeleton.LoadContent(this.Content);
            hollowKnight.LoadContent(this.Content);
            stairs.LoadContent(this.Content);
            ogre.LoadContent(this.Content);
            fireBall.LoadContent(this.Content);
 
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
           
            
            MouseState mouse = Mouse.GetState();
            //Mouse.WindowHandle = Window.Handle;
            Vector2 clickCoord = new Vector2(mouse.X, mouse.Y) + new Vector2((Ecir.cameraMove.X) + 180, (Ecir.cameraMove.Y) + 451);
            Matrix screenScale = camera.GetTransform();
            Point mousePoint = new Point((int)clickCoord.X, (int)clickCoord.Y);
            //Vector2 mousePos = new Vector2(mouse.X, mouse.Y);
           // Vector2 worldPosition = Vector2.Transform(mousePos, Matrix.Invert(screenScale));
           // Console.WriteLine("mouseX=" + worldPosition.X + "mouseY=" + worldPosition.Y);
            
            MenuPause.Mouse1(mousePoint);
           // Console.WriteLine("mouseX=" + clickCoord.X + "mouseY=" + clickCoord.Y);


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(exit) Exit();
            if (pause)
                this.IsMouseVisible = true;
            else {
                this.IsMouseVisible = false;
            }
           
            MenuPause.Update();
            
           
            keyState = Keyboard.GetState();
            if (pause == false)
            {

                if (!ecir.EcirDestroy())
                {
                    ecir.EcirMove(2, 2);
                    ecir.TerrainColisions();
                    ecir.EcirLife();
                }
                hollowKnight.Update();
                ecir.UpdateTime(gameTime.ElapsedGameTime.TotalSeconds);
                stairs.Update();
                ogre.Update();
                ogre.UpdateTime(gameTime.ElapsedGameTime.TotalSeconds);
                terrain1.Update();
                skeleton.Update();
                skeleton.UpdateTime(gameTime.ElapsedGameTime.TotalSeconds, gameTime.ElapsedGameTime.Milliseconds);
                fireBall.Update();
                fireBall.CreateFireBall(graphics);
                fireBall.UpdateTime(gameTime.ElapsedGameTime.TotalSeconds);

                if (zombie != null)
                {
                    zombie.UpdateTimer(gameTime.ElapsedGameTime.TotalSeconds);
                    zombie.ZombieChageDirection();
                    zombie.ZombieMove();
                    zombie.ZombieLife();
                    zombie.ZombieColor();
                
                }
                hollowKnight.UpdateTime(gameTime.ElapsedGameTime.TotalSeconds);
                Console.WriteLine("Pause==" + pause);
                base.Update(gameTime);
           }
           
            if (keyState.IsKeyDown(Keys.P) && !keyStateOld.IsKeyDown(Keys.P))
            {
                  pause = !pause;//->pausar o jogo
            }
            keyStateOld = keyState;
            if (restart == true) {
                this.Initialize();//->reiniciar o jogo
                this.LoadContent();
                Zombie.zombieLife = 100;
                Ecir.life = 100;
                Ecir.color = Color.White;
                this.Draw( gameTime);

            }
            restart = false;
           
  
            
        }
      /*  public void ChangeGameState(GameState state)
        {

        
        }
        public enum GameState { START, PLAY, END }*/

                /// <summary>
                /// This is called when the game should draw itself.
                /// </summary>
                /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            Matrix camera1 = camera.GetTransform();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            screenScale = camera.GetScreenScale(graphicsDevice);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, camera1 *Matrix.CreateScale(screenScale));
           
            spikesTrap.Draw(spriteBatch);
            spriteBatch.Draw(ecirBarLife, ecir.BarLifeEcir(), Color.Red);
            if(zombie!=null)spriteBatch.Draw(zombieBarLife,zombie.ZombieBarLife(), zombie.ColorBar());//se o zombie não for destruido desanha a bar life
            terrain1.Draw(spriteBatch);
            spikesTrap.Draw(spriteBatch);
            hollowKnight.Draw(spriteBatch);
            stairs.Draw(spriteBatch);
            ogre.Draw(spriteBatch);
           if (!ecir.EcirDestroy()) spriteBatch.Draw(ecir.Texture, ecir.Rectangle, ecir.EcirColor());
            //  if(zombie!=null)if (!zombie.DestroyZombie()) spriteBatch.Draw(zombie.Texture, zombie.Rectangle, zombie.ZombieColor()); else { zombie = null; }// se o zombie não for destruido e levar dano muda de cor quando a vida chagar a 0 é destruido
            if (zombie != null) if (!zombie.DestroyZombie()) spriteBatch.Draw(zombie.Texture, zombie.Rectangle, null, zombie.ZombieColor(), 0, new Vector2(zombie.Rectangle.Width / 2, zombie.Rectangle.Height / 2),zombie.SpriteEffect, 0f);
            skeleton.Draw(spriteBatch);
            fireBall.Draw(spriteBatch);
          if(pause==true)  MenuPause.Draw(spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
