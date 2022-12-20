/*
 * 작성자: 이주원
 * 프롤로그에서 버튼을 눌렀을 때 Canvas 내 특정 오브젝트 활성화하는 스크립트
 * 
 * 1. Newspaper 떠 있는 상태로 시작
 * 2. 엔터 후 Newpaper.SetActive(false). Newspaper 다이얼로그 재생
 * 3. 재생 종료 후 신청서 등장과 함께 ApplicationForm01 다이얼로그 재생
 * 4. 신청서 작성 후 submit 누르면 ApplicationForm02 다이얼로그 재생
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PrologueManager : MonoBehaviour
{
    public void ClickSubmit()
    {
        //GameObject.Find("Canvas").transform.Find("Submit_completed").gameObject.SetActive(true);
    }

    // OK 버튼을 눌렀을 때 호출할 함수
    public void ClickOK()
    {
        GameObject.Find("Canvas").transform.Find("ApplicationForm").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Submit_completed").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Player_completed_png").gameObject.SetActive(true);

    }

}