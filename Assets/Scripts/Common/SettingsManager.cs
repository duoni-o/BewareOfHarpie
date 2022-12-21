/*
 * 작성자: 이주원
 * 설정창 관리 스크립트
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // 설정창
    [SerializeField]
    GameObject settings;
    // 플레이어
    //[SerializeField]
    //GameObject player;

    void Update()
    {
        // Tab 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // 설정창이 켜져있는 경우
            if (settings.activeSelf == true)
                // 설정창 비활성화
                settings.SetActive(false);
            // 설정창이 꺼져있는 경우
            else
                // 설정창 활성화
                GameObject.Find("Canvas").transform.Find("Settings").gameObject.SetActive(true);
        }

        /*
        // 설정창이 켜져 있는 경우
        if (settings.activeSelf == true)
        {
            // 플레이어 이동 불가
            player.GetComponent<PlayerController_noJump>().enabled = false;
            player.GetComponent<PlayerController_jump>().enabled = false;
        }
        // 설정창을 끌 경우
        else
        {
            // 플레이어 이동 가능
            player.GetComponent<PlayerController_noJump>().enabled = true;
            player.GetComponent<PlayerController_jump>().enabled = true;
        }*/
    }
}