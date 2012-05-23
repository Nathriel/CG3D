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
		private VertexPositionColor[] points;

		public VertexPositionColor[] Points
		{
			get { return points; }
			set { points = value; }
		}

		private short[] cubeStrip;
		public short[] CubeStrip
		{
			get { return cubeStrip; }
			set { cubeStrip = value; }
		}

		public Cube(Game game)
			: base(game)
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			FillPoints();
			CreateCubeStrip();
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		private void FillPoints()
		{
			points = new VertexPositionColor[8];

			points[0] = new VertexPositionColor(new Vector3(0, 0, 0), Color.Black);
			points[1] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Black);
			points[2] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Black);
			points[3] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Black);
			points[4] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Black);
			points[5] = new VertexPositionColor(new Vector3(0, 1, 1), Color.Black);
			points[6] = new VertexPositionColor(new Vector3(1, 0, 1), Color.Black);
			points[7] = new VertexPositionColor(new Vector3(0, 0, 1), Color.Black);
		}

		private void CreateCubeStrip()
		{
			cubeStrip = new short[35];

			cubeStrip[0] = 0;
			cubeStrip[1] = 2;
			cubeStrip[2] = 1;
			cubeStrip[3] = 3;

			cubeStrip[4] = 6;

			cubeStrip[5] = 4;
			cubeStrip[6] = 5;
			cubeStrip[7] = 3;
			cubeStrip[8] = 2;
			cubeStrip[9] = 0;
			cubeStrip[10] = 5;
			cubeStrip[11] = 7;
			cubeStrip[12] = 6;
			cubeStrip[13] = 0;
			cubeStrip[14] = 1;
		}

		public void Move(String direction)
		{
			if (direction == "left")
			{
				for (int i = 0; i < points.Length; i++ )
				{
					points[i].Position.X -= 0.1f;
				}
			}
			else if (direction == "right")
			{
				for (int i = 0; i < points.Length; i++)
				{
					points[i].Position.X += 0.1f;
				}
			}
			else if (direction == "up")
			{
				for (int i = 0; i < points.Length; i++)
				{
					points[i].Position.Y += 0.1f;
				}
			}
			else if (direction == "down")
			{
				for (int i = 0; i < points.Length; i++)
				{
					points[i].Position.Y -= 0.1f;
				}
			}
			else if (direction == "front")
			{
				for (int i = 0; i < points.Length; i++)
				{
					points[i].Position.Z += 0.1f;
				}
			}
			else if (direction == "back")
			{
				for (int i = 0; i < points.Length; i++)
				{
					points[i].Position.Z -= 0.1f;
				}
			}
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}
	}
}
