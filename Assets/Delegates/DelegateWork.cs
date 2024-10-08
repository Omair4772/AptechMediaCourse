using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;

public delegate int WeWroteThis();


public class DelegateWork : MonoBehaviour
{
    
    public event WeWroteThis myDelegate;
    // public Action<int> newDelegate;
    // public Func<string,int> waheed;
    // public UnityEvent newName;

    private void Start() {
        StartCoroutine(WaitToCallFunction());
    }

    IEnumerator WaitToCallFunction()
    {
        yield return new WaitForSeconds(2f);
        // if(myDelegate != null)
        // {
        //     myDelegate();
        // }
        // myDelegate?.Invoke();
        myDelegate += MyFunction;
        myDelegate?.Invoke();
        yield return new WaitForSeconds(2f);
        myDelegate += AnotherFunction;
        myDelegate?.Invoke();
        Debug.Log("Ended!");
    }

    private void OnEnable() {
        
    }

    private void OnDisable() {
        
    }



    int MyFunction()
    {
        Debug.Log("Function");
        return 0;
    }

    int AnotherFunction()
    {
        Debug.Log("Whatever!");
        return 0;
    }

    //public UnityEvent onSomethingHappened;

    // public EventHandler newEventHandler;

    // private void OnEnable() {
    //     myDelegate = PrintValue;
    //     myDelegate += Function1ToAssign;
    //     myDelegate += Function2ToAssign;
    // }

    // private void OnDisable() {
    //     myDelegate -= Function1ToAssign;
    //     myDelegate -= Function2ToAssign;
    // }

    // void Start()
    // {
    //     //myDelegate = PrintValue;
    //     myDelegate(5);
    // }

    // void PrintValue(int value)
    // {
    //     Debug.Log("Value: " + value);
    // }

    // void Function1ToAssign(int x)
    // {
    //     Debug.Log("Function1 "+x);
    // }

    // void Function2ToAssign(int x)
    // {
    //     Debug.Log("Function2 "+x);
    // }
   


    // public Action<int> myAction;

    // private void OnEnable() {
    //     myAction = PrintValue;
    //     myAction += Function1ToAssign;
    //     myAction += Function2ToAssign;
    // }

    // private void OnDisable() {
    //     myAction -= Function1ToAssign;
    //     myAction -= Function2ToAssign;
    // }
    // void Start()
    // {
    //     //myAction = PrintValue;
    //     myAction(5);
    // }

}   


// public class Publisher : MonoBehaviour
// {
//     public event Action<int> OnValueChanged;

//     public void ChangeValue(int newValue)
//     {
//         OnValueChanged?.Invoke(newValue);
//     }
// }

// public class Subscriber : MonoBehaviour
// {
//     public Publisher publisher;

//     void OnEnable()
//     {
//         publisher.OnValueChanged += HandleValueChanged;
//     }

//     void OnDisable()
//     {
//         publisher.OnValueChanged -= HandleValueChanged;
//     }

//     void HandleValueChanged(int value)
//     {
//         Debug.Log("Value changed to: " + value);
//     }

//     public void NewFunction()
//     {
//         Debug.Log("Called!");
//     }
// }

#region  my region

#endregion