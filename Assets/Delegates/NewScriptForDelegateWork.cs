using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScriptForDelegateWork : MonoBehaviour
{
    public DelegateWork refToDelWork;

    private void OnEnable() {
        refToDelWork.myDelegate += NewFunctionToAddInDel;
    }

    private void OnDisable(){
        refToDelWork.myDelegate -= NewFunctionToAddInDel;
    }
    

    public void NewFunction()
    {
        Debug.Log("Called!");
    }

    public int NewFunctionToAddInDel()
    {
        Debug.Log("My name is : " + gameObject.name);
        return 0;
    }

    private void Start() {
        StartCoroutine(WaitThenCallDel());
    }

    IEnumerator WaitThenCallDel()
    {
        yield return new WaitForSeconds(6f);
        Debug.Log("Routine of another script called!");
        // refToDelWork.myDelegate = FunctionInAnotherDelgateScript;
        // refToDelWork.myDelegate?.Invoke();
        Debug.Log("Routine of another script ended!");
    }

    int FunctionInAnotherDelgateScript()
    {
        Debug.Log("This is another function in another delegate script!");
        return 0;
    }
}
