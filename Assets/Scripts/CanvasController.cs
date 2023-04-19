using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private MainUIController mainUIController;
    [SerializeField] private AnimationCurve moveCurve;

    void Start()
    {
        mainUIController.OnMain.AddListener(() => ChangeState(AppState.Main));
        mainUIController.OnMenu.AddListener(() => ChangeState(AppState.Menu));
        mainUIController.OnGallery.AddListener(() => ChangeState(AppState.Gallery));
        mainUIController.OnContact.AddListener(() => ChangeState(AppState.Contact));
    }

    private void OnDestroy()
    {
        mainUIController.OnMain.RemoveAllListeners();
        mainUIController.OnMenu.RemoveAllListeners();
        mainUIController.OnGallery.RemoveAllListeners();
        mainUIController.OnContact.RemoveAllListeners();
    }

    public void ChangeState(AppState state)
    {
        Debug.Log("New State:" + state);
        StopAllCoroutines();
        switch (state)
        {
            case AppState.Main:
                StartCoroutine(Rotate(Vector3.forward));
                break;
            case AppState.Menu:
                StartCoroutine(Rotate(Vector3.right));
                break;
            case AppState.Contact:
                StartCoroutine(Rotate(Vector3.left));
                break;
            case AppState.Gallery:
                StartCoroutine(Rotate(Vector3.back));
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
