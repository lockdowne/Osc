#region File Descrption
//------------------------------
//  Character.cs
//
//  Character object


//TODO: need to add a method to select set of animations depending on character job
//TODO: need to select animation depending on current action
//POSSILECHANGE: contructor "Position" is most likely going to be moved out when we get a character placement menu

//------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Osc.Rotch.Engine.Common;
using Microsoft.Xna.Framework;
#endregion
using Microsoft.Xna.Framework.Graphics;


namespace Osc.Rotch.Engine.Entities
{
    public class Character : Sprite
    {
        #region Fields

        private int level;
        private int health;
        private int healthPool;
        private int mana;
        private int manaPool;
        private int stamina;
        private int staminaPool;
        private int speed;
        private int physicalResistance;
        private int magicalResistance;
        private int attackDamage;
        private int magicDamage;
        private int physicalEvasion;
        private int magicalEvasion;
        private int critical;
        private int movement;

        //private int maxHealth;
        //private int maxMana;
        //private int maxStamina;
        //private int maxSpeed;
        //private int maxPhysicalResistance;
        //private int maxMagicalResistance;
        //private int maxAttackDamage;
        //private int maxMagicalDamage;
        //private int maxPhysicalEvasion;
        //private int maxMagicalEvasion;
        //private int maxCrital;
        //private int maxMovement;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the character's name
        /// </summary>
        public string CharacterName { get; set; }

        /// <summary>
        /// Gets or Sets the character's current level 
        /// </summary>
        public int Level { get { return level; } set { level = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's current health points
        /// </summary>
        public int Health { get { return health; } set { health = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's Health Pool
        /// </summary>
        public int HealthPool { get { return healthPool; } set { healthPool = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }


        /// <summary>
        /// Gets or Sets the character's current mana points
        /// </summary>
        public int Mana { get { return mana; } set { mana = (int)MathHelper.Clamp(value, 0, ManaPool); } }

        /// <summary>
        /// Gets or Sets the character's Mana Pool
        /// </summary>
        public int ManaPool { get { return manaPool; } set { manaPool = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's current stamina points
        /// </summary>
        public int Stamina { get { return stamina; } set { stamina = (int)MathHelper.Clamp(value, 0, staminaPool); } }

        /// <summary>
        /// Gets or Sets the character's stamina pool
        /// </summary>
        public int StaminaPool { get { return staminaPool; } set { staminaPool = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's speed
        /// </summary>
        public int Speed { get { return speed; } set { speed = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's Turn Counter  
        /// </summary>
        public int TurnCounter { get; set; }

        /// <summary>
        /// Gets or Sets the character's physical resistance
        /// </summary>
        public int PhysicalResistance { get { return physicalResistance; } set { physicalResistance = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's spell resistance
        /// </summary>
        public int MagicalResistance { get { return magicalResistance; } set { magicalResistance = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's attack damage 
        /// </summary>
        public int AttackDamage { get { return attackDamage; } set { attackDamage = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's magic damage
        /// </summary>
        public int MagicDamage { get { return magicDamage; } set { magicDamage = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's critical 
        /// </summary>
        public int Critical { get { return critical; } set { critical = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's physical evasion
        /// </summary>
        public int PhysicalEvasion { get { return physicalEvasion; } set { physicalEvasion = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's magical evasion 
        /// </summary>
        public int MagicalEvasion { get { return magicalEvasion; } set { magicalEvasion = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }

        /// <summary>
        /// Gets or Sets the character's movement
        /// </summary>
        public int Movement { get { return movement; } set { movement = (int)MathHelper.Clamp(value, 0, Int32.MaxValue); } }
        
        public int ActionToken { get; set; }

        public int MoveToken { get; set; }

        public float DepthValue { get; set; }

        #endregion


        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible)
                return;

            if (spriteBatch == null)
                return;

            if (CurrentAnimation == null)
                return;

            spriteBatch.Draw(CurrentAnimation.Texture, Position, CurrentAnimation.FrameBounds, Tint, Rotation, Vector2.Zero, Scale, SpriteEffects.None, DepthValue);
        }         
    } 
}
