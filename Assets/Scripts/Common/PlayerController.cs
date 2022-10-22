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

        // �̵� ����; p = p0 + vt
        // ������ġ = ������ġ + �ӵ� * �����ǽð�
        Vector3 dir = Vector3.right * h;// + Vector3.up * v;
        // ����ȭ ����
        dir.Normalize();
        //Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;

        // �¿� �̵�
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


        // �� ������ �ȳ�����
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftRange, rightRange), (transform.position.y, upRange, downRange));

        // �����̴� ���⿡ ���� �����Ѵ�.
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
            // ���� �� �ʱ�ȭ
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
