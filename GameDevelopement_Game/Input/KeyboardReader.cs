using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameDevelopement_Game.Input
{
    public class KeyboardReader:IInputReader
    {
        public int lookDirection { get; set; }

        public KeyboardReader(int LookDirection)
        {
            this.lookDirection = LookDirection;
        }
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
                this.lookDirection = -1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 1;
                this.lookDirection = 1;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y -= 2;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
            }
            direction.Y += 1;
            return direction;
        }

    }
}
