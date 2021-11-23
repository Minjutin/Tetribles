using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_piece : MonoBehaviour
{

    public bool grounded = false;
    public GameObject[] pieces;
    public bool gameOn = true;
    int which;
    public GameObject lose;


    //Spawn the first piece.
    void Start()
    {
        gameOn = true;
        which = Random.Range(0, pieces.Length);
        Instantiate(pieces[which], transform.position - new Vector3(0, 3, 0), transform.rotation);
        StartCoroutine(luo_pala());
    }

    //Create a new piece by using this method.
    IEnumerator luo_pala()
    {
        //This only works if gameOn is true. 
        while (gameOn)
        {
            if (grounded)
            {

                grounded = false;
                which = Random.Range(0,pieces.Length);
                Instantiate(pieces[which], transform.position-new Vector3(0,3,0), transform.rotation);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }

        //After game has ended open game over menu.
        lose.SetActive(true);

    }
}
