using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraState
{
    Main,
    Menu,
    Contact,
    Gallery
}

public class CameraController : MonoBehaviour
{
    [SerializeField] private MainUIController mainUIController;
    [SerializeField] private AnimationCurve moveCurve;

    private Animator animator;
    private CameraState state;

    void Start()
    {
        animator = GetComponent<Animator>();
        mainUIController.OnMain.AddListener(() => ChangeState(CameraState.Main));
        mainUIController.OnMenu.AddListener(() => ChangeState(CameraState.Menu));
        mainUIController.OnGallery.AddListener(() => ChangeState(CameraState.Gallery));
        mainUIController.OnContact.AddListener(() => ChangeState(CameraState.Contact));
    }

    private void OnDestroy()
    {
        mainUIController.OnMain.RemoveAllListeners();
        mainUIController.OnMenu.RemoveAllListeners();
        mainUIController.OnGallery.RemoveAllListeners();
        mainUIController.OnContact.RemoveAllListeners();
    }

    public void ChangeState(CameraState state)
    {
        Debug.Log("New State:" + state);
        StopAllCoroutines();
        switch (state)
        {
            case CameraState.Main:
                StartCoroutine(Rotate(Vector3.forward));
                break;
            case CameraState.Menu:
                StartCoroutine(Rotate(Vector3.right));
                break;
            case CameraState.Contact:
                StartCoroutine(Rotate(Vector3.left));
                break;
            case CameraState.Gallery:
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
