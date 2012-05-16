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
	public class DrawUserIndexedPrimitivesAssignment : DrawableGameComponent
	{
		private BasicEffect effect;
		private VertexPositionColor[] points;
		private short[] lineList;
		private short[] lineStrip;
		private short[] triangleList;
		private short[] triangleStrip;

		public DrawUserIndexedPrimitivesAssignment(Game game)
			: base(game)
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			effect = new BasicEffect(GraphicsDevice);
			FillPoints();
			CreateLineList();
			CreateLineStrip();
			CreateTriangleList();
			CreateTriangleStrip();
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
			points[4] = new VertexPositionColor(new Vector3(2, 1, 0), Color.Black);
		}

		private void CreateLineList()
		{
			lineList = new short[4];

			lineList[0] = 0;
			lineList[1] = 3;
			lineList[2] = 3;
			lineList[3] = 4;
		}

		private void CreateLineStrip()
		{
			lineStrip = new short[3];

			lineStrip[0] = 0;
			lineStrip[1] = 3;
			lineStrip[2] = 4;
		}

		private void CreateTriangleList()
		{
			triangleList = new short[6];

			triangleList[0] = 0;
			triangleList[1] = 1;
			triangleList[2] = 2;

			triangleList[3] = 2;
			triangleList[4] = 1;
			triangleList[5] = 3;
		}

		private void CreateTriangleStrip()
		{
			triangleStrip = new short[4];

			triangleStrip[0] = 0;
			triangleStrip[1] = 1;
			triangleStrip[2] = 2;
			triangleStrip[3] = 3;
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
