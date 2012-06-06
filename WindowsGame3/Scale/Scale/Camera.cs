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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Scale
{
	public class Camera : GameComponent
	{
		public Matrix view { get; protected set; }
		public Matrix projection { get; protected set; }

		private Vector3 pos;
		private Vector3 target;
		private Vector3 up;

		public Camera(Game game, Matrix projection, Vector3 pos, Vector3 up)
			: base(game)
		{
			this.pos = pos;
			target = Vector3.Zero;
			this.up = up;

			view = Matrix.CreateLookAt(pos, target, up);

			this.projection = projection;
		}

		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		public void Move(String direction)
		{
			if (direction == "left")
			{
				pos.X -= 0.1f;
			}
			else if (direction == "right")
			{
				pos.X += 0.1f;
			}
			else if (direction == "up")
			{
				pos.Y += 0.1f;
			}
			else if (direction == "down")
			{
				pos.Y -= 0.1f;
			}
			view = Matrix.CreateLookAt(pos, target, up);
		}
	}
}
