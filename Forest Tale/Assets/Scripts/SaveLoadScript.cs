using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadScript : MonoBehaviour {

	public static void Save(GameObject gameObject, string key)
    {
        PlayerPrefs.SetFloat(key + "PosX", gameObject.transform.position.x);
        PlayerPrefs.SetFloat(key + "PosY", gameObject.transform.position.y);
        PlayerPrefs.SetFloat(key + "PosZ", gameObject.transform.position.z);

        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Saved");
    }

    public static void Load(GameObject gameObject, string key)
    {
        Vector3 LoadPosition = new Vector3(PlayerPrefs.GetFloat(key + "PosX"), PlayerPrefs.GetFloat(key + "PosY"), PlayerPrefs.GetFloat(key + "PosZ"));
        gameObject.transform.position = LoadPosition;

        PlayerPrefs.GetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Loaded");
    }
}
