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
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

        private _3D_axis assenstelsel;
		public Camera camera { get; protected set; }
		private DrawUserPrimitivesAssignment drawUserPrimitivesAssignment;
		private DrawUserIndexedPrimitivesAssignment drawUserIndexedPrimitivesAssignment;
		private Cube cube;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            assenstelsel = new _3D_axis(this);
            this.Components.Add(assenstelsel);
            
            camera = new Camera(this);
            this.Components.Add(camera);

			//opdracht 2a: aan de rechterkant van de driehoek zie ik de driehoek niet, maar aan de linkerkant wel
			Triangle triangle = new Triangle(this, new Vector3(0, 0, 0), new Vector3(0, 0.5f, 0), new Vector3(0, 0, 0.5f), Color.Blue);
			//this.Components.Add(triangle);

			drawUserPrimitivesAssignment = new DrawUserPrimitivesAssignment(this);
			this.Components.Add(drawUserPrimitivesAssignment);

			drawUserIndexedPrimitivesAssignment = new DrawUserIndexedPrimitivesAssignment(this);
			this.Components.Add(drawUserIndexedPrimitivesAssignment);

			cube = new Cube(this);
			this.Components.Add(cube);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.Z))
			{
				assenstelsel.switchEnabled();
			}
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

			//opdracht 2b:
				//CullNone: beide kanten zichtbaar
				//CullClockwise: rechtekant zichtbaar
				//CullCounterclockwise: linkerkant zichtbaar
			
			//opdracht 2a:
			GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            base.Draw(gameTime); // deze regel zorgt ervoor dat Components getekend wordt
        }
    }
}
