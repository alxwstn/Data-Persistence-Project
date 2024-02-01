using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI bestScore;
    public void Start()
    {
        SetHighScoreText();
    }

    private void SetHighScoreText()
    {
        bestScore.text = GameManager.instance.GetBestScoreText();
        
    }
    public void StartClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitClicked()
    {
        {
            //MainManager.Instance.SaveColor();
            Debug.Log("Closing application...");
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        }

    }

    public void NameEntered(string name)
    {
        GameManager.instance.SetCurrentName(name);
    }
}
