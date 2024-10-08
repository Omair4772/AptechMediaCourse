using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class shpereMovements : MonoBehaviour
{

    public List<Transform> cubes;
    public float upPosition = 5;

    public float speed = 5;
    public float delay = 0f;

    private void Start()
    {
       StartCoroutine(ShpereMover());
    }

    #region Move Cube 

    IEnumerator ShpereMover()
    {


        foreach (Transform cube in cubes)
        {
            Vector3 startposition = cube.position;
            Vector3 targetposition = new Vector3(startposition.x, upPosition, startposition.z);

            while (cube.transform.position.y < upPosition)
            {
                //               Move Cube Through Vector3.movetoword         
                //     cube.transform.position = Vector3.MoveTowards(cube.transform.position, targetposition, speed * Time.deltaTime);


                //               Move Cube Through Transform.translate
                //               cube.transform.Translate(Vector3.up * Time.deltaTime , Space.World);

                //               Move Cube Through Transform.position

                yield return null;
            }

            yield return new WaitForSeconds(delay);
        }
    }

    #endregion





}
