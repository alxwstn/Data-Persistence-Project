using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreData highScoreData;
    public ScoreData currentScoreData;
    public static GameManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
        DontDestroyOnLoad(instance);

    }

    [Serializable]
    public class ScoreData
    {
        public int score;
        public string user;
    }
}
