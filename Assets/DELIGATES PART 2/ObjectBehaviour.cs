using UnityEngine;
using UnityEngine.Rendering;

public class ObjectBehaviour : MonoBehaviour
{
    public string objectGroup;
    private Vector3 defaultScale = new Vector3(1f, 1f, 1f);
    private float sizeChangeFactor = 0.2f;

    void OnEnable()
    {
        // Subscribe to the event
        ObjectManager.OnObjectCreated += HandleNewObjectCreated;
        print("SUBSCRIBED");
    }

    void OnDisable()
    {
        // Unsubscribe from the event
        ObjectManager.OnObjectCreated -= HandleNewObjectCreated;
        print("UN-SUBSCRIBED");
    }

    public void Initialize(string group)
    {
        objectGroup = group;
        SetColorByGroup(objectGroup);
        transform.localScale = defaultScale; // Reset to default scale
        print("INITIALIZED");
    }

    void SetColorByGroup(string group)
    {
        Color groupColor = Color.white;
        switch (group)
        {
            case "Red":
                groupColor = Color.red;
                break;
            case "Blue":
                groupColor = Color.blue;
                break;
            case "Green":
                groupColor = Color.green;
                break;
        }
        GetComponent<Renderer>().material.color = groupColor;
    }

    void HandleNewObjectCreated(GameObject newObj, string newGroup)
    {
        if (newGroup == objectGroup)
        {
            // Increase size of objects in the same group
            transform.localScale += new Vector3(sizeChangeFactor, sizeChangeFactor, sizeChangeFactor);
            CheckWinningCondition();
        }
        //else
        //{
        //    // Decrease size of objects in different groups
        //    transform.localScale -= new Vector3(sizeChangeFactor, sizeChangeFactor, sizeChangeFactor);
        //    transform.localScale = Vector3.Max(defaultScale, transform.localScale); // Ensure it doesn't shrink too small
        //}
    }

    void CheckWinningCondition()
    {
        print("CHECKING WINING CONDITION");

        if (transform.localScale.x >= 10f)
        {
            Debug.Log(objectGroup + " group has won the game!");
            Time.timeScale = 0;
        }
    }
}


