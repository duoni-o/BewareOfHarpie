using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player�� ����� ������ ���� ������� player�� ���� ���� �ְ� �����

public class GetKey : MonoBehaviour
{
    PlayerDataSave playerDataSave;
    
    void Start()
    {
        playerDataSave = GameObject.Find("Player_broken_jump").GetComponent<PlayerDataSave>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerDataSave.Save(collision);
            gameObject.SetActive(false);

    }

}
