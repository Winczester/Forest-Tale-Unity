using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class FoolScreenScript : MonoBehaviour {

    bool IsFoolScreen = false;

    public void FoolScreenToogle()
    {
        IsFoolScreen = !IsFoolScreen;
        Screen.fullScreen = IsFoolScreen;
    }
}
