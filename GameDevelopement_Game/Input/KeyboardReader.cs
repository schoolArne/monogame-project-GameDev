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

        public bool isStandingStill { get; set; }

        public bool isJumping { get; set; }
        public int jumpTimer { get; set; }

        public KeyboardReader(int LookDirection, bool isStandingStill)
        {
            this.lookDirection = LookDirection;
            this.isStandingStill = isStandingStill;
            isJumping = false;
            jumpTimer = 0;
        }
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                isStandingStill = false;
                direction.X -= 1;
                this.lookDirection = -1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                isStandingStill = false;
                direction.X += 1;
                this.lookDirection = 1;
            }
            if (state.IsKeyDown(Keys.Space) /*&& isJumping == false*/)
            {
                isStandingStill = false;
                direction.Y -= 2;
            }
            
            if (state.IsKeyDown(Keys.Down))
            {
                isStandingStill = false;
                direction.Y += 1;
            }
            
            if (state.IsKeyUp(Keys.Left) && state.IsKeyUp(Keys.Right) && state.IsKeyUp(Keys.Up) && state.IsKeyUp(Keys.Down))
            {
                isStandingStill = true;
            }
            return direction;
        }


    }
}
