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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace WindowsGame3
{
	public class Camera : GameComponent
	{
		public Matrix view { get; protected set; }
		public Matrix projection { get; protected set; }

		private Vector3 pos;
		private Vector3 target;
		private Vector3 up;

		public Camera(Game game)
			: base(game)
		{
			pos = new Vector3(1.5f, 1.5f, 4f);
			target = Vector3.Zero; // (0, 0, 0)
			up = Vector3.UnitY; // (0, 1, 0)

			view = Matrix.CreateLookAt(pos, target, up);

			// opdracht 1a: Het achter clippingplane komt voor het assenstelsel te staan, dus zie je het assenstelsel ook niet meer.

			// opdracht 1c:
			projection =
				Matrix.CreatePerspectiveFieldOfView(
					MathHelper.PiOver4, //Field of Vision
					(float)Game.Window.ClientBounds.Width /
					(float)Game.Window.ClientBounds.Height, //Aspect Ratio
					1, //Camera clippingplane
					10 //achter clippingplane
				);
			// opdracht 4:
			/*
			Matrix.CreateOrthographicOffCenter(
				-3.0f, //links
				3.0f, //rechts / scherm breedte
				-3.0f, // boven / scherm hoogte
				3.0f, // beleden
				-3.0f, //camera clippingplane
				10.0f //achter clippingplane
			);
			*/
		}

		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				pos.X -= 0.1f;
				view = Matrix.CreateLookAt(pos, target, up);
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				pos.X += 0.1f;
				view = Matrix.CreateLookAt(pos, target, up);
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Up))
			{
				pos.Y += 0.1f;
				view = Matrix.CreateLookAt(pos, target, up);
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Down))
			{
				pos.Y -= 0.1f;
				view = Matrix.CreateLookAt(pos, target, up);
			}

			base.Update(gameTime);
		}
	}
}