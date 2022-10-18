using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*
 * 진행 방식 
 * 1. Newspaper 떠 있는 상태로 시작
 * 2. 엔터 후 Newpaper.SetActive(false). Newspaper 다이얼로그 재생
 * 3. 재생 종료 후 신청서 등장과 함께 ApplicationForm01 다이얼로그 재생
 * 4. 신청서 작성 후 submit 누르면 ApplicationForm02 다이얼로그 재생
*/

public class PrologueManager : MonoBehaviour
{
    // 상태
    public bool isNewpaperActive = true;

    // 변수
    public GameObject newspaper;
    public GameObject applForm;

    // 오브젝트
    public DialogueRunner dialogueRunner;
    public string newspaperNode;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    public void OnMouseDown()
    {
        if (isNewpaperActive && !dialogueRunner.IsDialogueRunning)
        {
            StartNewspaperDial();
        }
    }

    public void StartNewspaperDial()
    {
        if (Input.GetKeyDown(KeyCode.Return) && newspaper.activeSelf == true)
        {
            // node Newspaper 재생
            dialogueRunner.StartDialogue(newspaperNode);

            // 신문기사 비활성화
            newspaper.SetActive(false);
        }
        isNewpaperActive = false;
    }

    public void StartAppForm1Dial()
    {
        // 앞에 다이얼 끝나면(이건 인스펙터 창에 있음)
        // 신청서 활성화
        GameObject.Find("Canvas").transform.Find("ApplicationForm").gameObject.SetActive(true);
        // node ApplicationForm01 재생

    }

    public void StartAppForm2Dial()
    {
        // 버튼 클릭했을 때
        // node ApplicationForm02 재생
    }
}
