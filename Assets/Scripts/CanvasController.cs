using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private AppController controller;
    [SerializeField] private AnimationCurve moveCurve;
    [SerializeField] private GameObject foodPanel;
    [SerializeField] private GameObject welcomePanel;

    private void Awake()
    {
        controller.OnStateChange += OnChangeState;
    }

    private void OnDestroy()
    {
        controller.OnStateChange -= OnChangeState;
    }

    public void OnChangeState(AppState state)
    {
        StopAllCoroutines();
        DisablePanels();

        switch (state)
        {
            case AppState.Main:
                welcomePanel.SetActive(true);
                break;
            case AppState.Menu:
                foodPanel.SetActive(true);
                break;
            case AppState.Contact:
                break;
            case AppState.Gallery:
                break;

        }
    }
    
    private void DisablePanels()
    {
        welcomePanel.SetActive(false);
        foodPanel.SetActive(false);
    }

    private IEnumerator Rotate(Vector3 target)
    {
        Quaternion startRot = transform.rotation;

        Quaternion targetRot = Quaternion.LookRotation(target, Vector3.up);

        float lerp = 0;
        while (lerp < 1)
        {
            transform.rotation = Quaternion.Slerp(startRot, targetRot, moveCurve.Evaluate(lerp));
            lerp += .001f;
            yield return null;
        }

        yield return null;
    }
}
