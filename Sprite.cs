using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;




namespace StarshipX
{

    class Sprite
    {

        protected Texture2D tSprite;
        //Vector2 v2SpritePosition = Vector2.Zero;




        public  float fSpriteScale = 1.0f;
        public  Rectangle rSpriteSize;
        public Rectangle rSpriteSource;

        protected float fGetSetScaleSizeSource
        {
            get { return fSpriteScale; }
            set {
                fSpriteScale  = value;
                rSpriteSize   = new Rectangle(0, 0, (int)(tSprite.Width * fGetSetScaleSizeSource), (int)(tSprite.Height * fGetSetScaleSizeSource));
                rSpriteSource = rSpriteSize;  
            }
        }
        
        
        


        public void LoadContent(ContentManager thecontentManager, string sfileName, float fgetsetScale)
        {
            tSprite = thecontentManager.Load<Texture2D>(sfileName);
            fGetSetScaleSizeSource = fgetsetScale;
            

        }







        //public void LoadContent(ContentManager thecontentManager, string sfileName, Vector2 v2setspritePosition)
        //{
        //    tSprite = thecontentManager.Load<Texture2D>(sfileName);
        //    v2SpritePosition = v2setspritePosition;
        //}








        protected virtual void Update(GameTime thegameTime)
        {



           
        }






        public virtual void Draw(SpriteBatch thespriteBatch)
        {




        }











    //
    }
//
}
