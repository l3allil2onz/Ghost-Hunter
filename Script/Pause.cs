using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    Gamemanager GM;
   // public GameObject HowtoPlayShow;
    // Use this for initialization
    void Start()
    {

        GM = GameObject.Find("CanvasOverlay").GetComponent<Gamemanager>();
      



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {

        Time.timeScale = 1;
        AudioListener.volume = 1f;
        GM.IsPause = false;
        GM.PauseScreen.SetActive(false);

    }
    public void PlayAgian()
    {

        Time.timeScale = 1;
        AudioListener.volume = 1f;
        Application.LoadLevel(Application.loadedLevel);

    }
    public void MainMenu()
    {

        Time.timeScale = 1;
        AudioListener.volume = 1f;
        SceneManager.LoadScene("MainMenu");

    }





}
