using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;







namespace StarshipX
{

    class PlayerShip : Sprite
    {


        Vector2 v2ShipPosition;


        const float fSpeed0 = 0f;
        const float fSpeed1 = 150f;
        const float fSpeed2 = 300f;
        const float fSpeed3 = 450f;
        const float fSpeed4 = 600f;

        const float fBaseSpeed = 140f;
        float fSpeedModifier;

        DirectonState currentDirection = DirectonState.NoDirection;
        enum DirectonState
        {
            UpLeft, Up, Upright,
            Right,
            DownRight,Down,DownLeft,
            Left,
            NoDirection
        
        }




        public void LoadContent(ContentManager thecontentManager, string sfileName, float fgetsetScale)  
        {

            base.LoadContent(thecontentManager, sfileName, fgetsetScale);
            fSpeedModifier = fSpeed4;

        }



        public void SetSpritePosition(Vector2 v2spriteStartPosition)
        {

            v2ShipPosition = v2spriteStartPosition;
        }








        public void Update(GameTime thegameTime, KeyboardState kscurrentState, GamePadState gpcurrentState)
        {


            //GetDirectionInput(thegameTime, kscurrentState, gpcurrentState);












            base.Update(thegameTime);
        }








        //public void GetDirectionInput(GameTime thegameTime, KeyboardState kscurrentState, GamePadState gpcurrentState)
        //{
        //    if (kscurrentState.IsKeyDown(Keys.Left)
        //        || gpcurrentState.DPad.Left == ButtonState.Pressed)
        //    {
        //        v2ShipPosition += new Vector2((-1 * (fBaseSpeed + fSpeedModifier))  * (float)(thegameTime.ElapsedGameTime.TotalSeconds), 0);
        //    }
        //    else if (kscurrentState.IsKeyDown(Keys.Right)
        //        || gpcurrentState.DPad.Right == ButtonState.Pressed)
        //    {
        //        v2ShipPosition += new Vector2( (fBaseSpeed + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds), 0);
        //    }

        //    else if (kscurrentState.IsKeyDown(Keys.Up)
        //        || gpcurrentState.DPad.Up == ButtonState.Pressed)
        //    {
        //        v2ShipPosition += new Vector2(0,    (-1 * (fBaseSpeed + fSpeedModifier)) * (float)(thegameTime.ElapsedGameTime.TotalSeconds));
        //    }

        //    else if (kscurrentState.IsKeyDown(Keys.Down)
        //        || gpcurrentState.DPad.Down == ButtonState.Pressed)
        //    {
        //        v2ShipPosition += new Vector2(0, (fBaseSpeed + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds));
        //    }




        //}









        public override void Draw(SpriteBatch thespriteBatch)
        {


            thespriteBatch.Draw(tSprite, v2ShipPosition, rSpriteSource, Color.White);

            base.Draw(thespriteBatch);
        }








    //
    }
//
}
