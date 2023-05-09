using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    public void OnBack()
    {
        AppController.Instance.ChangeState(AppState.Welcome);
    }

    public void OnMenu()
    {
        AppController.Instance.ChangeState(AppState.Menu);
    }

    public void OnContact()
    {
        AppController.Instance.ChangeState(AppState.Contact);
    }

    public void OnGallery()
    {
        AppController.Instance.ChangeState(AppState.Gallery);
    }
}
