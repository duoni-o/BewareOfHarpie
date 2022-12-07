using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpieEnding : MonoBehaviour
{
    public void ShowHarpieEndingMessage()
    {
        GameObject.Find("Canvas").transform.Find("Restart").gameObject.SetActive(true);
    }
}
