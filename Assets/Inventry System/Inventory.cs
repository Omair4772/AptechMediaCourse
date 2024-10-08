using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<IItem> items;

    void Start()
    {
        items = new List<IItem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){

            foreach (var item in items)
            {
                print(item.Name);
            }
        }

    }


    public void AddItem(IItem item)
    {
        items.Add(item);
        Debug.Log($"{item.Name} added to inventory.");
    }

    public void RemoveItem(IItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"{item.Name} removed from inventory.");
        }
    }
    public void UseItem(IItem item)
    {
        if (items.Contains(item))
        {
            item.UseItem();
            items.Remove(item); // Assuming items are one-time use
        }
        else
        {
            Debug.Log("Item not found in inventory.");
        }
    }

    public void PickupItem(IItem item)
    {
        AddItem(item);
    }
}
