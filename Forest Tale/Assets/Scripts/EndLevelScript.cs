using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hero")
        {
            SceneManager.LoadScene("menu scene");
            Debug.Log("lvl ended");
            PlayerScript.Gems = 0;
        }
    }
}
