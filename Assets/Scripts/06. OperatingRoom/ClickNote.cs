/*
 * 
 * 
 * 
 * 
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNote : MonoBehaviour
{
    public void ShowNoteBigger()
    {
        GameObject.Find("Canvas").transform.Find("Note_bigger").gameObject.SetActive(true);

    }

    public void CloseNoteBigger()
    {
        GameObject.Find("Canvas").transform.Find("Note_bigger").gameObject.SetActive(false);
    }
}
