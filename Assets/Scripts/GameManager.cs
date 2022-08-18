using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void GameOver()
    {
        Invoke("RestartLevel", 1f);
    }

    public void LevelDone()
    {
        Debug.Log("--------LEVEL_WIN--------");
    }

    private void RestartLevel()
    {
        Debug.Log("GAMEOVER");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
