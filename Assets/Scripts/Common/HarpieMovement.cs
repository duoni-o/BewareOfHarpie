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
        // 특정 위치까지 가게 되면
        if (transform.localPosition.x < xLeftRange)
        {
            // 변수 부호 변경
            a = -1;
        }
        else if (transform.localPosition.x > xRightRange)
        {
            a = 1;
        }

        // 위 변수 부호에 따라 Enemy가 움직이는 방향이 달라지게 됨
        transform.Translate(Vector3.left * speed * Time.deltaTime * a);


        //AnimationUpdate();
    }

    /*void AnimationUpdate()
    {
        if (플레이어 발견)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }*/
}

