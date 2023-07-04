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

        public bool triesToJump { get; set; }
        private int jumpTimer = 0;

        public KeyboardReader(int LookDirection, bool isStandingStill, bool Jump)
        {
            this.lookDirection = LookDirection;
            this.isStandingStill = isStandingStill;
            triesToJump = Jump;
        }
        public Vector2 ReadInput()
        {
            jumpTimer++;
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyUp(Keys.Left) && state.IsKeyUp(Keys.Right) && state.IsKeyUp(Keys.Space))
            {
                isStandingStill = true;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                isStandingStill = false;
                direction.X -= 1;
                this.lookDirection = -1;
                //
                //return direction;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                isStandingStill = false;
                direction.X += 1;
                this.lookDirection = 1;
                //
                //return direction;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                if(jumpTimer > 60)
                {
                    jumpTimer = 0;
                }
                if(jumpTimer < 30)
                {
                    direction.Y -= 1;
                    //return direction;
                }
            }
            if (/*state.IsKeyDown(Keys.Down)*/true)
            {
                if(jumpTimer >= 30)
                {
                    direction.Y += 1;
                    //
                    //return direction;
                }                
            }
            return direction;
        }


    }
}
