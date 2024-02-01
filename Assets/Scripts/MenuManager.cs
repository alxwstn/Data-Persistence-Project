using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
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
}