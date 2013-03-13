using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;





namespace StarshipX
{

    class SnakeSegment : Sprite
    {


        Vector2 v2CurrentPosition;

        public void LoadContent(ContentManager thecontentManager, string sfileName, float fsetspriteScale)
        {

            base.LoadContent(thecontentManager, sfileName, fsetspriteScale);


            v2CurrentPosition = new Vector2(200, 300);

        }





        public void Update(GameTime thegameTime)
        {

        }



        public void Draw(SpriteBatch thespriteBatch)
        {


            thespriteBatch.Draw(tSprite, v2CurrentPosition, rSpriteSource, Color.White);

        }









    //
    }
//
}
