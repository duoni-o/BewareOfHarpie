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
            Vector2 pos = new Vector2(PlayerPrefs.GetFloat("PosSaveX"),PlayerPrefs.GetFloat("PosSaveY"));
            gameObject.transform.position = pos;
          
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save(Collision2D collision){
      PlayerPrefs.SetFloat("PosSaveX",gameObject.transform.position.x);
      PlayerPrefs.SetFloat("PosSaveY",gameObject.transform.position.y);
      PlayerPrefs.SetString("GetItem",(collision.gameObject).ToString());

      PlayerPrefs.Save();
      print("saving");
    }
}
