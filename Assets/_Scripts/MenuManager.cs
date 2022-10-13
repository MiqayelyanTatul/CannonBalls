using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private const string Game = "Game";
    public void PlayGame()
    {
        Application.LoadLevel(Game);
    } 

    public void ExitGame()
    {
        Application.Quit();
    }
}
