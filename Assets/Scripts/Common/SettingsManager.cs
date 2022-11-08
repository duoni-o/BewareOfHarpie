using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    GameObject settings;
    //[SerializeField]
    //GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (settings.activeSelf == true)
                settings.SetActive(false);
            else
                GameObject.Find("Canvas").transform.Find("Settings").gameObject.SetActive(true);
        }
        /*
        if (settings.activeSelf == true)
            player.GetComponent<PlayerController>().enabled = false;
        else
            player.GetComponent<PlayerController>().enabled = true;
            */
    }
}
