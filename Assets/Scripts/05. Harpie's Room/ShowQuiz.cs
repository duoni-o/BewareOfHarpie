/*
 * 작성자: 이주원
 * 하피의 방에서 방문을 클릭했을 경우 퀴즈가 활성화되게 하는 스크립트
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuiz : MonoBehaviour
{
    // 방문을 클릭했을 경우
    public void OnMouseUp()
    {
        // 퀴즈 활성화
        GameObject.Find("Canvas").transform.Find("Quiz").gameObject.SetActive(true);
    }
}
