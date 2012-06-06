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

namespace Scale
{
	public class Cube : DrawableGameComponent
	{
		private Vector3 startPoint;
		private Color color;

		private VertexPositionColor[] points;
		private short[] cubeStrip;

		public VertexPositionColor[] Points
		{
			get { return points; }
			set { points = value; }
		}

		public short[] CubeStrip
		{
			get { return cubeStrip; }
			set { cubeStrip = value; }
		}

		public Cube(Game game, Vector3 startPoint, Color color)
			: base(game)
		{
			this.startPoint = startPoint;
			this.color = color;
			FillPoints();
			CreateCubeStrip();
			TranslateCube(startPoint);
			ScaleCube(new Vector3(2f, 0.5f, 0.5f));
		}

		public override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		private Vector3 AllPointsTogether()
		{
			Vector3 ret = Vector3.Zero;
			foreach (VertexPositionColor point in points)
			{
				ret += point.Position;
			}
			return ret;
		}

		private Vector3 CalcuteCenter()
		{
			Vector3 ret = AllPointsTogether();
			ret = ret / points.Length;
			return ret;
		}

		public void RotateCube(Vector3 rotationVector, float angle)
		{
			Vector3 center = CalcuteCenter();
			TranslateCube(Vector3.Zero - center);

			rotationVector.Normalize();
			Matrix rotationMatrix = Matrix.CreateFromAxisAngle(rotationVector, angle);
			for (int i = 0; i < points.Length; i++)
			{
				points[i].Position = Vector3.Transform(points[i].Position, rotationMatrix);
			}


			TranslateCube(center);
		}

		public void TranslateCube(Vector3 translateVector)
		{
			Matrix translationMatrix = Matrix.CreateTranslation(translateVector);

			for (int i = 0; i < points.Length; i++)
			{
				points[i].Position = Vector3.Transform(points[i].Position, translationMatrix);
			}
		}

		public void ScaleCube(Vector3 scaleVector)
		{
			Matrix scaleMatrix = Matrix.CreateScale(scaleVector);

			for (int i = 0; i < points.Length; i++)
			{
				points[i].Position = Vector3.Transform(points[i].Position, scaleMatrix);
			}
		}

		private void FillPoints()
		{
			points = new VertexPositionColor[8];

			points[0] = new VertexPositionColor(new Vector3(0, 0, 0), color);
			points[1] = new VertexPositionColor(new Vector3(1, 0, 0), color);
			points[2] = new VertexPositionColor(new Vector3(0, 1, 0), color);
			points[3] = new VertexPositionColor(new Vector3(1, 1, 0), color);
			points[4] = new VertexPositionColor(new Vector3(1, 1, 1), color);
			points[5] = new VertexPositionColor(new Vector3(0, 1, 1), color);
			points[6] = new VertexPositionColor(new Vector3(1, 0, 1), color);
			points[7] = new VertexPositionColor(new Vector3(0, 0, 1), color);
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
				for (int i = 0; i < points.Length; i++)
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
