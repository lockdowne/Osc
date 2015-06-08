using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oEngine.Factories
{
    public sealed class FontFactory : IFactory
    {
        private IDictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

        public ContentManager Content;


        public void UnloadContent()
        {
            fonts.Clear();
        }

        public void AddFont(string name)
        {
            if (Content == null)
                return;

            if(!fonts.ContainsKey(name))
            {
                fonts.Add(name, Content.Load<SpriteFont>("Fonts/" + name));
            }
        }

        public SpriteFont GetFont(string name)
        {
            return fonts.ContainsKey(name) ? fonts[name] : null;
        }
    }
}
