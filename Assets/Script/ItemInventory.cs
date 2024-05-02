using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemInventory : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string itemName;
        public Sprite sprite; // Sprite representing the item
        public bool isCollected; // Flag indicating whether the item has been collected
    }

    public List<Item> itemsToCollect; // List of items to be collected

    private Dictionary<string, Image> itemImages = new Dictionary<string, Image>(); // Dictionary to map item names to their images

    private void Start()
    {
        InitializeInventory();
    }

    private void InitializeInventory()
    {
        // Find all child images under the canvas
        Image[] images = GetComponentsInChildren<Image>(includeInactive: true);

        foreach (Image image in images)
        {
            // Map each image to its corresponding item name
            itemImages.Add(image.gameObject.name, image);

            // Check if the image GameObject name matches an item name in the itemsToCollect list
            Item item = itemsToCollect.Find(i => i.itemName == image.gameObject.name);

            if (item != null)
            {
                // Set the sprite of the image based on the item's sprite
                image.sprite = item.sprite;

                // Set the color of the image based on whether the item is collected or not
                image.color = item.isCollected ? Color.white : Color.black;
            }
        }
    }

    public void CollectItem(string itemName)
    {
        // Find the collected item in the list
        Item item = itemsToCollect.Find(i => i.itemName == itemName);

        if (item != null && !item.isCollected)
        {
            // Mark the item as collected
            item.isCollected = true;

            // Update the corresponding image color to white (indicating collected)
            if (itemImages.ContainsKey(itemName))
            {
                itemImages[itemName].color = Color.white;
            }
            else
            {
                Debug.LogWarning("Image not found for item: " + itemName);
            }

            Debug.Log("Item collected: " + itemName);
        }
        else if (item != null && item.isCollected)
        {
            Debug.LogWarning("Item already collected: " + itemName);
        }
        else
        {
            Debug.LogWarning("Item not found: " + itemName);
        }
    }
}
