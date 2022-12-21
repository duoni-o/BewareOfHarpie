/*
 * 작성자: 이주원
 * 타이틀 화면에서 시작하기, 설정, 종료하기 버튼을 눌렀을 경우 상호작용하는 함수들을 모아 둔 스크립트
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    // 시작하기 버튼 눌렀을 경우
    public void ClickStart()
    {        
        // 다음 씬(쓰레기장)으로 이동
        SceneManager.LoadScene("03. Dump");
    }

    // 설정 버튼 눌렀을 경우
    public void ClickSettings()
    {
        // 설정 화면 띄우기
        GameObject.Find("Canvas").transform.Find("Settings").gameObject.SetActive(true);
    }

    // 종료하기 버튼 눌렀을 경우
    public void ClickExit()
    {
        // 게임 종료
        Application.Quit();
    }
}