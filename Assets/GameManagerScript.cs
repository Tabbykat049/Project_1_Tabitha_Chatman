using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;

    void Start()
    {
        // Start with the cursor hidden and locked
        SetCursorState(false);
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        // Unlock the cursor ONLY ONCE here
        SetCursorState(true);
    }

    private void SetCursorState(bool isMenuOpen)
    {
        Cursor.visible = isMenuOpen;
        Cursor.lockState = isMenuOpen ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void restart()
    {
        // Reset timescale just in case you paused the game
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has Quit The Game");
    }
}