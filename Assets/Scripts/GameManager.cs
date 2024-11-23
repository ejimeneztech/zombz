using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Scene names (set these in the Inspector or hard-code them)
    public string startSceneName = "StartScene";
    public string gameSceneName = "MainGameScene";
    public string gameOverSceneName = "GameOverScene";
    public string successSceneName = "SuccessScene";

    // Ensure GameManager persists across scenes
    void Awake()
    {
        // Check if another instance of GameManager exists
        if (Object.FindObjectsByType<GameManager>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
    }

    // Transition to the start screen
    public void ShowStartScreen()
    {
        SceneManager.LoadScene(startSceneName);
    }

    // Start the game
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    // Show the game over screen
    public void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }

    // Show the success screen
    public void Success()
    {
        SceneManager.LoadScene(successSceneName);
    }

    // Restart the current game
    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // Useful for testing in the editor
    }
}
