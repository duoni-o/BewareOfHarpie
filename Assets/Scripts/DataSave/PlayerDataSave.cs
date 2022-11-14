using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSave : MonoBehaviour
{
    public string Item;
    public Transform TranslatePos;
    //Key 오브젝트
    public GameObject key;

    void Start()
    {
        PlayerPrefs.DeleteAll(); // 모두 삭제하기
        if(PlayerPrefs.HasKey("PosSaveX") & PlayerPrefs.HasKey("PosSaveY") & PlayerPrefs.HasKey("GetItem")){
            Vector2 pos = new Vector2(PlayerPrefs.GetFloat("PosSaveX"),PlayerPrefs.GetFloat("PosSaveY"));
            gameObject.transform.position = pos;
            Item = PlayerPrefs.GetString("GetItem");

            ItemActive(Item);
        }

    }

    public void Save(string item){
      PlayerPrefs.SetFloat("PosSaveX",gameObject.transform.position.x);
      PlayerPrefs.SetFloat("PosSaveY",gameObject.transform.position.y);
      PlayerPrefs.SetString("GetItem",item);

      PlayerPrefs.Save();
      print("saving");
    }

    //해당 아이템을 획득했다면 비활성화하기
    void ItemActive(string item){
      if(item == "Key"){
        key.SetActive(false);
      }
    }
}
