using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDisplay : MonoBehaviour
{

    private void OnDestroy()
    {
        print("Destoryed" + name);
    }
}
