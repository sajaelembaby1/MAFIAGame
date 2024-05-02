using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float totalTime = 180f; // Total time in seconds (3 minutes)
    private float remainingTime;
    private bool isGameOver = false;

    void Start()
    {
        remainingTime = totalTime;
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                remainingTime = 0;
                isGameOver = true;
                GameOver();
            }

            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        // Perform game over actions here (e.g., show game over screen, change text color)
        Debug.Log("Game Over!");
        timerText.color = Color.red;

        // Restart the game after a delay (e.g., 2 seconds)
        Invoke("RestartGame", 2f);
    }

    void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
