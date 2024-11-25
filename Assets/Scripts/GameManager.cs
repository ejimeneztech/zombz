using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton Instance

    public string startSceneName = "StartScene";
    public string gameSceneName = "MainGameScene";
    public string gameOverSceneName = "GameOverScene";
    public string successSceneName = "SuccessScene";

    private void Awake()
    {
        // Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate GameManager
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    public void ShowStartScreen() => SceneManager.LoadScene(startSceneName);
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;                  
    }

    public void GameOver() => SceneManager.LoadScene(gameOverSceneName);
    public void Success() => SceneManager.LoadScene(successSceneName);
    public void RestartGame() => SceneManager.LoadScene(gameSceneName);
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
