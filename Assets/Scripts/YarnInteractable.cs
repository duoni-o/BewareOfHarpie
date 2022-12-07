using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YarnInteractable : MonoBehaviour {
    [SerializeField] private string conversationStartNode;

    //[SerializeField] Image fadeOutImage;

    private DialogueRunner dialogueRunner;
    private bool interactable = true;
    private bool isCurrentConversation = false;
    private float defaultIndicatorIntensity;

    bool isNeedleActive = false;
    bool isThreadActive = false;

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
    }

    private void Update()
    {
        if (isNeedleActive && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("¹Ù´Ã È¹µæ");
            GameObject.Find("Needle").SetActive(false);
        }
        if (isThreadActive && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("½Ç È¹µæ");
            GameObject.Find("Thread").SetActive(false);
        }
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
                // ??????????
                //StartCoroutine(FadeOutCoroutine());
                SceneManager.LoadScene("01. Prologue_dump");
            }
            if (name == "Player_broken")
            {
                // ??????????
                SceneManager.LoadScene("02. Title");
            }
            if (name == "Box_cotton")
            {
                GameObject.Find("Box_cotton").gameObject.SetActive(false);
            }
            if (name == "Get_cotton")
            {
                GameObject.Find("Cotton").gameObject.SetActive(false);
            }
            if (name == "Get_button")
            {
                GameObject.Find("Get_button").gameObject.SetActive(false);
            }
            if (name == "Bed_answer")
            {
                SceneManager.LoadScene("HappyEnding");
            }
            if (name == "Bed")
            {
                SceneManager.LoadScene("BadEnding");
            }
            if (name == "Sofa_needle")
            {
                GameObject.Find("Sofa_needle").transform.Find("Needle").gameObject.SetActive(true);
                isNeedleActive = true;
            }
            if (name == "Eye_thread")
            {
                GameObject.Find("Thread_parent").transform.Find("Thread").gameObject.SetActive(true);
                //GameObject.Find("Eye_thread").gameObject.SetActive(false);
                isThreadActive = true;
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