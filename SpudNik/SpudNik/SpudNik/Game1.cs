using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using BEPUphysics;
using BEPUphysics.Entities.Prefabs;

namespace SpudNik
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private Camera camera;

        static Game1 instance = null;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Groundbox ground = null;
        //private GameEnt dalek;// testing stuff

        Space space;

       
        List<GameEnt> children = new List<GameEnt>();


        public Groundbox Groundbox
        {
            get { return ground; }
            set { ground = value; }
        }

        public SpriteBatch SpriteBatch1
        {
            get { return spriteBatch; }
            set { spriteBatch = value; }
        }

        public List<GameEnt> Children
        {
            get { return children; }
            set { children = value; }
        }

        public GraphicsDeviceManager Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }

        public static Game1 Instance()
        {
            return instance;
        }

        private BasicObj basicObj;

        private BasicObj BasicObj
        {
            get { return basicObj; }
            set { basicObj = value; }
        }

        public Game1()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferMultiSampling = true;
            graphics.SynchronizeWithVerticalRetrace = true;
            graphics.ApplyChanges();
            
            
            Content.RootDirectory = "Content";
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
            camera = new Camera();

            int midX = GraphicsDeviceManager.DefaultBackBufferHeight / 2;
            int midY = GraphicsDeviceManager.DefaultBackBufferWidth / 2;
            Mouse.SetPosition(midX, midY);

            
            
            children.Add(camera);

            ground = new Groundbox();
            children.Add(ground);

            basicObj = new BasicObj();
            basicObj.modelname = "dalek";
            children.Add(basicObj);


            base.Initialize();
        }

        

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //creating simulation space with gravity inside , gravity might be removed due to game being set in space??
            space = new Space();
            space.ForceUpdater.Gravity = new Vector3(0, -9.81f, 0);
            
            Box groundBox = new Box(Vector3.Zero, ground.width, 0.1f, ground.height);
            space.Add(groundBox);

            foreach (GameEnt child in children)
            {
                child.LoadContent();
            }

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            foreach (GameEnt child in children)
            {
                child.UnloadContent();
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            MouseState mouseState = Mouse.GetState();
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }


            for (int i = 0; i < children.Count; i++)
            {
                children[i].Update(gameTime);
            }

            space.Update(timeDelta);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            foreach (GameEnt child in children)
            {
                DepthStencilState state = new DepthStencilState();
                state.DepthBufferEnable = true;
                GraphicsDevice.DepthStencilState = state;
                child.Draw(gameTime);
            }

            spriteBatch.End();   
        }

        public Camera Camera
        {
            get
            {
                return camera;
            }
            set
            {
                camera = value;
            }
        }



        public GraphicsDeviceManager GraphicsDeviceManager
        {
            get
            {
                return graphics;
            }

        }
    }
}
