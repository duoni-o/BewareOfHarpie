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
        playerPosition = playerName.GetComponent<Transform>();
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        transform.position = playerPosition.position + cameraPosition;

        float leftX = mapSize.x - width;
        float leftY = mapSize.y - height;
        float clampX = Mathf.Clamp(transform.position.x, -leftX + center.x, leftX + center.x);
        float clampY = Mathf.Clamp(transform.position.y, -leftY + center.y, leftY + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);

    }

}
