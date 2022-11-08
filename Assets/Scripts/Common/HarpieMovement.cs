using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HarpieMovement : MonoBehaviour
{
    [SerializeField]
    float xLeftRange;
    [SerializeField]
    float xRightRange;
    [SerializeField]
    float speed;

    Animator animator;
    int a = 1;


    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        // Ư�� ��ġ���� ���� �Ǹ�
        if (transform.localPosition.x < xLeftRange)
        {
            // ���� ��ȣ ����
            a = -1;
        }
        else if (transform.localPosition.x > xRightRange)
        {
            a = 1;
        }

        // �� ���� ��ȣ�� ���� Enemy�� �����̴� ������ �޶����� ��
        transform.Translate(Vector3.left * speed * Time.deltaTime * a);


        //AnimationUpdate();
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

