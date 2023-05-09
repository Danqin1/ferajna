using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform root;

    Vector3 lookTarget = Vector3.zero;
    Vector3 startScale = Vector3.zero;

    private void Start()
    {
        startScale = transform.localScale;
        lookTarget = new Vector3(root.transform.position.x, transform.position.y, root.position.z);
    }

    void Update()
    {
        lookTarget.y = transform.position.y;
        transform.rotation = Quaternion.LookRotation(lookTarget - transform.position);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //lookTarget = root.position + Vector3.up * 1.5f;
        transform.localScale = startScale * 1.5f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //lookTarget = root.position;
        transform.localScale = startScale;
    }
}
