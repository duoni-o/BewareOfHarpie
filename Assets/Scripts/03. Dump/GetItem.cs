using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player�� ����� ������ ���� ������� player�� ���� ���� �ְ� �����

public class GetItem : MonoBehaviour
{
    PlayerDataSave playerDataSave;
    
    void Start()
    {
        playerDataSave = GameObject.Find("Player_broken_jump").GetComponent<PlayerDataSave>();
    
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            
            //데이터 저장
            playerDataSave.Save(gameObject.name);
            gameObject.SetActive(false);
            print(gameObject.name);
    }

}
