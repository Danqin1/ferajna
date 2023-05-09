using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var image = GetComponent<Image>();
        var sprite = image.sprite;
        if (sprite == null) return;

        float ratio = (float)sprite.texture.height / (float)sprite.texture.width;
        var rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x,rect.sizeDelta.x * ratio);
        rect.ForceUpdateRectTransforms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
