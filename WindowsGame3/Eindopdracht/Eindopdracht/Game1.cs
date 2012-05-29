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

namespace Eindopdracht
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private BasicEffect effect;
		private _3D_axis assenstelsel;
		public Camera camera1 { get; protected set; }
		public Camera camera2 { get; protected set; }
		public Camera camera3 { get; protected set; }
		public Camera camera4 { get; protected set; }
		private LetterL letterL;

		Viewport defaultViewport;
		Viewport leftTopViewport;
		Viewport rightTopViewport;
		Viewport leftBottomViewport;
		Viewport rightBottomViewport;
		Matrix projectionMatrix;
		Matrix halfprojectionMatrix;
		Matrix quadprojectionMatrix;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			assenstelsel = new _3D_axis(this);
			this.Components.Add(assenstelsel);

			projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 4.0f / 3.0f, 1.0f, 10000f);
			halfprojectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 2.0f / 3.0f, 1.0f, 10000f);
			quadprojectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 2.0f / 1.5f, 1.0f, 10000f);

			camera1 = new Camera(this, quadprojectionMatrix, new Vector3(0f, 0f, 10f), Vector3.UnitY);

			camera2 = new Camera(this, quadprojectionMatrix, new Vector3(0f, 10f, 0f), Vector3.UnitZ);

			camera3 = new Camera(this, quadprojectionMatrix, new Vector3(0f, 0f, 10f), Vector3.UnitX);

			camera4 = new Camera(this, quadprojectionMatrix, new Vector3(10f, 10f, 10f), Vector3.UnitZ);

			letterL = new LetterL(this);
			this.Components.Add(letterL);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			effect = new BasicEffect(GraphicsDevice);
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			defaultViewport = GraphicsDevice.Viewport;
			leftTopViewport = defaultViewport;
			rightTopViewport = defaultViewport;
			leftBottomViewport = defaultViewport;
			rightBottomViewport = defaultViewport;

			leftTopViewport.Width = leftTopViewport.Width / 2;
			leftBottomViewport.Width = leftTopViewport.Width;
			rightTopViewport.Width = rightTopViewport.Width / 2;
			rightBottomViewport.Width = rightTopViewport.Width;

			leftTopViewport.Height = defaultViewport.Height / 2;
			rightTopViewport.Height = defaultViewport.Height / 2;
			leftBottomViewport.Height = defaultViewport.Height / 2;
			rightBottomViewport.Height = defaultViewport.Height / 2;

			rightTopViewport.X = leftTopViewport.Width;
			rightBottomViewport.X = leftBottomViewport.Width;
			rightBottomViewport.Y = rightTopViewport.Height;
			leftBottomViewport.Y = leftTopViewport.Height;

			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				letterL.Move("left");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				letterL.Move("right");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				letterL.Move("up");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Down) && !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				letterL.Move("down");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				letterL.Move("front");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				letterL.Move("back");
			}


			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.RasterizerState = RasterizerState.CullNone;

			GraphicsDevice.Viewport = defaultViewport;
			GraphicsDevice.Clear(Color.White);

			GraphicsDevice.Viewport = leftTopViewport;
			effect.World = Matrix.Identity;
			effect.View = camera1.view;
			effect.Projection = camera1.projection;
			effect.VertexColorEnabled = true;
			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();

				GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, assenstelsel.Vertices, 0, 3);

				foreach(Cube cube in letterL.CubeList)
				{
					GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, cube.Points, 0, 8, cube.CubeStrip, 0, 15);
				}
			}

			GraphicsDevice.Viewport = leftBottomViewport;
			effect.World = Matrix.Identity;
			effect.View = camera2.view;
			effect.Projection = camera2.projection;
			effect.VertexColorEnabled = true;
			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();

				GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, assenstelsel.Vertices, 0, 3);
				
				foreach(Cube cube in letterL.CubeList)
				{
					GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, cube.Points, 0, 8, cube.CubeStrip, 0, 15);
				}
			}

			GraphicsDevice.Viewport = rightTopViewport;
			effect.World = Matrix.Identity;
			effect.View = camera3.view;
			effect.Projection = camera3.projection;
			effect.VertexColorEnabled = true;
			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();

				GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, assenstelsel.Vertices, 0, 3);
				
				foreach(Cube cube in letterL.CubeList)
				{
					GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, cube.Points, 0, 8, cube.CubeStrip, 0, 15);
				}
			}

			GraphicsDevice.Viewport = rightBottomViewport;
			effect.World = Matrix.Identity;
			effect.View = camera4.view;
			effect.Projection = camera4.projection;
			effect.VertexColorEnabled = true;
			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();

				GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, assenstelsel.Vertices, 0, 3);
				
				foreach(Cube cube in letterL.CubeList)
				{
					GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, cube.Points, 0, 8, cube.CubeStrip, 0, 15);
				}
			}




			base.Draw(gameTime);
		}
	}
}
