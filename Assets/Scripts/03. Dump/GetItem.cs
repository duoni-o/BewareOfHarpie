/*
 * 작성자 : 공서은
 * 획득한 아이템을 비활성화시키, 데드포인트와 인벤토리에 해당 데이터 전달하기
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GetItem : MonoBehaviour
{
    PlayerDataSave playerDataSave;
    InventoryEnable inventoryEnable;

    //인벤토리
    public GameObject Bag;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        if(scene.name == "03. Dump")
        {
            playerDataSave = GameObject.Find("Player_broken_jump").GetComponent<PlayerDataSave>();
        }
        else
        {
            playerDataSave = GameObject.Find("Player_broken_noJump").GetComponent<PlayerDataSave>();
        }

        inventoryEnable = Bag.GetComponent<InventoryEnable>();
    
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            //데이터 저장
            playerDataSave.Save(gameObject.name);
            //아이템과 닿는 순간 아이템 비활성화
            gameObject.SetActive(false);
            // 닿은 아이템 정보 전달
            inventoryEnable.Inventory(gameObject.name);
    }

    //마우스 클릭을 이용한 재료 획득할 경우
    public void inventoryData()
    {
        print("data");
        Scene scene1 = SceneManager.GetActiveScene();
        PlayerDataSave playerDataSave1;

        if (scene1.name == "03. Dump")
        {
            playerDataSave1 = GameObject.Find("Player_broken_jump").GetComponent<PlayerDataSave>();
        }
        else
        {
            playerDataSave1 = GameObject.Find("Player_broken_noJump").GetComponent<PlayerDataSave>();
        }

        InventoryEnable inventoryEnable1 = Bag.GetComponent<InventoryEnable>();


        if(scene1.name == "06. OperatingRoom")
        {
            // 닿은 아이템 정보 전달
            inventoryEnable1.Inventory("Note");
            //데이터 저장
            playerDataSave1.Save("Note");
        }
        else
        {
            // 닿은 아이템 정보 전달
            inventoryEnable1.Inventory(gameObject.name);
            //데이터 저장
            playerDataSave1.Save(gameObject.name);
        }
    
    }

}
