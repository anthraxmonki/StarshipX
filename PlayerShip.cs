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
        const float fSpeed5 = 750f;

        const float fSpeedBase = 140f;
        float fSpeedModifier;

        public DirectionState currentDirectionState = DirectionState.NoDirection;
        public enum DirectionState
        {
            UpLeft, Up, UpRight,
            Right,
            DownRight, Down, DownLeft,
            Left,
            NoDirection
        
        }




        public void LoadContent(ContentManager thecontentManager, string sfileName, float fgetsetScale)  
        {

            base.LoadContent(thecontentManager, sfileName, fgetsetScale);
            fSpeedModifier = fSpeed5;

        }



        public void SetSpritePosition(Vector2 v2spriteStartPosition)
        {

            v2ShipPosition = v2spriteStartPosition;
        }








        public void Update(GameTime thegameTime, KeyboardState kscurrentState, GamePadState gpcurrentState)
        {

            SetDirectionState(kscurrentState, gpcurrentState);
            MoveDirection(thegameTime);



            //GetDirectionInput(thegameTime, kscurrentState, gpcurrentState);












            base.Update(thegameTime);
        }





        //Multi-directionals MUST be updated first
        public void SetDirectionState(KeyboardState kscurrentState, GamePadState gpcurrentState)
        {
            //
            //UPLEFT UPLEFT UPLEFT UPLEFT
            if (kscurrentState.IsKeyDown(Keys.Up) 
                && kscurrentState.IsKeyDown(Keys.Left))
            {
                currentDirectionState = DirectionState.UpLeft;       
            }
            //
            ////UPRIGHT UPRIGHT UPRIGHT UPRIGHT
            else if (kscurrentState.IsKeyDown(Keys.Up)
                && kscurrentState.IsKeyDown(Keys.Right))
            {
                currentDirectionState = DirectionState.UpRight;
            }

            //DOWNRIGHT DOWNRIGHT DOWNRIGHT DOWNRIGHT
            else if (kscurrentState.IsKeyDown(Keys.Right)
                && kscurrentState.IsKeyDown(Keys.Down))
            {
                currentDirectionState = DirectionState.DownRight;
            }
            
            //DOWNLEFT DOWNLEFT DOWNLEFT DOWNLEFT
            else if (kscurrentState.IsKeyDown(Keys.Left)
                && kscurrentState.IsKeyDown(Keys.Down))
            {
                currentDirectionState = DirectionState.DownLeft;
            }


            //
            //UP UP UP UP UP
            else if (kscurrentState.IsKeyDown(Keys.Up))
            {
                currentDirectionState = DirectionState.Up;
            }
            //RIGHT RIGHT RIGHT RIGHT
            else if (kscurrentState.IsKeyDown(Keys.Right))
            {
                currentDirectionState = DirectionState.Right;
            }
            //DOWN DOWN DOWN DOWN
            else if (kscurrentState.IsKeyDown(Keys.Down))
            {
                currentDirectionState = DirectionState.Down;
            }
            //LEFT LEFT LEFT LEFT
            else if (kscurrentState.IsKeyDown(Keys.Left))
            {
                currentDirectionState = DirectionState.Left;
            }

        }








        public void MoveDirection(GameTime thegameTime)
        {
            //UPLEFT UPLEFT UPLEFT
            if (currentDirectionState == DirectionState.UpLeft)
            {
                v2ShipPosition += new Vector2(
                    -1 * (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds),
                    -1 * (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds));

                currentDirectionState = DirectionState.NoDirection;
            }

            //UPRIGHT UPRIGHT UPRIGHT UPRIGHT
            else if (currentDirectionState == DirectionState.UpRight)
            {
                v2ShipPosition += new Vector2( 
                    (fSpeedBase + fSpeedModifier)      * (float)(thegameTime.ElapsedGameTime.TotalSeconds), 
                    -1 * (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds));

                currentDirectionState = DirectionState.NoDirection;
            }

            //DOWNRIGHT DOWNRIGHT DOWNRIGHT DOWNRIGHT
            else if (currentDirectionState == DirectionState.DownRight)
            {
                v2ShipPosition += new Vector2(
                    (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds),
                    (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds)
                    );
                currentDirectionState = DirectionState.NoDirection;
            }

            //DOWNLOEFT DOWNLEFT DOWNLEFT DOWNLEFT
            else if (currentDirectionState == DirectionState.DownLeft)
            {
                v2ShipPosition += new Vector2(
                    -1 * (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds),
                    (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds)
                    );
                currentDirectionState = DirectionState.NoDirection;
            }




            //UP UP UP UP
            else if (currentDirectionState == DirectionState.Up)
            {
                v2ShipPosition += new Vector2(
                    0,
                    -1 * (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds));

                currentDirectionState = DirectionState.NoDirection;
            }
            //RIGHT RIGHT RIGHT RIGHT
            else if (currentDirectionState == DirectionState.Right)
            {
                v2ShipPosition += new Vector2((fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds), 0);
                currentDirectionState = DirectionState.NoDirection;
            
            }
            //DOWN DOWN DOWN DOWN
            else if (currentDirectionState == DirectionState.Down)
            {
                v2ShipPosition += new Vector2(0, (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds));
                currentDirectionState = DirectionState.NoDirection;
            }
            //LEFT LEFT LEFT LEFT
            else if (currentDirectionState == DirectionState.Left)
            {
                v2ShipPosition += new Vector2(-1 * (fSpeedBase + fSpeedModifier) * (float)(thegameTime.ElapsedGameTime.TotalSeconds), 0);
                currentDirectionState = DirectionState.NoDirection;
            }




        }


    




  


        public override void Draw(SpriteBatch thespriteBatch)
        {


            thespriteBatch.Draw(tSprite, v2ShipPosition, rSpriteSource, Color.White);

            base.Draw(thespriteBatch);
        }








    //
    }
//
}
