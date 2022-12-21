/*
 * 작성자: 이주원
 * 하피가 플레이어와 닿았을 경우 Harpie Ending으로 이동하는 스크립트
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerHarpieEnding : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Player 태그를 갖고 있는 오브젝트(플레이어)와 닿았을 경우
        if (collision.gameObject.tag == "Player")
        {
            // HarpieEnding 씬으로 이동
            SceneManager.LoadScene("HarpieEnding");
        }
    }
}
