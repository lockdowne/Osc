using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oEngine.Entities
{
    public class Sprite : IEntity
    {
        private Dictionary<string, Queue<Animation>> animations = new Dictionary<string, Queue<Animation>>();

        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the pixel position of sprite
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the color overlay of sprite
        /// </summary>
        public Color Tint { get; set; }

        /// <summary>
        /// Gets or sets the scale of sprite
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// Gets or sets the rotation of sprite
        /// </summary>
        public float Rotation { get; set; }
        
        /// <summary>
        /// Gets or sets whether sprite should be udpated
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets whether sprite should be drawn
        /// </summary>
        public bool IsVisible { get; set; }

        public virtual void Update(GameTime gameTime)
        {
            if (!IsActive)
                return;
        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible)
                return;
        }

        public void AddAnimation(string name, Animation animation)
        {
            // Create a one sequence animation
            Queue<Animation> animationSequence = new Queue<Animation>();
            animationSequence.Enqueue(animation);

            AddAnimationSequence(name, animationSequence);
        }

        public void AddAnimationSequence(string name, Queue<Animation> animationSequence)
        {
           if(!animations.ContainsKey(name))
           {
               animations.Add(name, animationSequence);
           }
        }


    }
}
