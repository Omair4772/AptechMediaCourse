using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinDecider : MonoBehaviour
{
   public int redCube, greenCube, blueCube;

    public string winCubeIs;
    public Timer timer;


    private void Update()
    {
        winDecide();
    }

    public void winDecide()
    {
        if (redCube > greenCube && redCube > blueCube)
        {
            if (timer.minutes <= 0 && timer.seconds <= 1)
            {
                winCubeIs = "RED CUBE WINS";
            }
        }
        if (greenCube > redCube && greenCube > blueCube)
        {
            if (timer.minutes <= 0 && timer.seconds <= 1)
            {
                winCubeIs = "GREEN CUBE WINS";
            }
        }
        if (blueCube > redCube && blueCube > greenCube)
        {
            if (timer.minutes <= 0 && timer.seconds <= 1)
            {
                winCubeIs = "BLUE CUBE WINS";
            }
        }
        else
        {
            if(timer.minutes <= 0 && timer.seconds <= 0)
            {
                winCubeIs = "GAME IS DRAW";
            }
        }

        print(winCubeIs);
    }
}
