/*
 * 작성자 : 공서은
 * 플레이어 데드포인트 위치 저장 및 획득한 재료 데이터 저장
 * 시작할때 위치 데이터가 저장이 되었는지 여부 체크
 * 만약 저장이 되어있으면 해당 데이터에 플레이어 고정시킴
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataSave : MonoBehaviour
{
    public Transform TranslatePos;
    InventoryEnable inventoryEnable;
    public GameObject Bag;

    string equipItem;

    //탈출,클리어에 필요한 오브젝트들
    public GameObject key;
    public GameObject cotton;
    public GameObject Thread;
    public GameObject Needle;
    public GameObject Btn;
    public GameObject Note;

    void Start()
    {
        inventoryEnable = Bag.GetComponent<InventoryEnable>();

        //PlayerPrefs.DeleteAll(); // 모두 삭제하기
        if (PlayerPrefs.HasKey("PosSaveX") & PlayerPrefs.HasKey("PosSaveY"))
        {
            Vector2 pos = new Vector2(PlayerPrefs.GetFloat("PosSaveX"),PlayerPrefs.GetFloat("PosSaveY"));
            gameObject.transform.position = pos;

            ItemActive();
        }

    }

    public void Save(string item)
    {
        PlayerPrefs.SetFloat("PosSaveX",gameObject.transform.position.x);
        PlayerPrefs.SetFloat("PosSaveY",gameObject.transform.position.y);
        PlayerPrefs.SetFloat("SceneIndex", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetString("Get"+item,item);

        PlayerPrefs.Save();
    }

    //어떤 아이템을 획득했는지 체크하는 함
    void ItemActive()
    {
        //획득해야하는 아이템들 
        string[] itemArray = {"Key","Cotton","Dump", "Get_button", "Thread","Needle","Note"};
        //획득한 아이템 리스트
        List<string> equipItemsList = new List<string>();

        for (int i=0; i < itemArray.Length; i++)
        {
            equipItem = itemArray[i];

            if (PlayerPrefs.HasKey("Get"+equipItem))
            {
                equipItemsList.Add(equipItem);
            }
        }

        //획득한 아이템 비활성화하기
        for (int i=0; i<equipItemsList.Count; i++)
        {
            if (equipItemsList[i] == "Key")
            {
                key.SetActive(false);
            }
            else if(equipItemsList[i] == "Cotton")
            {
                cotton.SetActive(false);
            }
            else if (equipItemsList[i] == "Thread")
            {
                Thread.SetActive(false);
            }
            else if (equipItemsList[i] == "Needle")
            {
                Needle.SetActive(false);
            }
            else if (equipItemsList[i] == "Get_button")
            {
                Btn.SetActive(false);
            }

            inventoryEnable.Inventory(equipItemsList[i]);
        }
    }
}
