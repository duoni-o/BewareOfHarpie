using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToHarpieRoom : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("05. HarpieRoom");
    }
}
