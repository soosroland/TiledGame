﻿using CocosSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Tiled.Droid.Entities;

namespace Tiled
{
    class LevelSelectorLayer : CCNode
    {
        MainLayer _mainLayer;
        Button backGround;
        Button level_left;
        Button level_right;
        Button difficulty_left;
        Button difficulty_right;
        Button speed_left;
        Button speed_right;
        Button start;
        CCLabel level;
        CCLabel difficulty;
        CCLabel speed;
        CCEventListenerTouchAllAtOnce touchListener;
        List<String> level_List;
        List<String> difficulty_List;
        List<String> speed_List;
        int actual_difficulty;
        int actual_speed;
        int actual_level;

        public LevelSelectorLayer(MainLayer mainLayer)
        {
            _mainLayer = mainLayer;

            backGround = new Button("background.png");
            backGround.Position = new CCPoint(192, 120);
            AddChild(backGround);

            level_List = new List<String>();
            level_List.Add("Level 1");
            level_List.Add("Level 2");
            level_List.Add("Level 3");
            level_List.Add("Level 4");
            level_List.Add("Level 5");
            level_List.Add("Level 6");
            level_List.Add("Level 7");
            level_List.Add("Level 8");
            level_List.Add("Level 9");
            actual_level = 0;

            difficulty_List = new List<String>();
            difficulty_List.Add("easy");
            difficulty_List.Add("normal");
            difficulty_List.Add("hard");
            difficulty_List.Add("realistic");
            actual_difficulty = 1;

            speed_List = new List<String>();
            speed_List.Add("slow");
            speed_List.Add("normal");
            speed_List.Add("fast");
            actual_speed = 1;

            level_left = new Button("arrow_left.png");
            level_left.Position = new CCPoint(130, 170);
            AddChild(level_left);

            level = new CCLabel("Level 1", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            level.Color = new CCColor3B(0, 0, 0);
            level.Position = new CCPoint(200, 170);
            AddChild(level);

            level_right = new Button("arrow_right.png");
            level_right.Position = new CCPoint(270, 170);
            AddChild(level_right);

            difficulty_left = new Button("arrow_left.png");
            difficulty_left.Position = new CCPoint(130, 120);
            AddChild(difficulty_left);

            difficulty = new CCLabel(difficulty_List[actual_difficulty], "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            difficulty.Color = new CCColor3B(0, 0, 0);
            difficulty.Position = new CCPoint(200, 120);
            AddChild(difficulty);

            difficulty_right = new Button("arrow_right.png");
            difficulty_right.Position = new CCPoint(270, 120);
            AddChild(difficulty_right);

            speed_left = new Button("arrow_left.png");
            speed_left.Position = new CCPoint(130, 70);
            AddChild(speed_left);

            speed = new CCLabel(speed_List[actual_speed], "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            speed.Color = new CCColor3B(0, 0, 0);
            speed.Position = new CCPoint(200, 70);
            AddChild(speed);

            speed_right = new Button("arrow_right.png");
            speed_right.Position = new CCPoint(270, 70);
            AddChild(speed_right);

            start = new Button("continue.png");
            start.Scale = 1.5f;
            start.Position = new CCPoint(200, 30);
            AddChild(start);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            Schedule(
               (dt) =>
               {
                   if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                   {
                       _mainLayer.BackToMenu();
                   }
               }
           );

            touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = HandleInput;
            AddEventListener(touchListener, this);
        }

        private void HandleInput(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                foreach (var touch in touches)
                {
                    if (start.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                    {
                        int hp=5;
                        switch (actual_difficulty)
                        {
                            case 0:
                                hp = 10;
                                break;
                            case 1:
                                hp = 5;
                                break;
                            case 2:
                                hp = 3;
                                break;
                            case 3:
                                hp = 1;
                                break;
                            default:
                                break;
                        }
                        _mainLayer.StartGame((actual_level+1).ToString(),hp, speed_List[actual_speed]);
                    }
                    else if (level_left.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                    {
                        if (actual_level > 0)
                        {
                            actual_level--;
                        }
                        else
                        {
                            actual_level = level_List.Count - 1;
                        }
                        level.Text = level_List[actual_level];
                    }
                    else if (level_right.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                    {
                        if (actual_level < level_List.Count - 1)
                        {
                            actual_level++;
                        }
                        else
                        {
                            actual_level = 0;
                        }
                        level.Text = level_List[actual_level];
                    }
                    else if (difficulty_left.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                    {
                        if (actual_difficulty > 0)
                        {
                            actual_difficulty--;
                        }
                        else
                        {
                            actual_difficulty = difficulty_List.Count - 1;
                        }
                        difficulty.Text = difficulty_List[actual_difficulty];
                    }
                    else if (difficulty_right.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                    {
                        if (actual_difficulty < difficulty_List.Count - 1)
                        {
                            actual_difficulty++;
                        }
                        else
                        {
                            actual_difficulty = 0;
                        }
                        difficulty.Text = difficulty_List[actual_difficulty];
                    }
                    else if (speed_left.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                    {
                        if (actual_speed > 0)
                        {
                            actual_speed--;
                        }
                        else
                        {
                            actual_speed = speed_List.Count - 1;
                        }
                        speed.Text = speed_List[actual_speed];
                    }
                    else if (speed_right.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                    {
                        if (actual_speed < speed_List.Count - 1)
                        {
                            actual_speed++;
                        }
                        else
                        {
                            actual_speed = 0;
                        }
                        speed.Text = speed_List[actual_speed];
                    }
                }
            }
        }
    }
}
