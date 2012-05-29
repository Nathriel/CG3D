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
	public class LetterL : DrawableGameComponent
	{
		private Cube[] cubeList;
		public Cube[] CubeList
		{
			get { return cubeList; }
			set { cubeList = value; }
		}

		public LetterL(Game game)
			: base(game)
		{
			cubeList = new Cube[4];
			cubeList[0] = new Cube(game, new Vector3(0, 2, 0));
			cubeList[1] = new Cube(game, new Vector3(0, 1, 0));
			cubeList[2] = new Cube(game, new Vector3(0, 0, 0));
			cubeList[3] = new Cube(game, new Vector3(1, 0, 0));
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
