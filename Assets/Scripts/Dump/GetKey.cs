using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player가 열쇠랑 닿으면 열쇠 사라지고 player가 열쇠 갖고 있게 만들기

public class GetKey : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            gameObject.SetActive(false);
    }
}
