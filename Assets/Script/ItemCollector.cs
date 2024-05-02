using UnityEngine;

public class ItemCollector : MonoBehaviour

{
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
        // Here you can add your specific item collection logic
        Debug.Log("Item collected!");

        // For example, increase player's score, update UI, etc.
    }
}


public class PlayerController : MonoBehaviour
{
    public ItemInventory itemInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            // Assuming the item has a unique name (e.g., "Gun", "Folder", etc.) matching the itemName in itemsToCollect
            string itemName = collision.gameObject.name;

            // Collect the item by calling the ItemInventory's CollectItem method
            itemInventory.CollectItem(itemName);

            // Optionally, destroy the collected item GameObject
            Destroy(collision.gameObject);
        }
    }
}
