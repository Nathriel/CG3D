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


namespace Viewports
{
	public class Cube : DrawableGameComponent
	{
		private BasicEffect effect;
		private VertexPositionColor[] cubeList;

		public Cube(Game game)
			: base(game)
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			effect = new BasicEffect(GraphicsDevice);
			CreateCubeList();
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		private void CreateCubeList()
		{
			cubeList = new VertexPositionColor[99];

			cubeList[0] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Blue);
			cubeList[1] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Blue);
			cubeList[2] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Blue);

			cubeList[3] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Blue);
			cubeList[4] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Blue);
			cubeList[5] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Blue);

			cubeList[6] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Red);
			cubeList[7] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Red);
			cubeList[8] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);

			cubeList[9] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);
			cubeList[10] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Red);
			cubeList[11] = new VertexPositionColor(new Vector3(0, 1, 1), Color.Red);

			cubeList[12] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Yellow);
			cubeList[13] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Yellow);
			cubeList[14] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Yellow);

			cubeList[15] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Yellow);
			cubeList[16] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Yellow);
			cubeList[17] = new VertexPositionColor(new Vector3(1, 0, 1), Color.Yellow);

			cubeList[18] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Purple);
			cubeList[19] = new VertexPositionColor(new Vector3(1, 0, 1), Color.Purple);
			cubeList[20] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Purple);

			cubeList[21] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Purple);
			cubeList[22] = new VertexPositionColor(new Vector3(1, 0, 1), Color.Purple);
			cubeList[23] = new VertexPositionColor(new Vector3(0, 0, 1), Color.Purple);

			cubeList[24] = new VertexPositionColor(new Vector3(0, 1, 1), Color.Gray);
			cubeList[25] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Gray);
			cubeList[26] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Gray);

			cubeList[27] = new VertexPositionColor(new Vector3(0, 1, 1), Color.Gray);
			cubeList[28] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Gray);
			cubeList[29] = new VertexPositionColor(new Vector3(0, 0, 1), Color.Gray);

			cubeList[30] = new VertexPositionColor(new Vector3(0, 0, 1), Color.Green);
			cubeList[31] = new VertexPositionColor(new Vector3(0, 1, 1), Color.Green);
			cubeList[32] = new VertexPositionColor(new Vector3(1, 0, 1), Color.Green);

			cubeList[33] = new VertexPositionColor(new Vector3(1, 0, 1), Color.Green);
			cubeList[34] = new VertexPositionColor(new Vector3(0, 1, 1), Color.Green);
			cubeList[35] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Green);
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

				GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, cubeList, 0, 12, VertexPositionColor.VertexDeclaration);
			}
			base.Draw(gameTime);
		}
	}
}
