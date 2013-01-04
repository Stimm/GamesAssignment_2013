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
    class BasicObj:GameEnt
    {

        public override void Update(GameTime gameTime)
        {
        }


        public BasicObj()
        {
            cRight = new Vector3(1.0f, 0.0f, 0.0f);
            cUp = new Vector3(0.0f, 1.0f, 0.0f);
            cLook = new Vector3(0, 0, -1);
            globalUp = new Vector3(0, 0, 1);
            globalDown = new Vector3(0, 0, -1);
        }
    }
}
