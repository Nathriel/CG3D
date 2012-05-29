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

namespace Eindopdracht
{
	public class LetterU : DrawableGameComponent
	{
		private Cube[] cubeList;
		public Cube[] CubeList
		{
			get { return cubeList; }
			set { cubeList = value; }
		}

		public LetterU(Game game, Vector3 startPoint, Color color)
			: base(game)
		{
			cubeList = new Cube[7];
			cubeList[0] = new Cube(game, startPoint + new Vector3(0f, 2f, 0f), color);
			cubeList[1] = new Cube(game, startPoint + new Vector3(0f, 1f, 0f), color);
			cubeList[2] = new Cube(game, startPoint + new Vector3(0f, 0f, 0f), color);
			cubeList[3] = new Cube(game, startPoint + new Vector3(1f, 0f, 0f), color);
			cubeList[4] = new Cube(game, startPoint + new Vector3(2f, 0f, 0f), color);
			cubeList[5] = new Cube(game, startPoint + new Vector3(2f, 1f, 0f), color);
			cubeList[6] = new Cube(game, startPoint + new Vector3(2f, 2f, 0f), color);
		}

		public override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		public void Move(String direction)
		{
			foreach (Cube cube in cubeList)
			{
				if (direction == "left")
				{
					for (int i = 0; i < cube.Points.Length; i++)
					{
						cube.Points[i].Position.X -= 0.1f;
					}
				}
				else if (direction == "right")
				{
					for (int i = 0; i < cube.Points.Length; i++)
					{
						cube.Points[i].Position.X += 0.1f;
					}
				}
				else if (direction == "up")
				{
					for (int i = 0; i < cube.Points.Length; i++)
					{
						cube.Points[i].Position.Y += 0.1f;
					}
				}
				else if (direction == "down")
				{
					for (int i = 0; i < cube.Points.Length; i++)
					{
						cube.Points[i].Position.Y -= 0.1f;
					}
				}
				else if (direction == "front")
				{
					for (int i = 0; i < cube.Points.Length; i++)
					{
						cube.Points[i].Position.Z += 0.1f;
					}
				}
				else if (direction == "back")
				{
					for (int i = 0; i < cube.Points.Length; i++)
					{
						cube.Points[i].Position.Z -= 0.1f;
					}
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
