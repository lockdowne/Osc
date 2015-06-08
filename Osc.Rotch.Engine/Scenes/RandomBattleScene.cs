using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Osc.Rotch.Engine.Inputs;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Osc.Rotch.Engine.Entities;
using System.Runtime.Serialization;
using Osc.Rotch.Engine.DataStructures;

namespace Osc.Rotch.Engine.Scenes
{
    [DataContract(Namespace="")]
    public class RandomBattleScene
    {
        [DataMember]
        private List<Character> characterPool = new List<Character>();

        [DataMember]
        public Tilemap Tilemap { get; set; }

        [DataMember]
        public Layer<TilePlaceable> PlaceableLayer { get; set; }

        [IgnoreDataMember]
        public CharacterCollection AllCharacters { get; set; }

        public void CreateRandomCharacters()
        {
            // TODO: Apply algorithm to select from character pool                        
        }
    }
}
