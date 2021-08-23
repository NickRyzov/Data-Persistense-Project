using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public InputField inputField;
    public Text highscoreText;
    public Text pretenderText;

    private void Awake()
    {
        inputField.onEndEdit.AddListener(ChangeName);
    }
    void Start()
    {
        Display();
    }



    public void StartGame()
    {
        print(Store.PLAYER_NAME);
        if (Store.PLAYER_NAME != null && Store.PLAYER_NAME!="")
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {

#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        Application.Quit();
    }

    public void ChangeName(string name)
    {
        print("name added " + name);
        Store.PLAYER_NAME = name;
        pretenderText.text = "Challenger: " + name;
    }

    

    public void Display()
    {
        highscoreText.text = "BestScore: " + Store.CHAMPION_NAME + ": " + Store.HIGHSCORE;
        pretenderText.text = "Challenger: " + Store.PLAYER_NAME;
    }
}
