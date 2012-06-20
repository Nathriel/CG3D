using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zonnestelsel
{
    class StarSystem : Microsoft.Xna.Framework.DrawableGameComponent
    {
        BasicEffect effect;

        Sun vulcanis_a;

        Planet ket_cheleb;
        Planet vulcan;
        Planet valdena;
        Planet tel_alep;
        Planet kal_apton;
        Planet kir_alep;

        public StarSystem(Game game)
            : base(game)
        {
            //Create
            vulcanis_a = new Sun(game, new Vector3(1f, 1f, 1f), new Vector3(-0.5f, -0.5f, -0.5f));
            vulcanis_a.color = Color.Yellow;
            vulcanis_a.name = "Vulcanis A";
            ket_cheleb = new Planet(game, new Vector3(-0.2f, -0.2f, -0.2f), new Vector3(2.5f, -0.10f, 2.5f));
            ket_cheleb.name = "Ket Cheleb";

            //Add
            game.Components.Add(ket_cheleb);
            game.Components.Add(vulcanis_a);
        }

        public override void Update(GameTime gameTime)
        {
            rotatePlanets();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            vulcanis_a.Draw(gameTime);
            ket_cheleb.Draw(gameTime);

            base.Draw(gameTime);
        }

        public void rotatePlanets()
        {
            //rotate Planets around its center
            Matrix translation = Matrix.CreateTranslation(-vulcanis_a.start - (vulcanis_a.size / 2));

            Matrix rotation = Matrix.CreateRotationY(MathHelper.ToRadians(1));
            Matrix result = Matrix.Multiply(Matrix.Identity, translation);
            result = Matrix.Multiply(result, rotation);
            result = Matrix.Multiply(result, Matrix.Invert(translation));

            vulcanis_a.world = vulcanis_a.world * result;
        }
    }
}
