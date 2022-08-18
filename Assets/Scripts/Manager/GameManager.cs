using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Level resetlediðim yer
/// </summary>

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
