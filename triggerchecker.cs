using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerchecker : MonoBehaviour
{

    public bool triggered = false;
    private GameObject pala;

    void OnTriggerStay2D(Collider2D other)
    {
        triggered = true;
        pala = other.gameObject;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
    }
    public void destroyer()
    {
        Destroy(pala);
    }
}
