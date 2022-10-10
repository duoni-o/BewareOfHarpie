using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PrologueManager : MonoBehaviour
{
    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = MoveToApplicationForm();
        StartCoroutine(coroutine);
    }

    [YarnCommand("custom_wait")]
    private IEnumerator MoveToApplicationForm()
    {
        yield return new WaitForSeconds(0.1f);

    }

}
