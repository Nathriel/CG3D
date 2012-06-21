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
        public SpriteBatch spriteBatch;
        public SpriteFont font;

		private BasicEffect effect;
		private _3D_axis assenstelsel;
		public Camera camera { get; protected set; }

		Viewport defaultViewport;

        StarSystem Eridani_system;

		public Game1()
		{
			this.graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			this.assenstelsel = new _3D_axis(this);
			this.Components.Add(assenstelsel);

            this.Eridani_system = new StarSystem(this);
		}

		
		protected override void Initialize()
        {
            this.camera = new Camera(this, new Vector3(0, 0, 0), new Vector3(10, 10, 10), Vector3.UnitY);
            this.Components.Add(this.camera);

			effect = new BasicEffect(GraphicsDevice);
			base.Initialize();
		}

		
		protected override void LoadContent()
		{
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.font = Content.Load<SpriteFont> ("SpriteFont1");

			defaultViewport = GraphicsDevice.Viewport;
		}


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            base.Update(gameTime);
        }
		
		protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            this.assenstelsel.Draw(gameTime);
            this.Eridani_system.Draw(gameTime);
			base.Draw(gameTime);
		}
	}
}
