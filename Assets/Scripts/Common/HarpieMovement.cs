/*
 * 작성자: 이주원
 * 작성일자: 2022.11.14
 * 하피의 움직임을 제어하는 스크립트
 * 플레이어 근처를 배회하다가 플레이어가 일정 범위 내에 들어오면 플레이어 쫓아옴
 * 플레이어가 가구 뒤에 숨으면 플레이어를 쫓는 걸 멈추고 다시 근처를 배회
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpieMovement : MonoBehaviour
{
    float leftRange;
    float rightRange;
    [SerializeField]
    float speed;

    Animator animator;
    int a = 1;

    Rigidbody2D rb;
    Transform target;
    Transform drawer;
    [SerializeField]
    float distance;
    [Header("플레이어와 가구 간 거리")]
    [SerializeField]
    float pdDistance;
    [Header("하피 왔다갔다 하는 거리")]
    [SerializeField]
    float phDistance;
    bool follow = false;
    bool overlap = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        drawer = GameObject.FindGameObjectWithTag("Drawer").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        HarpieRoutine();
        PlayerDrawerDistance();
    }

    // 일정 범위 내에서 왔다갔다 하기
    private void HarpieRoutine()
    {
        leftRange = target.position.x - phDistance;
        rightRange = target.position.x + phDistance;

        // 특정 위치까지 가게 되면
        if (transform.localPosition.x < leftRange)
        {
            // 변수 부호 변경
            a = -1;
        }
        else if (transform.localPosition.x > rightRange)
        {
            a = 1;
        }

        // 위 변수 부호에 따라 Enemy가 움직이는 방향이 달라지게 됨
        transform.Translate(Vector3.left * speed * Time.deltaTime * a);

        FollowTarget();
    }

    // 조건 만족 시 플레이어를 따라오는 함수
    void FollowTarget()
    {
        // 일정 거리 내에 있고 모든 조건을 만족할 경우
        if (Vector2.Distance(transform.position, target.position) > distance && follow && !overlap)
        {
            // 플레이어 따라옴
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
            rb.velocity = Vector2.zero;
    }

    // 플레이어가 하피 근처로 올 경우
    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
    }

    // 플레이어가 하피와 멀어질 경우
    private void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }

    private void PlayerDrawerDistance()
    {
        // 플레이어와 가구 사이 거리가 일정 거리 이하로 줄어들었을 때
        if (Vector2.Distance(target.position, drawer.position) < pdDistance)
        {
            // 겹쳐져 있는 것으로 간주
            overlap = true;
        }
        else
            overlap = false;
    }
}

