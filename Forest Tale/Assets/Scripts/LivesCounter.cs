using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour {

    private Text LivesText;

	// Use this for initialization
	void Awake () {
        LivesText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        LivesText.text = "Lives: " + PlayerScript.Lives.ToString();
	}
}
