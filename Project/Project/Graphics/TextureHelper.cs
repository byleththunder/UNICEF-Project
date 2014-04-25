﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace Project
{
    public static class TextHelper
    {
        private static Dictionary<string, Texture2D> cachedTextures;

        private static SpriteBatch spriteBatch;
        private static SpriteFont defaultSpriteFont;
        private static SpriteFont spriteFont;

        public static SpriteFont SpriteFont
        {
            get { return TextHelper.spriteFont; }
            set { TextHelper.spriteFont = value; }
        }

        public static SpriteBatch SpriteBatch
        {
            get { return TextHelper.spriteBatch; }
            set { 
                TextHelper.spriteBatch = value;
            }
        }

        public static Dictionary<string, Texture2D> CachedTextures
        {
            get {
                if (cachedTextures == null)
                    cachedTextures = new Dictionary<string, Texture2D>(10);
                return TextHelper.cachedTextures; 
            }
        }


        public static bool StringToTexture(string text, out Texture2D texture)
        {
            if (spriteBatch != null)
            {
                if (CachedTextures.ContainsKey(text))
                    texture = CachedTextures[text];
                else
                {
                    Texture2D tmp = CreateTexture(text);
                    texture = new Texture2D(tmp.GraphicsDevice, tmp.Width, tmp.Height);
                    Color[] colorData = new Color[tmp.Width*tmp.Height];
                    tmp.GetData<Color>(colorData);
                    texture.SetData<Color>(colorData);
                    tmp.Dispose();
                    CachedTextures.Add(text, texture);
                }
                return true;
            }
            texture = new Texture2D(spriteBatch.GraphicsDevice, 0, 0);
            return false;
        }

        private static Texture2D CreateTexture(string text)
        {
            Vector2 txtSize = spriteFont.MeasureString(text);

            RenderTarget2D rt2D = new RenderTarget2D(spriteBatch.GraphicsDevice, (int)txtSize.X, (int)txtSize.Y);

            spriteBatch.GraphicsDevice.SetRenderTarget(rt2D);
            spriteBatch.GraphicsDevice.Clear(Color.Transparent);

            BlendState defaultBlendState = spriteBatch.GraphicsDevice.BlendState;
            spriteBatch.GraphicsDevice.BlendState = BlendState.AlphaBlend;

            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, text, Vector2.Zero, Color.White);
            spriteBatch.End();

            spriteBatch.GraphicsDevice.SetRenderTarget(null);
            spriteBatch.GraphicsDevice.BlendState = defaultBlendState;

            return (Texture2D)rt2D;
        }

        public static void LoadDefaultFont(ContentManager contentManager)
        {
            if (defaultSpriteFont == null)
            {
                defaultSpriteFont = contentManager.Load<SpriteFont>("Fonte" + Path.AltDirectorySeparatorChar + "Arial");
                spriteFont = defaultSpriteFont;
            }
        }

        public static void FlushCache()
        {
            cachedTextures.Clear();
        }
    }
}