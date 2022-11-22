using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSave : MonoBehaviour
{
    public Transform TranslatePos;

    string equipItem;

    //탈출,클리어에 필요한 오브젝트들
    public GameObject key;
    public GameObject cotton;

    void Start()
    {
        //PlayerPrefs.DeleteAll(); // 모두 삭제하기
        if(PlayerPrefs.HasKey("PosSaveX") & PlayerPrefs.HasKey("PosSaveY")){
            Vector2 pos = new Vector2(PlayerPrefs.GetFloat("PosSaveX"),PlayerPrefs.GetFloat("PosSaveY"));
            gameObject.transform.position = pos;

            ItemActive();
        }

    }

    public void Save(string item){
      PlayerPrefs.SetFloat("PosSaveX",gameObject.transform.position.x);
      PlayerPrefs.SetFloat("PosSaveY",gameObject.transform.position.y);
      PlayerPrefs.SetString("Get"+item,item);

      PlayerPrefs.Save();
      print("saving->"+"Get"+item);
    }

    //해당 아이템을 획득했다면 비활성화하기
    void ItemActive(){

      //획득해야하는 아이템들
      string[] itemArray = {"Key","Cotton","Button","Thread","Needle","Note"};
      //획득한 아이템 리스트
      List<string> equipItemsList = new List<string>();
      
      for(int i=0; i < itemArray.Length; i++){
        equipItem = itemArray[i];
        
        if(PlayerPrefs.HasKey("Get"+equipItem)){
          equipItemsList.Add(equipItem);
        }
      }

      for(int i=0; i<equipItemsList.Count; i++){
        if(equipItemsList[i] == "Key"){
          key.SetActive(false);
        }
      else if(equipItemsList[i] == "Cotton"){
        cotton.SetActive(false);
      }

      }


    }
}
