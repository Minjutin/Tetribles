using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_handler : MonoBehaviour
{
    public GameObject pause;

    void Update()
    {
        //Whenever esc is pressed open pause menu.
        if(Input.GetKeyDown("escape")){
            pause.SetActive(true);
        }
    }
}
