using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public void PlayPressed()
    {
        SceneManager.LoadScene("test scene");
    }

    public void ExitPresed()
    {
        Application.Quit();
    }
}
