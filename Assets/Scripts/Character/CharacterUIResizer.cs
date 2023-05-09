using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIResizer : MonoBehaviour
{
    public RectTransform refRect;
    private RectTransform thisRect;

    float width = 0;

    void Start()
    {
        thisRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if(width != refRect.rect.width)
        {
            width = refRect.rect.width;
            thisRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            thisRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, width);
        }
    }
}
