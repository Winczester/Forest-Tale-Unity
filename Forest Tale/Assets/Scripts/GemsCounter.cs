using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsCounter : MonoBehaviour {

    private Text GemsText;

	// Use this for initialization
	void Awake () {
        GemsText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        GemsText.text = "Gems: " + PlayerScript.Gems.ToString();
	}
}
