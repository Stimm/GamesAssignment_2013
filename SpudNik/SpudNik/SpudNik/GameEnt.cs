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
        public Vector3 pos;
        public Vector3 velocity;
        public float mass;
        
        // for quaternion
        public Quaternion q;
        
        //Stuff for camra
        public Vector3 cRight;
        public Vector3 cUp;
        public Vector3 cLook;
        public Vector3 globalUp = new Vector3(0, 0, 1);
        public Vector3 globalDown = new Vector3(0, 0, -1);




        public void yaw;
        public void pitch;
        


        public Matrix worldTransform = new Matrix();
        public Matrix localTransform = Matrix.Identity;

        public virtual void LoadContent()
        {
            model = Game1.Instance().Content.Load<Model>(modelname);
        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(GameTime gameTime)
        {
        }

        public virtual void UnloadContent()
        {
        }

        public float getYaw()
        {

            Vector3 localLook = look;
            localLook.Y = basis.Y;
            localLook.Normalize();
            float angle = (float)Math.Acos(Vector3.Dot(basis, localLook));

            if (look.X > 0)
            {
                angle = (MathHelper.Pi * 2.0f) - angle;
            }
            return angle;

        }

        public float getPitch()
        {
            if (look.Y == basis.Y)
            {
                return 0;
            }
            Vector3 localBasis = new Vector3(look.X, 0, look.Z);
            localBasis.Normalize();
            float dot = Vector3.Dot(localBasis, look);
            float angle = (float)Math.Acos(dot);

            if (look.Y < 0)
            {
                angle = (MathHelper.Pi * 2.0f) - angle;
            }

            return angle;
        }

    }    
}
