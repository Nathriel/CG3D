using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Zonnestelsel
{
	class Planet : Cube
    {
        float angle = 0;

        public Planet(Game game, Vector3 size, Vector3 pos)
            : base(game, size, pos)
        {

        }
        
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            angle += 1f;
            //rotatePlanetsAroundSun();

            base.Update(gameTime);
        }

        public void rotatePlanetsAroundSun()
        {
            Matrix rotation = Matrix.CreateRotationY(MathHelper.ToRadians(angle));

            this.world = rotation;
        }
	}
}
