using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private AnimationCurve moveCurve;
    [SerializeField] private Transform changingStateRef;
    [SerializeField] private Transform mainStateRef;
    [SerializeField] private Transform menuStateRef;
    [SerializeField] private Transform galleryStateRef;
    [SerializeField] private Transform constactStateRef;
    [SerializeField] private float changingTime;
    [SerializeField] private float changingAnimationTime = 2;

    private Animator animator;

    private int changeScreen = Animator.StringToHash("Change");
    private int point = Animator.StringToHash("Pointing");
    private int looking = Animator.StringToHash("Looking");
    private int idle = Animator.StringToHash("Idle");
    private int hello = Animator.StringToHash("Hello");

    void Start()
    {
        animator = GetComponent<Animator>();
        AppController.Instance.OnStateChange += OnChangeState;
    }

    public void OnChangeState(AppState state)
    {
        StopAllCoroutines();

        switch (state)
        {
            case AppState.Main:
                OnAnimState(state);
                break;
            case AppState.Menu:
                StartCoroutine(Change(menuStateRef, state));
                break;
            case AppState.Contact:
                StartCoroutine(Change(constactStateRef, state));
                break;
            case AppState.Gallery:
                StartCoroutine(Change(galleryStateRef, state));
                break;

        }
    }

    public void OnChangeScreen()
    {
        //animator.SetTrigger(changeScreen);
    }

    private void OnAnimState(AppState state)
    {
        switch (state)
        {
            case AppState.Main:
                animator.SetTrigger(hello);
                break;
            case AppState.Menu:
                animator.SetTrigger(point);
                break;
            case AppState.Contact:
                animator.SetTrigger(changeScreen);
                break;
            case AppState.Gallery:
                animator.SetTrigger(looking);
                break;

        }
    }

    private IEnumerator Change(Transform target, AppState state)
    {
        Quaternion startRot = transform.rotation;
        Quaternion targetRot = target.rotation;

        OnChangeScreen();
        float lerp = 0;
        while (lerp < 1)
        {
            transform.rotation = Quaternion.Slerp(startRot, changingStateRef.rotation, moveCurve.Evaluate(lerp));

            lerp += .001f;
            yield return new WaitForSeconds(changingTime / 1000);
        }

        yield return new WaitForSeconds(changingAnimationTime);

        startRot = transform.rotation;
        lerp = 0;
        while (lerp < 1)
        {
            transform.rotation = Quaternion.Slerp(startRot, targetRot, moveCurve.Evaluate(lerp));

            lerp += .001f;
            yield return new WaitForSeconds(changingTime / 1000);
        }
        OnAnimState(state);

        yield return null;
    }
}
