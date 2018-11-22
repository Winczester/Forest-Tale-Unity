using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public void PlayPressed()
    {
        SceneManager.LoadScene("lvl 1");
    }

    public void ExitPresed()
    {
        Application.Quit();
    }
}
