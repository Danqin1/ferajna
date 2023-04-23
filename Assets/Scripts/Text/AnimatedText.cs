using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnimatedText : MonoBehaviour
{
    public UnityAction OnFinished;

    [SerializeField] private AnimatedText waitingFor;
    [SerializeField] private string content;
    [SerializeField] private float delay = .1f;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
        if (waitingFor != null)
        {
            waitingFor.OnFinished += () => StartCoroutine(Animate());
        }
        else
        {
            StartCoroutine(Animate());
        }
    }

    private IEnumerator Animate()
    {
        int length = content.Length;
        string currentText = "";
        float time = length * delay;
        for (int i = 0; i < length; i++)
        {
            currentText += content[i];
            text.text = currentText;
            yield return new WaitForSeconds(time / length);
        }

        OnFinished?.Invoke();
    }
}
