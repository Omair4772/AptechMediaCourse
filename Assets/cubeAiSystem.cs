using System.Collections;
using UnityEngine;

public class cubeAiSystem : MonoBehaviour
{
    public float speed = 10f;
    public float range = 10f;

    RaycastHit hit;
    public LayerMask mask;

    public bool booliyan = true;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        StartCoroutine(CubeMover());
    }

    IEnumerator CubeMover()
    {
        int moveDecider = Random.Range(0, 4);

        switch (moveDecider)
        {
            case 0: 
            {
                    // MOVE FORWARD

                 while (booliyan)
                 {
                        print("CASE 1");
                     if (Physics.Raycast(transform.position, transform.forward, out hit, range, mask))
                     {
                            StartCoroutine(ChangingColor());
                            booliyan = false;
                     }
                     else
                     {
                         transform.position += Vector3.forward * speed * Time.deltaTime;
                         yield return null;
                     }
                 }

                    yield return new WaitForSeconds(1f);
                    booliyan = true;
                 break;
            }

            case 1:
                {
                                        //MOVE RIGHT 
                    print("case 2");

                    while (booliyan)
                    {
                        if (Physics.Raycast(transform.position, Vector3.right, out hit, range, mask))
                        {
                            booliyan = false;
                            StartCoroutine(ChangingColor());
                        }
                        else
                        {
                            transform.position += Vector3.right * speed * Time.deltaTime;
                            yield return null;
                        }
                    }
                       yield return new WaitForSeconds(1f);
                       booliyan = true;
                    break;
                }

            case 2:
                {
                                         // MOVE LEFT

                    print("CASE 3");

                    while (booliyan)
                    {
                        if (Physics.Raycast(transform.position, Vector3.left, out hit, range, mask))
                        {
                            booliyan = false;
                            StartCoroutine(ChangingColor());
                        }
                        else
                        {
                            transform.position += Vector3.left * speed * Time.deltaTime;

                            yield return null;
                        }
                    }

                        yield return new WaitForSeconds(1f);
                        booliyan = true;
                    break;
                }

            case 3:
                {
                                            // MOVE BACK
                    print("CASE 4");

                    while (booliyan)
                    {
                        if (Physics.Raycast(transform.position, Vector3.back, out hit, range, mask))
                        {
                            booliyan = false;
                            StartCoroutine(ChangingColor());
                        }
                        else
                        {
                            transform.position += Vector3.back * speed * Time.deltaTime;
                            yield return null;
                        }

                    }
                    
                        yield return new WaitForSeconds(1f);
                        booliyan = true;
                    break;
                }
        }

        StartCoroutine(CubeMover());
    }

    IEnumerator ChangingColor()
    {
        renderer.material.color = Color.Lerp(Color.yellow, Color.green, 70f* Time.deltaTime);
        yield return null;
    }
}
