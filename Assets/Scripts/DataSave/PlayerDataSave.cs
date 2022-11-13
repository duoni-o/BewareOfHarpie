using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSave : MonoBehaviour
{
    public Transform transform;
    public Transform TranslatePos;

    void Start()
    {
        if(PlayerPrefs.HasKey("PosSaveX") & PlayerPrefs.HasKey("PosSaveY")){

          
          print((PlayerPrefs.GetFloat("PosSaveX")+" "+PlayerPrefs.GetFloat("PosSaveY")));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.CompareTag("Save")){
         transform = col.transform;
         Save();
      }
         
    }

    void Save(){
      PlayerPrefs.SetFloat("PosSaveX",transform.position.x);
      PlayerPrefs.SetFloat("PosSaveY",transform.position.y);
      PlayerPrefs.Save();
      print("saving");
    }
}
