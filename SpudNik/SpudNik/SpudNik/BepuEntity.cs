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
using BEPUphysics.Entities.Prefabs;

namespace SpudNik
{
    class BepuEntity : GameEnt
    {
        public BEPUphysics.Entities.Entity body;

        public override void Update(GameTime gameTime)
        {
            worldTransform = body.WorldTransform;

        }
    }
}
