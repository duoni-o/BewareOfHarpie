/*
 * 작성자: 이주원
 * 엔딩에서 타이틀로, 게임 종료 버튼을 눌렀을 경우 해당하는 씬으로 이동
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    // 타이틀로 버튼 눌렀을 경우
    public void ClickToTitle()
    {
        // 타이틀 씬으로 이동
        SceneManager.LoadScene("02. Title");
    }

    // 게임 종료 버튼 눌렀을 경우
    public void ClickQuit()
    {
        // 게임 종료
        Application.Quit();
    }

    public void MoveToThanks()
    {
        // 최종 씬으로 이동
        SceneManager.LoadScene("Thanks");
    }

    // 하피 애니메이션 후 다시 시작 버튼 활성화
    public void ShowHarpieEndingMessage()
    {
        // 다시 시작 버튼 활성화
        GameObject.Find("Canvas").transform.Find("Restart").gameObject.SetActive(true);
        // 타이틀로 이동 버튼 활성화
        GameObject.Find("Canvas").transform.Find("ToTitle").gameObject.SetActive(true);
    }
}
