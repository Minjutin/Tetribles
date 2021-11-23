using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public int points = 0;
    public int highscore;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (points > highscore)
        {
            highscore = points;

            PlayerPrefs.SetInt("highscore", highscore);
        }
        if (points < 10)
        {
           gameObject.GetComponent<Text>().text = "SCORE\n0000"+points;
        }
        else if (points < 100)
        {
            gameObject.GetComponent<Text>().text = "SCORE\n000" + points;
        }
        else if (points < 1000)
        {
            gameObject.GetComponent<Text>().text = "SCORE\n00" + points;
        }

    }
}
