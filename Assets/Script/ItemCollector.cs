using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int collectedItems = 0;
    private const int TotalItemsToCollect = 5;  // Total number of items needed to collect to win

    // This method gets called when another Collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is tagged as an item
        if (other.CompareTag("Item"))
        {
            // Perform item collection logic
            CollectItem(other.gameObject);

            // Destroy the item game object after collecting
            Destroy(other.gameObject);
        }
    }

    // This method handles the item collection logic
    private void CollectItem(GameObject item)
    {
        // Increment the collected items count
        collectedItems++;

        Debug.Log("Item collected! Total items collected: " + collectedItems);

        // Check if all required items are collected
        if (collectedItems >= TotalItemsToCollect)
        {
            // All required items collected, trigger game end (player wins)
            Debug.Log("Congratulations! You collected all items and won the game!");
            EndGame();
        }
    }

    // Function to end the game
    private void EndGame()
    {
        // Load a game over scene or perform other end-game actions
        SceneManager.LoadScene("GameOverScene");
    }
}


