using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionsScript : MonoBehaviour {

    Resolution[] rsl;
    List<string> resolutions;
    Dropdown dropdown;

    bool IsFoolScreen = false;

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();

        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }

    public void Resolution()
    {
        Screen.SetResolution(rsl[dropdown.value].width, rsl[dropdown.value].height, IsFoolScreen);
    }



}
