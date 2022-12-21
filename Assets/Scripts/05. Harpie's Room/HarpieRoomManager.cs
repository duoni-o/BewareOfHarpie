/*
 * 작성자: 이주원
 * 퀴즈 관련 스크립트
 * 클릭 시 색이 변하고 Reset 버튼을 클릭했을 경우 초기화
 * 정답일 경우 Open 버튼을 클릭하면 다음 씬으로 이동
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 2차원 배열 선언
[System.Serializable]
public class Bingo
{
    public Image[] Bingo_list;
}

public class HarpieRoomManager : MonoBehaviour
{
    [SerializeField]
    GameObject harpie;

    public Bingo[] Bingos;
    // isOpened가 true일 경우 다음 씬으로 이동 가능
    public bool isOpened = false;

    // 알파벳 'O' 맞춰 클릭할 경우 true
    bool isRed = false;
    // 알파벳 'U' 맞춰 클릭할 경우 true
    bool isGreen = false;
    // 알파벳 'T' 맞춰 클릭할 경우 true
    bool isBlue = false;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                // 모든 버튼 흰색으로 초기화
                Bingos[i].Bingo_list[j].color = Color.white;
            }
        }
    }

    public void MoveToOperatingRoom()
    {
        // isOpened가 true일 경우
        if (isOpened)
        {
            // 다음 씬으로 이동
            SceneManager.LoadScene("06. OperatingRoom");
        }
    }

    public void ChangeColorRed()
    {
        // 현재 클릭한 버튼을
        GameObject redButton = EventSystem.current.currentSelectedGameObject;
        // 빨강색으로 변경
        redButton.GetComponent<Image>().color = Color.red;
    }

    public void ChangeColorGreen()
    {
        // 현재 클릭한 버튼을
        GameObject greenButton = EventSystem.current.currentSelectedGameObject;
        // 초록색으로 변경
        greenButton.GetComponent<Image>().color = Color.green;
    }

    public void ChangeColorBlue()
    {
        // 현재 클릭한 버튼을
        GameObject blueButton = EventSystem.current.currentSelectedGameObject;
        // 파랑색으로 변경
        blueButton.GetComponent<Image>().color = Color.blue;
    }

    public void ResetToWhite()
    {
        // 모든 버튼 배열의 색을
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                // 흰색으로 변경
                Bingos[i].Bingo_list[j].color = Color.white;
            }
        }

        isRed = false;
        isGreen = false;
        isBlue = false;
        isOpened = false;
    }

    // 퀴즈 창 닫기
    public void CloseQuiz()
    {
        GameObject.Find("Canvas").transform.Find("Quiz").gameObject.SetActive(false);
    }

    public void Update()
    {
        GameObject quiz = GameObject.Find("Canvas").transform.Find("Quiz").gameObject;
        if (quiz.activeSelf == true)
        {
            harpie.GetComponent<HarpieMovement>().enabled = false;
        }
        else
            harpie.GetComponent<HarpieMovement>().enabled = true;

        // 알파벳 'O' 완성
        if (Bingos[0].Bingo_list[0].color == Color.red && Bingos[0].Bingo_list[1].color == Color.red && Bingos[0].Bingo_list[2].color == Color.red
            && Bingos[0].Bingo_list[3].color == Color.red && Bingos[0].Bingo_list[4].color == Color.white && Bingos[0].Bingo_list[5].color == Color.red
            && Bingos[0].Bingo_list[6].color == Color.red && Bingos[0].Bingo_list[7].color == Color.red && Bingos[0].Bingo_list[8].color == Color.red)
        {
            isRed = true;
        }

        // 알파벳 'U' 완성
        if (Bingos[1].Bingo_list[0].color == Color.green && Bingos[1].Bingo_list[1].color == Color.white && Bingos[1].Bingo_list[2].color == Color.green
            && Bingos[1].Bingo_list[3].color == Color.green && Bingos[1].Bingo_list[4].color == Color.white && Bingos[1].Bingo_list[5].color == Color.green
            && Bingos[1].Bingo_list[6].color == Color.green && Bingos[1].Bingo_list[7].color == Color.green && Bingos[1].Bingo_list[8].color == Color.green)
        {
            isGreen = true;
        }

        // 알파벳 'T' 완성
        if (Bingos[2].Bingo_list[0].color == Color.blue && Bingos[2].Bingo_list[1].color == Color.blue && Bingos[2].Bingo_list[2].color == Color.blue
            && Bingos[2].Bingo_list[3].color == Color.white && Bingos[2].Bingo_list[4].color == Color.blue && Bingos[2].Bingo_list[5].color == Color.white
            && Bingos[2].Bingo_list[6].color == Color.white && Bingos[2].Bingo_list[7].color == Color.blue && Bingos[2].Bingo_list[8].color == Color.white)
        {
            isBlue = true;
        }

        // 'OUT'이 완성됐을 경우 이동 가능
        if (isRed && isGreen && isBlue)
        {
            isOpened = true;
        }
    }
}
