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
		private LetterL firstLetter;
		private LetterU secondLetter;
		private LetterL thirdLetter;

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

			camera3 = new Camera(this, quadprojectionMatrix, new Vector3(30f, 0f, 10f), Vector3.UnitY);

			camera4 = new Camera(this, quadprojectionMatrix, new Vector3(10f, 10f, 10f), Vector3.UnitY);

			firstLetter = new LetterL(this, new Vector3(-4, 0, 0), Color.Blue);
			this.Components.Add(firstLetter);
			secondLetter = new LetterU(this, new Vector3(-1, 0, 0), Color.Red);
			this.Components.Add(secondLetter);
			thirdLetter = new LetterL(this, new Vector3(3, 0, 0), Color.Green);
			this.Components.Add(thirdLetter);
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
				firstLetter.Move("left");
				secondLetter.Move("left");
				thirdLetter.Move("left");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				firstLetter.Move("right");
				secondLetter.Move("right");
				thirdLetter.Move("right");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Up) && !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				firstLetter.Move("up");
				secondLetter.Move("up");
				thirdLetter.Move("up");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Down) && !Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				firstLetter.Move("down");
				secondLetter.Move("down");
				thirdLetter.Move("down");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				firstLetter.Move("front");
				secondLetter.Move("front");
				thirdLetter.Move("front");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.LeftControl))
			{
				firstLetter.Move("back");
				secondLetter.Move("back");
				thirdLetter.Move("back");
			}


			base.Update(gameTime);
		}

		private void drawView(Viewport viewport, Camera camera)
		{
			GraphicsDevice.Viewport = viewport;
			effect.World = Matrix.Identity;
			effect.View = camera.view;
			effect.Projection = camera.projection;
			effect.VertexColorEnabled = true;
			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();

				GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, assenstelsel.Vertices, 0, 3);

				foreach (Cube cube in firstLetter.CubeList)
				{
					GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, cube.Points, 0, 8, cube.CubeStrip, 0, 15);
				}
				foreach (Cube cube in secondLetter.CubeList)
				{
					GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, cube.Points, 0, 8, cube.CubeStrip, 0, 15);
				}
				foreach (Cube cube in thirdLetter.CubeList)
				{
					GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, cube.Points, 0, 8, cube.CubeStrip, 0, 15);
				}
			}
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

			drawView(leftTopViewport, camera1);
			drawView(leftBottomViewport, camera2);
			drawView(rightTopViewport, camera3);
			drawView(rightBottomViewport, camera4);

			base.Draw(gameTime);
		}
	}
}
