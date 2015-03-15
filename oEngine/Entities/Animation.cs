using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace oEngine.Entities
{
    public class Animation : IEntity, ITexture
    {
        private Rectangle mainFrame;

        private float frameTimer;

        private int currentFrame;

        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TextureName { get; set; }

        /// <summary>
        /// Gets or sets the spritesheet texture
        /// </summary>
        [IgnoreDataMember]
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Gets or sets the length of time to stay on a frame
        /// </summary>
        public float FrameDuration { get; set; }

        /// <summary>
        /// Gets or sets the number of frames in spritesheet to iterate through
        /// </summary>
        public int FrameCount { get; set; }

        /// <summary>
        /// Gets or sets the current frame being drawn
        /// </summary>
        public int CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                currentFrame = (int)MathHelper.Clamp(value, 0, FrameCount - 1);
            }
        }

        /// <summary>
        /// Gets bounds of current frame in animation sequence
        /// </summary>
        public Rectangle FrameBounds
        {
            get { return new Rectangle(mainFrame.X + (mainFrame.Width * CurrentFrame), mainFrame.Y, mainFrame.Width, mainFrame.Height); }
        }

        public event Action AnimationComplete;

        /// <summary>
        /// Update animation by current frame
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(frameTimer > FrameDuration)
            {
                frameTimer = 0.0f;

                CurrentFrame = (CurrentFrame + 1) % FrameCount;      
          
                if(CurrentFrame == 0)
                {
                    // Animation sequence completed
                    if(AnimationComplete != null)
                    {
                        AnimationComplete();
                    }
                }
            }
        }

        public void Initialize(int x, int y, int width, int height, int frameCount, float frameDuration = 0.2f)
        {
            mainFrame = new Rectangle(x, y, width, height);

            FrameCount = frameCount;

            FrameDuration = frameDuration;
        }

    }
}
