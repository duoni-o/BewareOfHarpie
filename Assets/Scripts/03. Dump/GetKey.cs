using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player�� ����� ������ ���� ������� player�� ���� ���� �ְ� �����

public class GetKey : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            gameObject.SetActive(false);
    }
}
