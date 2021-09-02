using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Choose Player");
    }
    public void GotoHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GotoPlayBoy ()
    {
        SceneManager.LoadScene("SampleScene2");
    }
    public void GotoPlayGirl()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GotoBackBoy()
    {
        SceneManager.LoadScene("Choose Player 1");
    }
    public void GotoNextGirl()
    {
        SceneManager.LoadScene("Choose Player ");
    }

    public void GirlGotoNext2()
     {
         SceneManager.LoadScene("GirlVsPai");
     }
    /*public void GotoGirl()
    {
        SceneManager.LoadScene("Choose Player2");
    }*/
}
