using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string currentPlayerName, bestPlayerName;
    public int bestScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Initialize()
    {
        GameObject bestScoreText = GameObject.Find("Text best score");
        bestScoreText.GetComponent<Text>().text = $"Best Score: {bestPlayerName} : {bestScore}";
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);

        if (sceneId == 1)
        {
            currentPlayerName = GameObject.Find("InputField Name").GetComponent<TMP_InputField>().text;
            // TODO: what to do if the player doesn't enter a name?
        }
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
