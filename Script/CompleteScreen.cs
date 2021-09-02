using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteScreen : MonoBehaviour {
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GotoNextScene()
    {
        SceneManager.LoadScene("BoyVsPai" +
           (GameObject.Find("Gamemanager").GetComponent<Gamemanager>().
            NumberStage + 1));
    }
}

