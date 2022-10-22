using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
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
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                transform.position += dir * 1.2f * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            key = 1;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                transform.position += dir * 1.2f * speed * Time.deltaTime;
        }


        // 맵 밖으로 안나가게
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftRange, rightRange), (transform.position.y, upRange, downRange));

        // 움직이는 방향에 따라 반전한다.
        if (key != 0)
        {
            transform.localScale = new Vector2(-key, 1);
        }

        AnimationUpdate();
    }

    void AnimationUpdate()
    {
        if (h == 0)
        {
            animator.SetBool("isWalking", false);

        }
        else
        {
            animator.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

}
