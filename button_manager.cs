using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_manager : MonoBehaviour
{
    public GameObject kanvas;
    AudioSource audioData;

    public void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UnPause()
    {
        audioData = GameObject.Find("Piece_Spawner").GetComponent<AudioSource>();
        audioData.Play(0);
        GameObject.Find("Pause_Canvas").SetActive(false);
    }

    public void CloseScores()
    {
        audioData = GameObject.Find("Menu Canvas").GetComponent<AudioSource>();
        audioData.Play(0);
        kanvas.SetActive(false);
    }

    public void OpenScores()
    {
        audioData = GameObject.Find("Menu Canvas").GetComponent<AudioSource>();
        audioData.Play(0);
        kanvas.SetActive(true);
    }
}
