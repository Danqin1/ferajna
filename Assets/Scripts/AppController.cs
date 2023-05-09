using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public enum AppState
{
    Welcome,
    Main,
    Menu,
    Contact,
    Gallery,
}

public class AppController : MonoBehaviour
{
    public UnityAction<AppState> OnStateChange;

    public AppState state { get; private set; }
    // Start is called before the first frame update

    static AppController mInstance;

    public static AppController Instance
    {
        get
        {
            return mInstance ? mInstance : (mInstance = (new GameObject("MyClassContainer")).AddComponent<AppController>());
        }
    }

    private void Awake()
    {
        mInstance = this;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        //ChangeState(0);
    }
    public void ChangeState(AppState _state)
    {
        state = (AppState)_state;

        OnStateChange?.Invoke(state);
    }
}
