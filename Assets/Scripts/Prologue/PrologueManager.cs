using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*
 * ���� ��� 
 * 1. Newspaper �� �ִ� ���·� ����
 * 2. ���� �� Newpaper.SetActive(false). Newspaper ���̾�α� ���
 * 3. ��� ���� �� ��û�� ����� �Բ� ApplicationForm01 ���̾�α� ���
 * 4. ��û�� �ۼ� �� submit ������ ApplicationForm02 ���̾�α� ���
*/

public class PrologueManager : MonoBehaviour
{
    // ����
    public bool isNewpaperActive = true;

    // ����
    public GameObject newspaper;
    public GameObject applForm;

    // ������Ʈ
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
            // node Newspaper ���
            dialogueRunner.StartDialogue(newspaperNode);

            // �Ź���� ��Ȱ��ȭ
            newspaper.SetActive(false);
        }
        isNewpaperActive = false;
    }

    public void StartAppForm1Dial()
    {
        // �տ� ���̾� ������(�̰� �ν����� â�� ����)
        // ��û�� Ȱ��ȭ
        GameObject.Find("Canvas").transform.Find("ApplicationForm").gameObject.SetActive(true);
        // node ApplicationForm01 ���

    }

    public void StartAppForm2Dial()
    {
        // ��ư Ŭ������ ��
        // node ApplicationForm02 ���
    }
}
