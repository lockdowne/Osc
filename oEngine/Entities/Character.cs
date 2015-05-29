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
using oEngine.Common;
using Microsoft.Xna.Framework;
#endregion
using Microsoft.Xna.Framework.Graphics;


namespace oEngine.Entities
{
    public class Character : Sprite
    {
        //TEST REGION
        public Animation deadAnimation { get; set; }
        public bool isDead
        {
            get { return (Health <= 0); }
        }
        public string playString { get; set; }
        //TEST REGION

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
        public int TurnCounter { get; private set; }

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

        /// <summary>
        /// Returns Whether the character has high enough TurnCounter to be considered ready
        /// </summary>
        public bool IsReady { get { return ((TurnCounter > Consts.TurnReady) && !isDead); } }

        /// <summary>
        /// Returns the character's coordinate in relation to the tilemap
        /// </summary>
        public Point Coordinate { get; set; }

        public int ActionToken { get; set; }

        public int MoveToken { get; set; }

        #endregion

        #region Initialization
        public Character(int charSpeed, string characterName)
        {
            Speed = charSpeed;
            CharacterName = characterName;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Used to symbolize a turn has progressed
        /// </summary>
        public void ProgressTurnCounter()
        {
            //potentially need a check to prevent counter from going (ie. stop effects)
            TurnCounter += Speed;
        }

        /// <summary>
        /// Used to symbolize spending TurnCounter needed for action
        /// </summary>
        public void TakingTurn()
        {
            TurnCounter -= Consts.TurnReady;
        }
        #endregion

        //TODO: need to add a method to select set of animations depending on character job

        //TODO: need to select animation depending on current action

        /// <summary>
        /// TEMPORARY METHOD FOR TEST
        /// </summary>
        /// <param name="animation"></param>
        public void AnimationInitialize(Animation animation)
        {
            playString = "default";
            AddAnimation("default", animation);
            PlayAnimation(playString);
            AddAnimation("dead", deadAnimation);
            //Position = new Vector2(float.NaN, float.NaN);
            //IsActive = true;
            //IsVisible = true;
            Scale = 1.0f;
            Tint = Color.White;

        }

        public void SetPositionToGrid(Vector2 inputPosition, int tileWidth, int tileHeight)
        {
            Position = inputPosition;
            Coordinate = MathExtension.IsoPixelsToCoordinate(inputPosition, tileWidth, tileHeight);
        }

        public void SetCoordinateToGrid(Point coordinate, int tileWidth, int tileHeight)
        {
            Coordinate = coordinate;
            Position = MathExtension.IsoCoordinateToPixels(coordinate.X, coordinate.Y, tileWidth, tileHeight) - (new Vector2(Bounds.Width / 2, Bounds.Height));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
