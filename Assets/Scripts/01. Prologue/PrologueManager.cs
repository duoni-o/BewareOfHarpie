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
    public void ClickSubmit()
    {
        //GameObject.Find("Canvas").transform.Find("Submit_completed").gameObject.SetActive(true);
    }

    public void ClickOK()
    {
        GameObject.Find("Canvas").transform.Find("ApplicationForm").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Submit_completed").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Player_completed_png").gameObject.SetActive(true);

    }

}
