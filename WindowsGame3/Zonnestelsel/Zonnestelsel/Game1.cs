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

namespace Zonnestelsel
{
	
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private BasicEffect effect;
		private _3D_axis assenstelsel;
		public Camera camera { get; protected set; }
		private List<Planet> planetList;

		private Planet sun;
		private Planet earth;

		Viewport defaultViewport;
		Matrix projectionMatrix;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			assenstelsel = new _3D_axis(this);
			this.Components.Add(assenstelsel);

			projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 4.0f / 3.0f, 1.0f, 10000f);

			camera = new Camera(this, projectionMatrix, new Vector3(2f, 2f, 10f), Vector3.UnitY);

			planetList = new List<Planet>();

			sun = new Planet(this, new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f), Color.Gold);
			planetList.Add(sun);


			earth = new Planet(this, new Vector3(3f, 3f, 3f), new Vector3(0.5f, 0.5f, 0.5f), Color.Gold);
			planetList.Add(earth);
		}

		
		protected override void Initialize()
		{
			effect = new BasicEffect(GraphicsDevice);
			base.Initialize();
		}

		
		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			defaultViewport = GraphicsDevice.Viewport;
		}

		
		protected override void Update(GameTime gameTime)
		{

			// Allows the game to exit
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				camera.Move("left");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				camera.Move("right");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Up))
			{
				camera.Move("up");
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.Down))
			{
				camera.Move("down");
			}


			sun.RotateOnCenter(new Vector3(1f, 1f, 1f), 0.03f);

			earth.RotateOnPoint(new Vector3(1f, 1f, 1f), 0.05f);
			
			

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

				foreach (Planet planet in planetList)
				{
					GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, planet.Points, 0, 8, planet.CubeStrip, 0, 15);
				}
			}
		}

		
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.RasterizerState = RasterizerState.CullNone;

			GraphicsDevice.Viewport = defaultViewport;
			GraphicsDevice.Clear(Color.White);

			drawView(defaultViewport, camera);

			base.Draw(gameTime);
		}
	}
}
