using CocosSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tiled.Droid.Entities;
using Tiled.Shared;

namespace Tiled
{
    public class MainLayer : CCLayer
    {
        MenuLayer menuLayer;
        GameLayer gameLayer;
        HighScoreLayer highScoreLayer;
        HowToPlayLayer howToPlayLayer;
        YouDiedLayer youDiedLayer;
        VictoryLayer victoryLayer;
        LevelSelectorLayer levelSelectorLayer;

        public MainLayer()
        {
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            this.AddChild(menuLayer = new MenuLayer(this));
        }
         
        public void StartGame(String level_num, int hp, String speed)
        {
            this.RemoveChild(levelSelectorLayer);
            this.AddChild(gameLayer = new GameLayer(this, level_num, hp, speed));
        }

        public void LevelSelector()
        {
            this.RemoveChild(menuLayer);
            this.AddChild(levelSelectorLayer = new LevelSelectorLayer(this)); 
        }

        public void HighScores()
        {
            this.RemoveChild(menuLayer);
            this.AddChild(highScoreLayer = new HighScoreLayer(this));
        }

        public void HowToPlay()
        {
            this.RemoveChild(menuLayer);
            this.AddChild(howToPlayLayer = new HowToPlayLayer(this));
        }

        public void BackToMenu()
        {
            this.RemoveAllChildren();
            this.AddChild(menuLayer);
        }

        public void Victory(String s, String level, int missed_coins, int lost_lives)
        {
            this.RemoveAllChildren();
            this.AddChild(victoryLayer = new VictoryLayer(this, s, level, missed_coins, lost_lives));
        }

        public void Died()
        {
            this.RemoveAllChildren();
            this.AddChild(youDiedLayer = new YouDiedLayer(this));
        }
    }
}
