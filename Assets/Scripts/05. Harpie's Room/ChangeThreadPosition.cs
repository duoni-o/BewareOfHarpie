using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeThreadPosition : MonoBehaviour
{
    [SerializeField]
    Transform thread_position;
    [SerializeField]
    Transform target_position;

    void Update()
    {
        thread_position.position = Vector2.MoveTowards(thread_position.position, target_position.position, 5.0f * Time.deltaTime);
    }
}
