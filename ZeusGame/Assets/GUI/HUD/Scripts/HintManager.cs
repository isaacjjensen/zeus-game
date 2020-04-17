using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    private Queue<Hint> hintQueue = new Queue<Hint>();
    private Hint currentHint;
    private bool isProcessing = false;

    public class Hint
    {
        public string message;
        public float messageDuration;

        public Hint (string inMessage, float inDuration)
        {
            message = inMessage;
            messageDuration = inDuration;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isProcessing && hintQueue.Count > 0)
        {
            ProcessHintMessages();
        }
    }

    public void SubmitHintMessage(string message, float duration)
    {
        hintQueue.Enqueue(new Hint(message, duration));
    }

    private void ProcessHintMessages()
    {
        isProcessing = true;
        while (hintQueue.Count > 0)
        {
            Hint hint = hintQueue.Dequeue();
            SetDisplayText(hint);
            StartCoroutine(DelayedClear(hint));
        }
        isProcessing = false;
    }

    private void SetDisplayText(Hint hint)
    {
        currentHint = hint;
        gameObject.GetComponent<TextMeshProUGUI>().text = hint.message;
    }

    private void ClearDisplayText()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }

    IEnumerator DelayedClear(Hint hint)
    {
        yield return new WaitForSeconds(hint.messageDuration);

        if (hint == currentHint)
        {
            ClearDisplayText();
        }
    }
}
