/*
 * ��ũ��Ʈ��: HarpieMovement
 * �ۼ���: ���ֿ�
 * �ۼ�����: 2022.11.14
 * ����: ������ �������� �����ϴ� ��ũ��Ʈ�Դϴ�.
 * �÷��̾� ��ó�� ��ȸ�ϴٰ� �÷��̾ ���� ���� ���� ������ �÷��̾ �Ѿƿɴϴ�.
 * �÷��̾ ���� �ڿ� ������ �÷��̾ �Ѵ� �� ���߰� �ٽ� ��ó�� ��ȸ�մϴ�.
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
    [Header("�÷��̾�� ���� �� �Ÿ�")]
    [SerializeField]
    float pdDistance;
    [Header("���� �Դٰ��� �ϴ� �Ÿ�")]
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
        
        //AnimationUpdate();
    }

    private void HarpieRoutine()
    {
        leftRange = target.position.x - phDistance;
        rightRange = target.position.x + phDistance;

        // Ư�� ��ġ���� ���� �Ǹ�
        if (transform.localPosition.x < leftRange)
        {
            // ���� ��ȣ ����
            a = -1;
        }
        else if (transform.localPosition.x > rightRange)
        {
            a = 1;
        }

        // �� ���� ��ȣ�� ���� Enemy�� �����̴� ������ �޶����� ��
        transform.Translate(Vector3.left * speed * Time.deltaTime * a);

        FollowTarget();
    }

    void FollowTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > distance && follow && !overlap)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
            rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }

    private void PlayerDrawerDistance()
    {
        if (Vector2.Distance(target.position, drawer.position) < pdDistance)
        {
            overlap = true;
            //Debug.Log(Vector2.Distance(target.position, drawer.position));
        }
        else
            overlap = false;
    }

    /*void AnimationUpdate()
    {
        if (�÷��̾� �߰�)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }*/
}

