using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

using UnityEngine.UI;

public class PhoneTouch : MonoBehaviour
{
    /* Screen Touch
    private Touch touch;
    public Text displaytext;
    public float timeTouchEnd;
    public float displayTouchTime = 0.5f;
    */

    /* DRAG TOUCH 
    public Text directionalText;
    private Touch touch;
    private Vector2 startPosition, endPosition;
    public string direction;
    */

    /* Multi Touch */

    public Text multiTouchInfoDisplay;
    public int maxTabCount = 0;
    private string multiTouchInfo;
    public Touch touch;

    private void Update()
    {
        /* Touch Input On Screen
        #region Touch Input On Screen
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary)
            {
                displaytext.text = touch.phase.ToString();
                timeTouchEnd = Time.time;
            }
        }
        else if(Time.time - timeTouchEnd > displayTouchTime)
        {
            displaytext.text = "";
        }
        #endregion
        */

        /* Drag Touch 

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {

                endPosition = touch.position;
                float x = startPosition.x - endPosition.x;
                float y = startPosition.y - endPosition.y;

                
                if(Mathf.Abs(x) > Mathf.Abs(y))
                {
                    direction = x > 0 ? "right" : "left";
                }
                else if(Mathf.Abs(y) >= Mathf.Abs(y) || Mathf.Abs(y) <= Mathf.Abs(y))
                {
                    direction = y > 0 ? "down" : "up";
                }
                else
                {
                    direction = "Tapped";   
                }
            }
        }

        directionalText.text = direction;
        */

        multiTouchInfo = string.Format("Max Tab Count: {0} \n ", maxTabCount);

        if(Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++){
                touch = Input.GetTouch(i);

                multiTouchInfo += string.Format("Touch: {0} - position {1} - Tab Count {2} - Finger ID: {3} \n Radius: {4} ({5}%) \n",
                                                 i, touch.position, touch.tapCount, touch.fingerId, touch.radius, 
                                                ((touch.radius / (touch.radius + touch.radiusVariance)) * 100f).ToString("F1"));
                
                if(touch.tapCount > maxTabCount) {
                    
                    maxTabCount = touch.tapCount;
                }
            }
        }
        multiTouchInfoDisplay.text = multiTouchInfo;
    }

}
