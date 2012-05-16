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
	public class DrawUserPrimitivesAssignment : DrawableGameComponent
	{
		private BasicEffect effect;
		private VertexPositionColor[] lineList;
		private VertexPositionColor[] lineStrip;
		private VertexPositionColor[] triangleList;
		private VertexPositionColor[] triangleStrip;

		public DrawUserPrimitivesAssignment(Game game)
			: base(game)
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			effect = new BasicEffect(GraphicsDevice);
			CreateLineList();
			CreateLineStrip();
			CreateTriangleList();
			CreateTriangleStrip();
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		private void CreateLineList()
		{
			lineList = new VertexPositionColor[4];

			lineList[0] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Black);
			lineList[1] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Black);
			lineList[2] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Black);
			lineList[3] = new VertexPositionColor(new Vector3(2, 1, 0), Color.Black);
		}

		private void CreateLineStrip()
		{
			lineStrip = new VertexPositionColor[3];

			lineStrip[0] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Black);
			lineStrip[1] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Black);
			lineStrip[2] = new VertexPositionColor(new Vector3(2, 1, 0), Color.Black);
		}

		private void CreateTriangleList()
		{
			triangleList = new VertexPositionColor[6];

			triangleList[0] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Black);
			triangleList[1] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Black);
			triangleList[2] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Black);

			triangleList[3] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Blue);
			triangleList[4] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Blue);
			triangleList[5] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Blue);
		}

		private void CreateTriangleStrip()
		{
			triangleStrip = new VertexPositionColor[4];

			triangleStrip[0] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Black);
			triangleStrip[1] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Black);
			triangleStrip[2] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Black);
			triangleStrip[3] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Blue);
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
				//GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, lineList, 0, 2, VertexPositionColor.VertexDeclaration);
				//GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineStrip, lineStrip, 0, 2, VertexPositionColor.VertexDeclaration);
				//GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList, 0, 2, VertexPositionColor.VertexDeclaration);
				//GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, triangleStrip, 0, 2, VertexPositionColor.VertexDeclaration);
			}
			base.Draw(gameTime);
		}
	}
}
