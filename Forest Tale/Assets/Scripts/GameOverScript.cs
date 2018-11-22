using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public GameObject GameOverUI;

    private void Update()
    {
        if(PlayerScript.Lives <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Hero"));
            GameOver();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
}
