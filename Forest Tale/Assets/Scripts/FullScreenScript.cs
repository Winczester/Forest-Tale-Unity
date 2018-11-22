using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class FullScreenScript : MonoBehaviour {

    bool IsFullScreen = false;

    public void FullScreenToogle()
    {
        IsFullScreen = !IsFullScreen;
        Screen.fullScreen = IsFullScreen;
    }
}
