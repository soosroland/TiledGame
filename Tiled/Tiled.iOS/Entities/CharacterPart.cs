using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CocosSharp;

namespace Tiled.Droid.Entities
{
    public class CharacterPart : Entities
    {
        public CCSprite sprite;

        public CharacterPart(String s, String part) : base()
        {
            sprite = new CCSprite(s + part + ".png");
            // Center the Sprite in this entity to simplify
            // centering the Ship on screen
            //sprite1.AnchorPoint = CCPoint.AnchorMiddle;
            //this.AddChild(sprite);

            /*sprite2 = new CCSprite(s + part + ".png");
            // Center the Sprite in this entity to simplify
            // centering the Ship on screen
            //sprite2.AnchorPoint = CCPoint.AnchorMiddle;
            this.AddChild(sprite2);

            sprite3 = new CCSprite(s + part + ".png");
            // Center the Sprite in this entity to simplify
            // centering the Ship on screen
            //sprite3.AnchorPoint = CCPoint.AnchorMiddle;
            this.AddChild(sprite3);

            sprite4 = new CCSprite(s + part + ".png");
            // Center the Sprite in this entity to simplify
            // centering the Ship on screen
            //sprite4.AnchorPoint = CCPoint.AnchorMiddle;
            this.AddChild(sprite4);*/

        }

        public override void MoveX(int x)
        {
            sprite.PositionX += x;
            /*sprite2.PositionX += x;
            sprite3.PositionX += x;
            sprite4.PositionX += x;*/
        }

        public override void MoveY(int y)
        {
            sprite.PositionY += y;
            /*sprite2.PositionY += y;
            sprite3.PositionY += y;
            sprite4.PositionY += y;*/
        }
    }
}