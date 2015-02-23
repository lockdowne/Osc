using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oEngine.Factories
{
    public sealed class TextureFactory : IFactory
    {
        private IDictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public ContentManager Content;
        
        public void AddTexture(string name)
        {
            if (Content == null)
                return;

            if (!textures.ContainsKey(name))
            {
                textures.Add(name, Content.Load<Texture2D>("Textures/" + name));
            }
        }

        public void UnloadContent()
        {
            textures.Clear();
        }

        public Texture2D GetTexture(string name)
        {
            return textures.ContainsKey(name) ? textures[name] : null;
        }
        
    }
}
