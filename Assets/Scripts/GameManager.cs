using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


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
        LoadHighScore();
        currentScoreData = new ScoreData();

    }

    public void SetCurrentName(string name)
    {
        currentScoreData.user = name;
    }

    public void SetNewScore(int newScore)
    {
        currentScoreData.score = newScore;
        if (newScore > highScoreData.score)
        {
            highScoreData.user = currentScoreData.user;
            highScoreData.score = currentScoreData.score;
            SaveHighScore();
        }

    }

    public void SaveHighScore()
    {
        string json = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            highScoreData = JsonUtility.FromJson<ScoreData>(json);
        }
    }

    public string GetBestScoreText()
    {
        if (instance != null && instance.highScoreData != null)
        {
            return "Best Score: " + instance.highScoreData.user + " : " + instance.highScoreData.score;
        }
        return "Best Score: unclaimed!";
    } 

    [System.Serializable]
    public class ScoreData
    {
        public int score;
        public string user;
    }
}
