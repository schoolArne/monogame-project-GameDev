using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameDevelopement_Game.Input
{
    public interface IInputReader
    {
        int lookDirection { get; set; }
        Vector2 ReadInput();

    }
}
