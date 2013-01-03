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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace SpudNik
{
    public class Camera : GameEnt
    {

        
        public Matrix projection;
        public Matrix view;


        private MouseState mouseState;
        private KeyboardState keyBoard;

        public override void LoadContent()
        {
            
        }

        public override void UnloadContent()
        {

        }

        public Camera()
        {
            pos = new Vector3(0.0f, 30.0f, 50.0f);
            cLook = new Vector3(0.0f, 0.0f, -1.0f);
        }

        public override void Update(GameTime gameTime)
        {
            float timeDelta = (float)(gameTime.ElapsedGameTime.Milliseconds / 1000.0f);

            keyBoard = Keyboard.GetState();
            mouseState = Mouse.GetState();

            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;

            int midX = GraphicsDeviceManager.DefaultBackBufferHeight / 2;
            int midY = GraphicsDeviceManager.DefaultBackBufferWidth / 2;

            int deltaX = mouseX - midX;
            int deltaY = mouseY - midY;

            yaw(-(float)deltaX / 100.0f);
            pitch(-(float)deltaY / 100.0f);
            Mouse.SetPosition(midX, midY);

            view = Matrix.CreateLookAt(pos, pos + cLook, cUp);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), Game1.Instance().GraphicsDeviceManager.GraphicsDevice.Viewport.AspectRatio, 1.0f, 10000.0f);
        }
        public Matrix getProjection()
        {
            return projection;
        }

        public Matrix getView()
        {
            return view;
        }

    }
}
