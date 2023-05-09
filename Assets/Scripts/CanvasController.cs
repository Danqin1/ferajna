using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private AnimationCurve moveCurve;
    [SerializeField] private GameObject foodPanel;
    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private GameObject contactPanel;
    [SerializeField] private GameObject galleryPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private float lerpSpeed = 0.05f;

    GameObject currentPanel;

    private void Awake()
    {
        AppController.Instance.OnStateChange += OnChangeState;
        welcomePanel.SetActive(true);
        currentPanel = welcomePanel;
    }

    public void OnStart()
    {
        AppController.Instance.ChangeState(AppState.Main);
    }

    public void OnChangeState(AppState state)
    {
        StopAllCoroutines();

        StartCoroutine(FadeOut(currentPanel));

        switch (state)
        {
            case AppState.Welcome:
                currentPanel = welcomePanel;
                break;
            case AppState.Main:
                currentPanel = mainPanel;
                break;
            case AppState.Menu:
                currentPanel = foodPanel;
                break;
            case AppState.Contact:
                currentPanel = contactPanel;
                break;
            case AppState.Gallery:
                currentPanel = galleryPanel;
                break;

        }

        StartCoroutine(FadeIn(currentPanel));
    }

    private IEnumerator FadeOut(GameObject panel)
    {
        if (!panel.activeSelf) yield break;

        var renderer = panel.GetComponent<CanvasGroup>();
        renderer.interactable = false;

        float lerp = 1;
        while (lerp > 0)
        {
            renderer.alpha = lerp;
            lerp -= lerpSpeed;
            yield return null;
        }

        renderer.alpha = 0;
        renderer.blocksRaycasts = false;
        panel.SetActive(false);

        yield return null;
    }

    private IEnumerator FadeIn(GameObject panel)
    {
        var renderer = panel.GetComponent<CanvasGroup>();
        renderer.interactable = false;
        panel.SetActive(true);

        float lerp = 0;
        while (lerp < 1)
        {
            renderer.alpha = lerp;
            lerp += lerpSpeed;
            yield return null;
        }

        renderer.alpha = 1;
        renderer.interactable = true;
        renderer.blocksRaycasts = true;

        yield return null;
    }
}
