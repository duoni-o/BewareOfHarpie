using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneMove : MonoBehaviour
{
    Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Door") {
            if (PlayerPrefs.HasKey("GetKey")){
                if(scene.name == "Dump"){
                    SceneManager.LoadScene("Corridor");
                }
            }
        }
    }
}
