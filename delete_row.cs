using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_row : MonoBehaviour
{

    //in update we will check, if every box collider in our row is triggered by a square.
    void Update()
    {
        bool destroyable = true;
        foreach (Transform child in transform)
        {
            if(child.GetComponent<triggerchecker>().triggered == false)
            {
                destroyable = false;
            }
        }

        //If every child was triggered, let us destroy every triggerer.
        if (destroyable)
        {
            GameObject.Find("score_text").GetComponent<score>().points++;
            foreach(Transform child in transform)
            {
                child.GetComponent<triggerchecker>().destroyer();
            }
        }

    }

}
