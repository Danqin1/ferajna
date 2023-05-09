using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;

    private void Update()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            var rot = transform.rotation.eulerAngles;
            rot.y += Input.mouseScrollDelta.y * scrollSpeed;

            transform.rotation = Quaternion.Euler(rot);
        }
    }
}
