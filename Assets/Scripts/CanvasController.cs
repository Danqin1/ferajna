using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private AppController controller;
    [SerializeField] private AnimationCurve moveCurve;

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
        switch (state)
        {
            case AppState.Main:
                break;
            case AppState.Menu:
                break;
            case AppState.Contact:
                break;
            case AppState.Gallery:
                break;

        }
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
