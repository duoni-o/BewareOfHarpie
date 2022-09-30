using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settings;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (settings.activeSelf == true)
                settings.SetActive(false);
            else
                GameObject.Find("Canvas").transform.Find("Settings").gameObject.SetActive(true);
        }
    }
}
