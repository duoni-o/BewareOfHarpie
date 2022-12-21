/*
 * 작성자: 이주원
 * 플레이어 움직임 관련 스크립트. 쓰레기장 씬에서 사용
 * 상하좌우 이동, 달리기 기능
 * 애니메이션 관련 함수
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_noJump : MonoBehaviour
{
    // 플레이어 속도
    [SerializeField]
    float speed = 5;
    // 점프 횟수
    int jumpCount = 0;
    new Rigidbody2D rigidbody2D;
    Animator animator;
    float h;
    float v;

    
    [SerializeField]
    float leftRange;
    [SerializeField]
    float rightRange;
    [SerializeField]
    float upRange;
    [SerializeField]
    float downRange;
    
    bool isWalking;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // 이동 공식; p = p0 + vt
        // 현재위치 = 이전위치 + 속도 * 순간의시간
        Vector3 dir = Vector3.right * h + Vector3.up * v;
        // 정규화 벡터
        dir.Normalize();
        //Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;

        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            key = -1;
            // Shift 키를 눌렀을 경우 속도 증가
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                transform.position += dir * 1.005f * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            key = 1;
            // Shift 키를 눌렀을 경우 속도 증가
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                transform.position += dir * 1.005f * speed * Time.deltaTime;
        }

        // 맵 밖으로 안나가게 범위 고정
        float clampX = Mathf.Clamp(transform.position.x, leftRange, rightRange);
        float clampY = Mathf.Clamp(transform.position.y, upRange, downRange);
        transform.position = new Vector3(clampX, clampY);

        // 움직이는 방향에 따라 반전한다.
        if (key != 0)
        {
            transform.localScale = new Vector2(-key, 1);
        }

        AnimationUpdate();
    }

    void AnimationUpdate()
    {
        // 속도가 0일 경우
        if (h == 0)
        {
            // 걷기 애니메이션 중단
            animator.SetBool("isWalking", false);

        }
        else
        {
            // 걷기 애니메이션 시작
            animator.SetBool("isWalking", true);
            // Shift 키 누를 경우
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                // 달리기 애니메이션 시작
                animator.SetBool("isRunning", true);
            }
            else
            {
                // 달리기 애니메이션 중단
                animator.SetBool("isRunning", false);
            }
        }
    }

}
