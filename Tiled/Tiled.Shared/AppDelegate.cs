﻿using System.Reflection;
using Microsoft.Xna.Framework;
using CocosSharp;
using CocosDenshion;

namespace Tiled.Shared
{
    public class AppDelegate : CCApplicationDelegate
    {
        CCScene scene;
        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {
            application.PreferMultiSampling = false;
            application.ContentRootDirectory = "Content";
            application.ContentSearchPaths.Add("animations");
            application.ContentSearchPaths.Add("fonts");
            application.ContentSearchPaths.Add("sounds");

            CCSize windowSize = mainWindow.WindowSizeInPixels;

            float desiredWidth = 1024.0f;
            float desiredHeight = 768.0f;
            
            CCScene.SetDefaultDesignResolution(desiredWidth, desiredHeight, CCSceneResolutionPolicy.ShowAll);
            
            application.ContentSearchPaths.Add("images/hd");
            CCSprite.DefaultTexelToContentSizeRatio = 2.0f;

            CCScene.SetDefaultDesignResolution(384, 240, CCSceneResolutionPolicy.ShowAll);

            scene = new CCScene(mainWindow);
            MainLayer mainLayer = new MainLayer();
            scene.AddChild(mainLayer);
            mainWindow.RunWithScene(scene);
        }

        public override void ApplicationDidEnterBackground(CCApplication application)
        {
            application.Paused = true;
        }

        public override void ApplicationWillEnterForeground(CCApplication application)
        {
            application.Paused = false;
        }
    }
}