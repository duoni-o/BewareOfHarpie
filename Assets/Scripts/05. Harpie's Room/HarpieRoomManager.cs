using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Bingo
{
    public Image[] Bingo_list;
}

public class HarpieRoomManager : MonoBehaviour
{
    public Bingo[] Bingos;
    public bool isOpened = false;

    bool isRed = false;
    bool isGreen = false;
    bool isBlue = false;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Bingos[i].Bingo_list[j].color = Color.white;
            }
        }
    }

    public void MoveToOperatingRoom()
    {
        if (isOpened)
        {
            SceneManager.LoadScene("06. OperatingRoom");
        }
    }

    public void ChangeColorRed()
    {
        GameObject redButton = EventSystem.current.currentSelectedGameObject;
        redButton.GetComponent<Image>().color = Color.red;
        //isRed = true;
    }

    public void ChangeColorGreen()
    {
        GameObject greenButton = EventSystem.current.currentSelectedGameObject;
        greenButton.GetComponent<Image>().color = Color.green;
        //isGreen = true;
    }

    public void ChangeColorBlue()
    {
        GameObject blueButton = EventSystem.current.currentSelectedGameObject;
        blueButton.GetComponent<Image>().color = Color.blue;
        //isBlue = true;
    }

    public void ResetToWhite()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Bingos[i].Bingo_list[j].color = Color.white;
            }
        }

        isRed = false;
        isGreen = false;
        isBlue = false;
        isOpened = false;
    }

    public void ShowQuiz()
    {
        GameObject.Find("Canvas").transform.Find("Quiz").gameObject.SetActive(true);
    }

    public void CloseQuiz()
    {
        GameObject.Find("Canvas").transform.Find("Quiz").gameObject.SetActive(false);
    }


    public void Update()
    {
        if (Bingos[0].Bingo_list[0].color == Color.red && Bingos[0].Bingo_list[1].color == Color.red && Bingos[0].Bingo_list[2].color == Color.red
            && Bingos[0].Bingo_list[3].color == Color.red && Bingos[0].Bingo_list[4].color == Color.white && Bingos[0].Bingo_list[5].color == Color.red
            && Bingos[0].Bingo_list[6].color == Color.red && Bingos[0].Bingo_list[7].color == Color.red && Bingos[0].Bingo_list[8].color == Color.red)
        {
            Debug.Log("»¡°­ ¿Ï¼º");
            isRed = true;
        }

        if (Bingos[1].Bingo_list[0].color == Color.green && Bingos[1].Bingo_list[1].color == Color.white && Bingos[1].Bingo_list[2].color == Color.green
            && Bingos[1].Bingo_list[3].color == Color.green && Bingos[1].Bingo_list[4].color == Color.white && Bingos[1].Bingo_list[5].color == Color.green
            && Bingos[1].Bingo_list[6].color == Color.green && Bingos[1].Bingo_list[7].color == Color.green && Bingos[1].Bingo_list[8].color == Color.green)
        {
            Debug.Log("ÃÊ·Ï ¿Ï¼º");
            isGreen = true;
        }

        if (Bingos[2].Bingo_list[0].color == Color.blue && Bingos[2].Bingo_list[1].color == Color.blue && Bingos[2].Bingo_list[2].color == Color.blue
            && Bingos[2].Bingo_list[3].color == Color.white && Bingos[2].Bingo_list[4].color == Color.blue && Bingos[2].Bingo_list[5].color == Color.white
            && Bingos[2].Bingo_list[6].color == Color.white && Bingos[2].Bingo_list[7].color == Color.blue && Bingos[2].Bingo_list[8].color == Color.white)
        {
            Debug.Log("ÆÄ¶û ¿Ï¼º");
            isBlue = true;
        }

        if (isRed && isGreen && isBlue)
        {
            Debug.Log("¿ÀÇÂ °¡´É");
            isOpened = true;
        }
    }
}
