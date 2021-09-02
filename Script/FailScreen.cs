using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScreen : MonoBehaviour {


    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GotoCurrentScene()
    {
        SceneManager.LoadScene("GamePlay" +
            GameObject.Find("GameManager").GetComponent<Gamemanager>().
            NumberStage);
    }
}
