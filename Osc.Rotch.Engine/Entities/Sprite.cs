using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Osc.Rotch.Engine.Common;
using System.Runtime.Serialization;

namespace Osc.Rotch.Engine.Entities
{
    [DataContract]
    public class Sprite : IEntity
    {
        [DataMember]
        private Dictionary<string, IList<Animation>> Animations { get; set; }

        [IgnoreDataMember]
        private Queue<string> nextAnimation = new Queue<string>();

        [IgnoreDataMember]
        private int animationIndex;

        /// <summary>
        /// Gets or sets the unqiueID 
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of sprite
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of sprite
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets the current animation string that is being played
        /// </summary>
        [DataMember]
        public string CurrentAnimationSequence { get; private set; }

        /// <summary>
        /// Gets or sets the pixel position of sprite
        /// </summary>
        [DataMember]
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the color overlay of sprite
        /// </summary>
        [DataMember]
        public Color Tint { get; set; }

        /// <summary>
        /// Gets or sets the scale of sprite
        /// </summary>
        [DataMember]
        public float Scale { get; set; }

        /// <summary>
        /// Gets or sets the rotation of sprite
        /// </summary>
        [DataMember]
        public float Rotation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public Rectangle Bounds
        {
            get { return CurrentAnimation == null ? Rectangle.Empty : new Rectangle((int)Position.X, (int)Position.Y, CurrentAnimation.FrameBounds.Width, CurrentAnimation.FrameBounds.Height); }
        }

        /// <summary>
        /// Gets the current animation sequence that is being played
        /// </summary>
        [IgnoreDataMember]
        public Animation CurrentAnimation
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentAnimationSequence))
                    return null;

                if (AnimationIndex < 0)
                    return null;

                return Animations[CurrentAnimationSequence][AnimationIndex];
            }
        }

        /// <summary>
        /// Gets the index in the current animation sequence
        /// </summary>
        [IgnoreDataMember]
        public int AnimationIndex
        {
            get { return animationIndex; }
            private set
            {
                if (string.IsNullOrEmpty(CurrentAnimationSequence) || !Animations.ContainsKey(CurrentAnimationSequence)) // Dont need this check as we cant get to this point without a valid current animation sequence
                {
                    animationIndex = -1;
                    return;
                }

                animationIndex = value % Animations[CurrentAnimationSequence].Count;
            }
        }

        /// <summary>
        /// Gets or sets whether sprite should be udpated
        /// </summary>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets whether sprite should be drawn
        /// </summary>
        [DataMember]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Update animation
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            if (!IsActive)
                return;

            // TODO: Handle change in current animation sequence

            // Play current animation in sequence

            if (CurrentAnimation == null)
                return;

            CurrentAnimation.Update(gameTime);

            if (CurrentAnimation.IsAnimationComplete)
            {
                // Need to reset the animation for the next iteration
                CurrentAnimation.Reset();

                // Play next animation in sequence
                AnimationIndex++;

                if (AnimationIndex == 0)
                {
                    // Animation sequence is complete
                    // Check if theres any queued up animations that want to be played
                    // The last animation sequence is the one that will be looped, its up to the wrapper classes to handle when to play animations
                    if (nextAnimation.Count > 0)
                        PlayAnimation(nextAnimation.Dequeue(), true);
                }
            }
        }

        /// <summary>
        /// Draw animation
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible)
                return;

            if (spriteBatch == null)
                return;

            if (CurrentAnimation == null)
                return;

            spriteBatch.Draw(CurrentAnimation.Texture, Position, CurrentAnimation.FrameBounds, Tint, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 0.0f);
        }

        /// <summary>
        /// Add an animation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="animation"></param>
        public void AddAnimation(string name, Animation animation)
        {
            AddAnimation(name, new List<Animation>().Populate(animation));
        }

        /// <summary>
        /// Add an animation sequence
        /// </summary>
        /// <param name="name"></param>
        /// <param name="animationSequence"></param>
        public void AddAnimation(string name, IList<Animation> animationSequence)
        {
            if (Animations == null)
                Animations = new Dictionary<string, IList<Animation>>();

            if (!Animations.ContainsKey(name))
            {
                Animations.Add(name, animationSequence);
            }
        }

        /// <summary>
        /// Queue up the next animation to play
        /// </summary>
        /// <param name="animationName">The name of the animation to play</param>
        /// <param name="forceAnimation">Whether to wait until the current animation should finish before playing the animation</param>
        public void PlayAnimation(string animationName, bool forceAnimation = false)
        {
            if (!Animations.ContainsKey(animationName))
                throw new ArgumentNullException("Animation " + animationName + " does not exist");

            Animations[animationName].ForEach(a => a.Reset());

            if (forceAnimation || string.IsNullOrEmpty(CurrentAnimationSequence))
                CurrentAnimationSequence = animationName;
            else
                nextAnimation.Enqueue(animationName);
        }
    }
}
