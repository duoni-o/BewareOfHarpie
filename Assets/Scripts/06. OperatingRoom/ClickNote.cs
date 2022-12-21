/*
 * 작성자: 이주원
 * 인벤토리 내 쪽지 UI를 클릭한 경우 쪽지 내용 활성화,
 * 활성화된 쪽지 화면을 닫는 스크립트
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNote : MonoBehaviour
{
    public void ShowNoteBigger()
    {
        // 쪽지 내용 활성화
        GameObject.Find("Canvas").transform.Find("Note_bigger").gameObject.SetActive(true);

    }

    public void CloseNoteBigger()
    {
        // 활성화된 쪽지 내용 닫기
        GameObject.Find("Canvas").transform.Find("Note_bigger").gameObject.SetActive(false);
    }
}
