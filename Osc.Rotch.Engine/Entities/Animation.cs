using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Osc.Engine.Entities
{
    [DataContract]
    public class Animation : IEntity, ITexture
    {
        [DataMember]
        private Rectangle mainFrame;

        [IgnoreDataMember]
        private float frameTimer;

        private int currentFrame;
        private int playCount;

        /// <summary>
        /// Gets or sets the unique ID
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of animation
        /// </summary>
        [DataMember]
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the description of animation
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the textures name associated with animation that is drawn
        /// </summary>
        [DataMember]
        public string TextureName { get; set; }

        /// <summary>
        /// Gets or sets the spritesheet texture
        /// </summary>
        [IgnoreDataMember]
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Gets or sets the length of time to stay on a frame
        /// </summary>
        [DataMember]
        public float FrameDuration { get; set; }

        /// <summary>
        /// Gets or sets the number of frames in spritesheet to iterate through
        /// </summary>
        [DataMember]
        public int FrameCount { get; set; }

        /// <summary>
        /// Gets the current play count of animation to determine once the animation has completed its sequence
        /// </summary>
        [IgnoreDataMember]
        public int PlayCount
        {
            get { return playCount; }
            private set
            {
                playCount = (int)MathHelper.Clamp(value, 0, Int32.MaxValue);
            }
        }

        /// <summary>
        /// Gets or sets the number of times the animation should repeat before continuing
        /// </summary>
        [DataMember]
        public int RepeatCount { get; set; }

        /// <summary>
        /// Gets or sets the current frame being drawn
        /// </summary>
        [IgnoreDataMember]
        public int CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                currentFrame = (int)MathHelper.Clamp(value, 0, FrameCount - 1);
            }
        }

        [IgnoreDataMember]
        public bool IsAnimationComplete
        {
            get { return playCount >= RepeatCount; }
        }

        /// <summary>
        /// Gets bounds of current frame in animation sequence
        /// </summary>
        [IgnoreDataMember]
        public Rectangle FrameBounds
        {
            get { return new Rectangle(mainFrame.X + (mainFrame.Width * CurrentFrame), mainFrame.Y, mainFrame.Width, mainFrame.Height); }
        }

        /// <summary>
        /// Update animation by current frame
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (frameTimer > FrameDuration)
            {
                frameTimer = 0.0f;

                CurrentFrame = (CurrentFrame + 1) % FrameCount;

                if (CurrentFrame == 0)
                {
                    // Animation complete
                    PlayCount++;
                }
            }
        }

        /// <summary>
        /// Initializes all required information for animation
        /// </summary>
        /// <param name="textureName">Image local name</param>
        /// <param name="texture">Texture to be drawn</param>
        /// <param name="x">Starting X position on in pixels</param>
        /// <param name="y">Starting Y position on texture in pixels</param>
        /// <param name="width">Width of the frame</param>
        /// <param name="height">Height of the frame</param>
        /// <param name="frameCount">The number of frames in animation</param>
        /// <param name="repeatCount">How many times the sequence should repeat until moving on</param>
        /// <param name="frameDuration">How long a single frame should wait until moving on</param>
        public void Initialize(string textureName, Texture2D texture, int x, int y, int width, int height, int frameCount, int repeatCount = 1, float frameDuration = 0.2f)
        {
            TextureName = textureName;

            Texture = texture;

            mainFrame = new Rectangle(x, y, width, height);

            FrameCount = frameCount;

            RepeatCount = repeatCount;

            FrameDuration = frameDuration;
        }

        /// <summary>
        /// Resets the animation to start from beginning of sequence
        /// </summary>
        public void Reset()
        {
            PlayCount = 0;
            CurrentFrame = 0;
        }

    }
}
