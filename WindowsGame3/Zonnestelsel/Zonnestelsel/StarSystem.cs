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
            ket_cheleb = new Planet(game, new Vector3(-0.2f, -0.2f, -0.2f), new Vector3(5f, -0.10f, 5f));
            ket_cheleb.name = "Ket Cheleb";
            ket_cheleb.angle_increase = 2f;
            vulcan = new Planet(game, new Vector3(-0.3f, -0.3f, -0.3f), new Vector3(6f, -0.10f, 6f));
            vulcan.name = "Vulcan";
            vulcan.color = Color.IndianRed;
            valdena = new Planet(game, new Vector3(-0.4f, -0.4f, -0.4f), new Vector3(8f, -0.10f, 8f));
            valdena.name = "Valdena";
            valdena.color = Color.PaleVioletRed;
            valdena.angle_increase = 0.1f;
            tel_alep = new Planet(game, new Vector3(-0.3f, -0.3f, -0.3f), new Vector3(13f, -0.10f, 13f));
            tel_alep.name = "Tel Alep";
            tel_alep.color = Color.PaleTurquoise;
            tel_alep.angle_increase = 0.8f;
            kal_apton = new Planet(game, new Vector3(-0.7f, -0.7f, -0.7f), new Vector3(13f, -0.10f, 13f));
            kal_apton.name = "Kal Apton";
            kal_apton.color = Color.DarkOliveGreen;
            kal_apton.angle_increase = 0.2f;
            kir_alep = new Planet(game, new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(15f, -0.10f, 15f));
            kir_alep.name = "Kir Alep";
            kir_alep.color = Color.DarkCyan;
            kir_alep.angle_increase = 0.4f;

            //Add
            game.Components.Add(vulcanis_a);
            game.Components.Add(ket_cheleb);
            game.Components.Add(vulcan);
            game.Components.Add(valdena);
            game.Components.Add(tel_alep);
            game.Components.Add(kal_apton);
            game.Components.Add(kir_alep);
        }

        public override void Update(GameTime gameTime)
        {
            rotatePlanets();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
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
