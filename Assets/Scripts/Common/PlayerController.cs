using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    int jumpCount = 0;
    Rigidbody2D rigidbody2D;
    Animator animator;
    float h;
    //float v;

    /*
    [SerializeField]
    float leftRange;
    [SerializeField]
    float rightRange;
    [SerializeField]
    float upRange;
    [SerializeField]
    float downRange;
    */
    bool isWalking;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");

        // 이동 공식; p = p0 + vt
        // 현재위치 = 이전위치 + 속도 * 순간의시간
        Vector3 dir = Vector3.right * h;// + Vector3.up * v;
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
                transform.position += dir * 1.05f * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            key = 1;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                transform.position += dir * 1.05f * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            rigidbody2D.velocity = Vector3.zero;
            rigidbody2D.AddForce(Vector3.up * 300f);
            //rigidbody2D.AddForce(new Vector3(0, 300f));
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            // 점프 수 초기화
            jumpCount = 0;
        }
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
