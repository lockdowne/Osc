using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oEngine.Entities;

namespace oGame.Events
{
    public class BattleScreenSomethingSelected
    {

    }

    public class BattleScreenCharacterIsSelected
    {
        public Character character { get; set; }
    }

    public class BattleScreenDeselectedAll
    {

    }

    public class BattleScreenDeselectedCharacter
    {

    }

    public class BattleScreenCharacterIsHovered
    {
        public Character character { get; set; }
    }

    public class BattleScreenCharacterNotHovered
    {

    }

    public class BattleScreenCharacterCollectionNowEmpty
    {

    }

    public class BattleScreenCharacterCollectionNotEmpty
    {

    }

    public class BattleScreenStartingBattleSequence
    {

    }

    public class BattleScreenConfirming
    {

    }

    public class BattleScreenNotConfirming
    {

    }

    public class BattleScreenIsExiting
    {

    }
}
