using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public enum AppState
{
    Main = 0,
    Menu = 1,
    Contact = 2,
    Gallery = 3,
    About,
    Changing
}

public class AppController : MonoBehaviour
{
    public UnityAction<AppState> OnStateChange;

    private AppState state;
    // Start is called before the first frame update

    private void Start()
    {
        ChangeState(0);
    }
    public void ChangeState(int _state)
    {
        state = (AppState)_state;

        OnStateChange?.Invoke(state);
    }
}
