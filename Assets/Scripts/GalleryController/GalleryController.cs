using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryController : MonoBehaviour
{
    public void OnBack()
    {
        AppController.Instance.ChangeState(AppState.Main);
    }
}
