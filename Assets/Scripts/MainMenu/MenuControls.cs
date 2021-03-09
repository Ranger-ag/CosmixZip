using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
    MenuMusicManager musicManager;

    public GameObject[] btns;

    public GameObject[] darkModeObj;

    bool darkMode = false;


    void Start()
    {
        musicManager = GetComponent<MenuMusicManager>();
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Delete) && darkMode == false)
        {
            darkMode = true;

            musicManager.SetExtendAudio();

            foreach(GameObject go in btns)
            {
                go.SetActive(false);
            }

            foreach (GameObject go in darkModeObj)
            {
                go.SetActive(true);
            }
        }

    }
}
