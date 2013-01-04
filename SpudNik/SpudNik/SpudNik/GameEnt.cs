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
    public abstract class GameEnt
    {
        // Stuf for models 
        public String modelname;
        public Model model = null;
        
        //stuff foir physx
        public Vector3 pos  = Vector3.Zero;
        public Vector3 velocity = Vector3.Zero;
        public Vector3 force = Vector3.Zero;
        public float mass = 1.0f;
        public float scale;
       
        
        // for quaternion
        public Quaternion q;
        
        //Stuff for camra
        public Vector3 cRight = new Vector3(1.0f, 0.0f, 0.0f);
        public Vector3 cUp = new Vector3(0.0f, 1.0f, 0.0f);
        public Vector3 cLook = new Vector3(0, 0, -1);
        public Vector3 globalUp = new Vector3(0, 0, 1);
        public Vector3 globalDown = new Vector3(0, 0, -1);

        public Matrix worldTransform = new Matrix();
        public Matrix localTransform = Matrix.Identity;

        public float Mass
        {
            get { return mass; }
            set { mass = value; } 
        }

        public virtual void LoadContent()
        {
            model = Game1.Instance().Content.Load<Model>(modelname);
        }


        public abstract void Update(GameTime gameTime);

        public virtual void Draw(GameTime gameTime)
        {
            if (model != null)
            {
                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();
                        effect.PreferPerPixelLighting = true;
                        effect.World = localTransform * worldTransform;
                        effect.Projection = Game1.Instance().Camera.getProjection();
                        effect.View = Game1.Instance().Camera.getView();
                    }
                    mesh.Draw();
                }
            }
        }

        public virtual void UnloadContent()
        {
        }

        public void yaw(float angle)
        {
            Matrix T = Matrix.CreateRotationY(angle);
            cRight = Vector3.Transform(cRight, T);
            cLook = Vector3.Transform(cLook, T);
        }

        public void pitch(float angle)
        {
            Matrix T = Matrix.CreateFromAxisAngle(cRight, angle);
            cLook = Vector3.Transform(cLook, T);
        }

        public float getYaw()
        {

            Vector3 localLook = cLook;
            localLook.Y = globalDown.Y;
            localLook.Normalize();
            float angle = (float)Math.Acos(Vector3.Dot(globalDown, localLook));

            if (cLook.X > 0)
            {
                angle = (MathHelper.Pi * 2.0f) - angle;
            }
            return angle;

        }

        public float getPitch()
        {
            if (cLook.Y == globalDown.Y)
            {
                return 0;
            }
            Vector3 localBasis = new Vector3(cLook.X, 0, cLook.Z);
            localBasis.Normalize();
            float dot = Vector3.Dot(localBasis, cLook);
            float angle = (float)Math.Acos(dot);

            if (cLook.Y < 0)
            {
                angle = (MathHelper.Pi * 2.0f) - angle;
            }

            return angle;
        }

        public void walk(float amount)
        {
            pos += cLook * amount;
        }

        public void strafe(float amount)
        {

            pos += cRight * amount;

        }
    }    
}
