using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YarnInteractable : MonoBehaviour {
    [SerializeField] private string conversationStartNode;

    //[SerializeField]
    //Image fadeOutImage;

    private DialogueRunner dialogueRunner;
    private bool interactable = true;
    private bool isCurrentConversation = false;
    private float defaultIndicatorIntensity;

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
    }

    public void OnMouseDown() {
        if (interactable && !dialogueRunner.IsDialogueRunning) {
            StartConversation();
            if (name == "Player_broken")
            {
                GameObject.Find("Player_broken").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("Player_broken_png").gameObject.SetActive(true);
            }
        }
    }

    private void StartConversation() {
        Debug.Log($"Started conversation with {name}.");
        isCurrentConversation = true;
        dialogueRunner.StartDialogue(conversationStartNode);
    }

    private void EndConversation() {
        if (isCurrentConversation) {
            isCurrentConversation = false;
            Debug.Log($"End conversation with {name}.");
            if (name == "Newspaper")
            {
                GameObject.Find("Newspaper").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("ApplicationForm").gameObject.SetActive(true);
            }
            if (name == "Submit")
            {
                GameObject.Find("Canvas").transform.Find("Submit_completed").gameObject.SetActive(true);
            }
            if (name == "OK")
            {
                // ÆäÀÌµå¾Æ¿ô
                //StartCoroutine(FadeOutCoroutine());
                SceneManager.LoadScene("Prologue_dump");
            }
            if (name == "Player_broken")
            {
                // ÆäÀÌµå¾Æ¿ô
                SceneManager.LoadScene("Title");
            }
        }
    }

//    [YarnCommand("disable")]
    public void DisableConversation() {
        interactable = false;
    }

    /*IEnumerator FadeOutCoroutine()
    {
        GameObject.Find("Canvas").transform.Find("FadeOutImage").gameObject.SetActive(true);
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeOutImage.color = new Color(0, 0, 0, fadeCount);
        }
    }*/
}