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


        public Matrix worldTransform;
        public Matrix locilTransform;

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
    }    
}
