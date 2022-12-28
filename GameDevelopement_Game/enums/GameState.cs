using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.enums
{
    public abstract class GameState
    {
        enum CurrentGameState
        {
            main_menu,
            level_1,
            level_2,
            gameover
        }
    }
}
