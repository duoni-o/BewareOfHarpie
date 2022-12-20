/*
 * 
 * 
 * 
 * 
 * 
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuiz : MonoBehaviour
{
    public void OnMouseUp()
    {
        GameObject.Find("Canvas").transform.Find("Quiz").gameObject.SetActive(true);
    }
}
