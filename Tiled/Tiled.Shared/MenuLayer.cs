using System;
using System.Collections.Generic;
using System.Net.Sockets;
using CocosSharp;
using Microsoft.Xna.Framework;
using Tiled.Droid.Entities;

namespace Tiled.Shared
{
    public class MenuLayer : CCLayerColor
    {
        //CCLabel label;
        Button levels;
        Button highscores;
        Button howtoplay;
        Button backGround;
        MainLayer _mainLayer;
        NetworkStream serverStream;
        int sajt = 0;
        public MenuLayer(MainLayer gameLayer)
            : base(CCColor4B.Blue)
        {
            _mainLayer = gameLayer;

            backGround = new Button("background");
            backGround.Position = new CCPoint(192, 120);
            AddChild(backGround);

            levels = new Button("LevelSelect");
            levels.Scale = 2;
            levels.Position = new CCPoint(192, 150);
            AddChild(levels);

            highscores = new Button("HighScores");
            highscores.Scale = 2;
            highscores.Position = new CCPoint(192, 90);
            AddChild(highscores);
            
            howtoplay = new Button("HowToPlay");
            howtoplay.Scale = 2;
            howtoplay.Position = new CCPoint(192, 30);
            AddChild(howtoplay);

            //Connect to server
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            //clientSocket.Connect("127.0.0.1", 8888);
            var tcpClient = new TcpClient("10.0.2.2", 8888);
            serverStream = tcpClient.GetStream();

        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;
   
            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            foreach (var touch in touches)
            {
                if (levels.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                {
                    _mainLayer.LevelSelector();
                }
                else if (highscores.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                {
                    byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Highscores   " + sajt++);
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    _mainLayer.HighScores();
                }
                else if (howtoplay.sprite.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                {
                    _mainLayer.HowToPlay();
                }
            }
        }
    }
}

