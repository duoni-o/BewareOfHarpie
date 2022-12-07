using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNeedlePosition : MonoBehaviour
{
    [SerializeField]
    Transform needle_position;
    [SerializeField]
    Transform target_position;

    void Update()
    {
        needle_position.position = Vector2.MoveTowards(needle_position.position, target_position.position, 5.0f * Time.deltaTime);
    }

}
