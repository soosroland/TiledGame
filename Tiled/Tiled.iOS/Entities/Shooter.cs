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
    public class Shooter : Entities
    {
        CCSprite sprite;
        int _x=0;
        int _y=0;
        public int _rotation { get; set; }

        public int row { get; set; }
        public int column { get; set; }

        public Shooter(int x, int y, String dir) : base()
        {
            sprite = new CCSprite("cannon.png");
            sprite.AnchorPoint = CCPoint.AnchorMiddle;
            switch (dir)
            {
                case "up":
                    _rotation = 0;
                    break;
                case "right":
                    _rotation = 90;
                    break;
                case "down":
                    _rotation = 180;
                    break;
                case "left":
                    _rotation = 270;
                    break;
                default:
                    _rotation = 0;
                    break;
            }
            sprite.Rotation = _rotation;
            this.AddChild(sprite);
            _x = x;
            _y = y;

            Schedule(FireBullet, interval: 4.0f);

        }

        public override void MoveX(int x)
        {
            this.PositionX += x;
        }

        public override void MoveY(int y)
        {
            this.PositionY += y;
        }

        void FireBullet(float unusedValue)
        {
            Bullet newBullet = BulletFactory.Self.CreateNew();
            newBullet.Rotation = _rotation;
            newBullet.Position = this.Position;
            newBullet.VelocityX = _x;
            newBullet.VelocityY = _y;
        }
    }
}