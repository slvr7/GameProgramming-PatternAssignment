using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceSpace;
using UnityEngine.UI;

public class ServiceManager
{
    public TimeManager t = new TimeManager();
    public ScoreManager s = new ScoreManager();

    public void Init()
    {
        s.initialize();
        t.initialize();
    }

    public void Update()
    {
        s.Update();
        t.Update();
    }

    public void GameOver()
    {
        s.clearScore();
        t.clearTime();
    }

}
