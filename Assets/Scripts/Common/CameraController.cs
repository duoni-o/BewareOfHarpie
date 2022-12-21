/*
 * 작성자: 이주원
 * 카메라 이동 구현
 * 플레이어의 이동에 맞춰 카메라가 움직인다. 맵 외의 부분은 보여주지 않는다.
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject playerName;

    [SerializeField]
    Vector3 cameraPosition = new Vector3(0, 0, -10);
    Transform playerPosition;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    Vector2 mapSize;

    float height, width;

    void Start()
    {
        // 플레이어 위치 받아오기
        playerPosition = playerName.GetComponent<Transform>();
        // 카메라가 받아오는 스크린의 크기를 나타냄
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        transform.position = playerPosition.position + cameraPosition;

        // 카메라가 움직일 수 있는 범위 지정
        float leftX = mapSize.x - width;
        float leftY = mapSize.y - height;
        float clampX = Mathf.Clamp(transform.position.x, -leftX + center.x, leftX + center.x);
        float clampY = Mathf.Clamp(transform.position.y, -leftY + center.y, leftY + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);

    }

}
