using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpudNik
{
    public class Groundbox : GameEnt
    {
        GraphicsDeviceManager graphics;
        VertexPositionTexture[] vertices;
        BasicEffect basicEffect;

        public float width = 500;
        public float height = 500;

        public override void UnloadContent()
        {

        }

        public Groundbox()
        {
            graphics = Game1.Instance().GraphicsDeviceManager;

        }

        public override void LoadContent()
        {

            float twidth = 10;
            float theight = 10;

            vertices = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-width, 0, height), new Vector2(0, theight)),
                new VertexPositionTexture(new Vector3(-width, 0, -height), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3(width, 0, height), new Vector2(twidth, theight)),

                new VertexPositionTexture(new Vector3(width, 0, height), new Vector2(twidth, theight)),
                new VertexPositionTexture(new Vector3(-width, 0, -height), new Vector2(0, 0)),
                
                new VertexPositionTexture(new Vector3(width, 0, -height), new Vector2(twidth, 0))
            };

            Texture2D portrait = Game1.Instance().Content.Load<Texture2D>("Ground");
            float aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

            basicEffect = new BasicEffect(graphics.GraphicsDevice);
            basicEffect.TextureEnabled = true;
            basicEffect.Texture = portrait;
            
            
        }

        public override void Update(GameTime gameTime)
        {

            basicEffect.World = Matrix.Identity;
            basicEffect.Projection = Game1.Instance().Camera.projection;
            basicEffect.View = Game1.Instance().Camera.view;

           
        }

        public override void Draw(GameTime gameTime)
        {

            basicEffect.FogColor = Color.Black.ToVector3();
            basicEffect.FogEnabled = true;
            basicEffect.FogStart = 100.0f;
            basicEffect.FogEnd = 150.0f;

            EffectPass effectPass = basicEffect.CurrentTechnique.Passes[0];
            effectPass.Apply();
            SamplerState state = new SamplerState();
            state.AddressU = TextureAddressMode.Wrap;
            state.AddressV = TextureAddressMode.Wrap;
            state.AddressW = TextureAddressMode.Wrap;
            state.Filter = TextureFilter.Anisotropic;
            graphics.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
            graphics.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, vertices, 0, 2);
        }
    }
}
