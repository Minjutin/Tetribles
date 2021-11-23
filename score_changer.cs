using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_changer : MonoBehaviour
{

    public int highscore = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        highscore = PlayerPrefs.GetInt("highscore");

        GetComponent<UnityEngine.UI.Text>().text = highscore.ToString()+"pt.";
    }
}
