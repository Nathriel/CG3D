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


namespace WindowsGame3
{
    public class _3D_axis : DrawableGameComponent
    {
        private VertexPositionColor[] vertices;
		private BasicEffect effect;

		public BasicEffect Effect
		{
			get { return effect; }
			set { effect = value; }
		}
		private bool enabled;


        public _3D_axis(Game game)
            : base(game)
        {
            vertices = new VertexPositionColor[6];
            vertices[0] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Red);
            vertices[1] = new VertexPositionColor(new Vector3(3, 0, 0), Color.Red);
            vertices[2] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Green);
            vertices[3] = new VertexPositionColor(new Vector3(0, 3, 0), Color.Green);
            vertices[4] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Blue);
            vertices[5] = new VertexPositionColor(new Vector3(0, 0, 3), Color.Blue);
			
			enabled = true;
        }

        public override void Initialize()
        {
            base.Initialize();
            effect = new BasicEffect(GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

		public void switchEnabled()
		{
			enabled = !enabled;
		}

        public override void Draw(GameTime gameTime)
        {
            effect.World = Matrix.Identity;
            effect.View = ((Game1)this.Game).camera.view;
            effect.Projection = ((Game1)this.Game).camera.projection;
            effect.VertexColorEnabled = true;

			if (enabled)
			{
				foreach (EffectPass pass in effect.CurrentTechnique.Passes)
				{
					pass.Apply();
					GraphicsDevice.DrawUserPrimitives<VertexPositionColor>
						(PrimitiveType.LineList, vertices, 0, 3);
				}
			}

            base.Draw(gameTime);
        }
    }
}