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

namespace Viewports
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private BasicEffect effect;
		private _3D_axis assenstelsel;
		public Camera camera1 { get; protected set; }
		public Camera camera2 { get; protected set; }
		private Cube cube;

		Viewport defaultViewport;
		Viewport leftViewport;
		Viewport rightViewport;
		Matrix projectionMatrix;
		Matrix halfprojectionMatrix;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			assenstelsel = new _3D_axis(this);
			this.Components.Add(assenstelsel);

			projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 4.0f / 3.0f, 1.0f, 10000f);
			halfprojectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 2.0f / 3.0f, 1.0f, 10000f);

			camera1 = new Camera(this, halfprojectionMatrix, new Vector3(0f, 0f, 10f), Vector3.UnitY);

			camera2 = new Camera(this, halfprojectionMatrix, new Vector3(0f, 10f, 0f), Vector3.UnitZ);

			cube = new Cube(this);
			this.Components.Add(cube);
		}

		protected override void Initialize()
		{
			effect = new BasicEffect(GraphicsDevice);
			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			defaultViewport = GraphicsDevice.Viewport;
			leftViewport = defaultViewport;
			rightViewport = defaultViewport;
			leftViewport.Width = leftViewport.Width / 2;
			rightViewport.Width = rightViewport.Width / 2;
			rightViewport.X = leftViewport.Width;
		}

		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				cube.Move("left");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				cube.Move("right");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				cube.Move("up");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Down) && !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				cube.Move("down");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				cube.Move("front");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				cube.Move("back");
			}


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.RasterizerState = RasterizerState.CullNone;

			GraphicsDevice.Viewport = defaultViewport;
			GraphicsDevice.Clear(Color.White);

			GraphicsDevice.Viewport = leftViewport;
			effect.World = Matrix.Identity;
			effect.View = camera1.view;
			effect.Projection = camera1.projection;
			effect.VertexColorEnabled = true;
			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();

				GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, assenstelsel.Vertices, 0, 3);

				GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, cube.Points, 0, 8, cube.CubeStrip, 0, 15);
			}

			GraphicsDevice.Viewport = rightViewport;
			effect.World = Matrix.Identity;
			effect.View = camera2.view;
			effect.Projection = camera2.projection;
			effect.VertexColorEnabled = true;
			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();

				GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, assenstelsel.Vertices, 0, 3);

				GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, cube.Points, 0, 8, cube.CubeStrip, 0, 15);
			}


			

			base.Draw(gameTime);
		}
	}
}