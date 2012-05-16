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


namespace WindowsGame3
{
	public class Cube : DrawableGameComponent
	{
		private BasicEffect effect;
		private VertexPositionColor[] points;
		private short[] cubeStrip;

		public Cube(Game game)
			: base(game)
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			effect = new BasicEffect(GraphicsDevice);
			FillPoints();
			CreateCubeStrip();
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		private void FillPoints()
		{
			points = new VertexPositionColor[5];

			points[0] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Black);
			points[1] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Black);
			points[2] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Black);
			points[3] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Black);
		}

		private void CreateCubeStrip()
		{
			cubeStrip = new short[4];

			cubeStrip[0] = 0;
			cubeStrip[1] = 1;
			cubeStrip[2] = 2;
			cubeStrip[3] = 3;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			effect.World = Matrix.Identity;
			effect.View = ((Game1)this.Game).camera.view;
			effect.Projection = ((Game1)this.Game).camera.projection;
			effect.VertexColorEnabled = true;

			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();

				//GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.LineList, points, 0, 5, lineList, 0, 2);
				//GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.LineStrip, points, 0, 5, lineStrip, 0, 2);
				//GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, points, 0, 4, triangleList, 0, 2);
				//GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, points, 0, 4, triangleStrip, 0, 2);
			}
			base.Draw(gameTime);
		}
	}
}
