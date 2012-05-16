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
	public class Triangle : DrawableGameComponent
	{
		private VertexPositionColor[] vertices;
		private BasicEffect effect;

		private Vector3 firstPoint;
		private Vector3 secondPoint;
		private Vector3 thirdPoint;

		private Color color;

		public Triangle(Game game, Vector3 firstPoint, Vector3 secondPoint, Vector3 thirdPoint, Color color)
			: base(game)
		{
			this.firstPoint = firstPoint;
			this.secondPoint = secondPoint;
			this.thirdPoint = thirdPoint;
			this.color = color;
		}

		protected override void LoadContent()
		{
			base.LoadContent();

			vertices = new VertexPositionColor[3];

			vertices[0] = new VertexPositionColor(firstPoint, color);
			vertices[1] = new VertexPositionColor(secondPoint, color);
			vertices[2] = new VertexPositionColor(thirdPoint, color);
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

		public override void Draw(GameTime gameTime)
		{
			effect.World = Matrix.Identity;
			effect.View = ((Game1)this.Game).camera.view;
			effect.Projection = ((Game1)this.Game).camera.projection;
			effect.VertexColorEnabled = true;
			
			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();
				GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 1, VertexPositionColor.VertexDeclaration);
			}
			
			base.Draw(gameTime);
		}
	}
}
