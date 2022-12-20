/*
 * 
 * 
 * 
 * 
 * 
 * 
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public void ClickStart()
    {        
        SceneManager.LoadScene("03. Dump");
    }

    public void ClickSettings()
    {
        GameObject.Find("Canvas").transform.Find("Settings").gameObject.SetActive(true);
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}