using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HappyEnding : MonoBehaviour
{
    public void MoveToTitle()
    {
        SceneManager.LoadScene("Thanks");
    }
}
