using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class YarnInteractable : MonoBehaviour {
    [SerializeField] private string conversationStartNode;

    private DialogueRunner dialogueRunner;
    private bool interactable = true;
    private bool isCurrentConversation = false;
    private float defaultIndicatorIntensity;

    [SerializeField]
    GameObject newspaper;

    public void Start() {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
    }

    public void OnMouseDown() {
        if (interactable && !dialogueRunner.IsDialogueRunning) {
            StartConversation();
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
                newspaper.SetActive(false);
                GameObject.Find("Canvas").transform.Find("ApplicationForm").gameObject.SetActive(true);
            }
            if (name == "Submit")
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

//    [YarnCommand("disable")]
    public void DisableConversation() {
        interactable = false;
    }
}