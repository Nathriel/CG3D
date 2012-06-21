using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zonnestelsel
{
    public class Cube : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public string name;

        public Vector3 size;
        public Vector3 start;

        public BasicEffect effect;

        public Matrix world { get; set; }
        public Matrix origin { get; set; }

        public VertexPositionColor[] TriangleList;
        private short[] cubeStrip;
        public Color color { get; set; }

        public Cube(Game game, Vector3 size, Vector3 pos)
            : base(game)
        {
            this.size = size;
            this.start = pos;
            TriangleList = new VertexPositionColor[8];

            this.world = Matrix.Identity;
            this.origin = this.world;

            this.color = Color.Red;
        }

        public override void Initialize()
        {
            base.Initialize();
            effect = new BasicEffect(GraphicsDevice);

            TriangleList[0] = new VertexPositionColor(new Vector3(0, 0, 0), color);
            TriangleList[1] = new VertexPositionColor(new Vector3(1, 0, 0), color);
            TriangleList[2] = new VertexPositionColor(new Vector3(0, 1, 0), color);
            TriangleList[3] = new VertexPositionColor(new Vector3(1, 1, 0), color);
            TriangleList[4] = new VertexPositionColor(new Vector3(1, 1, 1), color);
            TriangleList[5] = new VertexPositionColor(new Vector3(0, 1, 1), color);
            TriangleList[6] = new VertexPositionColor(new Vector3(1, 0, 1), color);
            TriangleList[7] = new VertexPositionColor(new Vector3(0, 0, 1), color);

            cubeStrip = new short[35];

            cubeStrip[0] = 0;
            cubeStrip[1] = 2;
            cubeStrip[2] = 1;
            cubeStrip[3] = 3;

            cubeStrip[4] = 6;

            cubeStrip[5] = 4;
            cubeStrip[6] = 5;
            cubeStrip[7] = 3;
            cubeStrip[8] = 2;
            cubeStrip[9] = 0;
            cubeStrip[10] = 5;
            cubeStrip[11] = 7;
            cubeStrip[12] = 6;
            cubeStrip[13] = 0;
            cubeStrip[14] = 1;

            TranslateCube(start);
            ScaleCube(size);
        }

        public override void Update(GameTime gameTime)
        {
            this.RotateOnCenter(new Vector3(0f, 1f, 0f), 0.03f);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawScene(gameTime);
            drawPlanetText(gameTime);
            base.Draw(gameTime);
        }

        public void DrawScene(GameTime gameTime)
        {
            effect.World = this.world;
            effect.View = ((Game1)this.Game).camera.view;
            effect.Projection = ((Game1)this.Game).camera.projection;
            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleStrip, this.TriangleList, 0, 8, this.cubeStrip, 0, 15);

                GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            }
        }
        public Vector3 AllPointsTogether()
        {
            Vector3 ret = Vector3.Zero;
            foreach (VertexPositionColor point in TriangleList)
            {
                ret += point.Position;
            }
            return ret;
        }

        public Vector3 CalcuteCenter()
        {
            Vector3 ret = AllPointsTogether();
            ret = ret / TriangleList.Length;
            return ret;
        }

        public void RotateOnCenter(Vector3 rotationVector, float angle)
        {
            Vector3 center = CalcuteCenter();
            TranslateCube(Vector3.Zero - center);

            rotationVector.Normalize();
            Matrix rotationMatrix = Matrix.CreateFromAxisAngle(rotationVector, angle);
            for (int i = 0; i < TriangleList.Length; i++)
            {
                TriangleList[i].Position = Vector3.Transform(TriangleList[i].Position, rotationMatrix);
            }


            TranslateCube(center);
        }

        public void TranslateCube(Vector3 translateVector)
        {
            Matrix translationMatrix = Matrix.CreateTranslation(translateVector);

            for (int i = 0; i < TriangleList.Length; i++)
            {
                TriangleList[i].Position = Vector3.Transform(TriangleList[i].Position, translationMatrix);
            }
        }

        public void ScaleCube(Vector3 scaleVector)
        {
            Matrix scaleMatrix = Matrix.CreateScale(scaleVector);

            for (int i = 0; i < TriangleList.Length; i++)
            {
                TriangleList[i].Position = Vector3.Transform(TriangleList[i].Position, scaleMatrix);
            }
        }

        public void drawPlanetText(GameTime gameTime)
        {
            Vector3 screenSpace;
            Vector2 textPosition;
            Vector2 stringCenter;

            // calculate screenspace of text3d space position
            screenSpace = GraphicsDevice.Viewport.Project(this.CalcuteCenter(), ((Game1)this.Game).camera.projection, ((Game1)this.Game).camera.view, this.world);

            // get 2D position from screenspace vector
            textPosition.X = screenSpace.X;
            textPosition.Y = screenSpace.Y;

            // we want to draw the text centered around textPosition, so we'll
            // calculate the center of the string, and use that as the origin
            // argument to spriteBatch.DrawString. DrawString automatically
            // centers text around the vector specified by the origin argument.
            stringCenter = ((Game1)this.Game).font.MeasureString(this.name) * 0.5f;


            // now subtract the string center from the text position to find correct position
            textPosition.X = (int)(textPosition.X - stringCenter.X);
            textPosition.Y = (int)(textPosition.Y - stringCenter.Y);
            
            ((Game1)this.Game).spriteBatch.Begin();
            ((Game1)this.Game).spriteBatch.DrawString(((Game1)this.Game).font, this.name, textPosition, Color.GhostWhite);
            ((Game1)this.Game).spriteBatch.End();

            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
        }
    }
}
