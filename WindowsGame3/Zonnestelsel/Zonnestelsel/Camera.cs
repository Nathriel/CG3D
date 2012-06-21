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

namespace Zonnestelsel
{
	public class Camera : GameComponent
	{
		public Matrix view { get; protected set; }
		public Matrix projection { get; protected set; }

		private Vector3 pos;
		private Vector3 target;
		private Vector3 up;

		//public Camera(Game game, Matrix projection, Vector3 pos, Vector3 up)
        public Camera(Game game, Vector3 tar, Vector3 position, Vector3 up)
            : base(game)
		{
            this.pos = position;
			target = tar;
			this.up = up;

			view = Matrix.CreateLookAt(pos, target, up);

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Game.Window.ClientBounds.Width / (float)Game.Window.ClientBounds.Height, 1, 100);
		}

		public override void Initialize()
		{
			base.Initialize();
		}

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            //currentMState = Mouse.GetState();

            //float x;
            //float y;
            //if (currentMState.LeftButton == ButtonState.Pressed)
            //{
            //    x = currentMState.X - prevMState.X;
            //    y = currentMState.Y - prevMState.Y;

            //    pos.X += (x * 0.1f);
            //    pos.Y += (y * 0.1f);
            //    view = Matrix.CreateLookAt(pos, target, up);
            //}
            //prevMState = currentMState;

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

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                pos.Y -= 0.1f;
                view = Matrix.CreateLookAt(pos, target, up);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                pos.Y += 0.1f;
                view = Matrix.CreateLookAt(pos, target, up);
            }

            base.Update(gameTime);
        }
	}
}
