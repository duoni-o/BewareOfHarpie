/*
 * 작성자: 이주원
 * 바늘이 활성화 된 경우 정해둔 위치로 옮기는 스크립트
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNeedlePosition : MonoBehaviour
{
    // 현재 실의 위치
    [SerializeField]
    Transform needle_position;
    // 옮기고 싶은 위치
    [SerializeField]
    Transform target_position;

    void Update()
    {
        // 현재 위치에서 옮기고 싶은 위치로 이동
        needle_position.position = Vector2.MoveTowards(needle_position.position, target_position.position, 5.0f * Time.deltaTime);
    }

}
