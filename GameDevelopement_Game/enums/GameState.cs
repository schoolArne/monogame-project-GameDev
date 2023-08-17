using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopement_Game.enums
{
    public static class GameState
    {
        public enum CurrentGameState
        {
            main_menu = 0,
            level_1 = 1,
            level_2 = 2,
            gameover = 3,
            finished = 4,
            level_3 = 5
        }
    }
}
