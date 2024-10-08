using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerInteraction : MonoBehaviour
{
    private Inventory inventory;

    public Text healthShow;
   [HideInInspector] public int presentHealth;
    public int maxHealth;
    public int healthToGive;
    public int damage;
    public int indexofList;

    void Start()
    {
        presentHealth = maxHealth;
        inventory = GetComponent<Inventory>();
    }

    void OnTriggerEnter(Collider other)
    {
            IItem item = other.GetComponent<IItem>();
            
            if (item != null)
            {
                inventory.PickupItem(item);
                Destroy(other.gameObject); // Remove the item from the game world
            }
    }

    public void Use()
    {
        if (inventory.items.Any(item => item.Name == "Health Potion"))
        {
            IItem item = inventory.items[indexofList];

            inventory.UseItem(item);
        }
    }
}
