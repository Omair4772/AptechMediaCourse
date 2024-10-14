using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimRigControl : MonoBehaviour
{

    public MultiAimConstraint aimRig;
    public TwoBoneIKConstraint secondHandRig;


    private void Awake()
    {
        aimRig.weight = 0f;
        secondHandRig.weight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        bool aiming = Input.GetButton("Fire1") || Input.GetButton("Fire2");
        
        if (aiming)
        {
            aimRig.weight = 1f;
            secondHandRig.weight = 1f;
        }
        if (!aiming)
        {
            aimRig.weight = 0f;
            secondHandRig.weight = 0f;
        }
    }
}
