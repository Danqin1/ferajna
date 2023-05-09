using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    [SerializeField] private bool autoSetup;
    [SerializeField] private RectTransform mainUI;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float scrollSpeed = 0.001f;
    [SerializeField] private float cardWidth = 400f;
    [SerializeField] private List<Transform> panels;

    private HorizontalLayoutGroup layoutGroup;
    private int childsCount;
    private List<float> childPoints = new List<float>();
    private float distance;
    private float value = 0;
    private bool isSetupReady = false;

    private void Start()
    {
        if (autoSetup) Setup();
    }

    void Update()
    {
        if (!isSetupReady) return;

        if(Input.GetMouseButton(0) || Input.mouseScrollDelta.y != 0 || Input.mouseScrollDelta.x != 0)
        {
            value = scrollbar.value;
        }
        else
        {
            for (int i = 0; i < childPoints.Count; i++)
            {
                if (value < childPoints[i] + distance / 2f && value > childPoints[i] - distance / 2f)
                {
                    panels[i].localScale = Vector3.Lerp(panels[i].localScale, Vector3.one, .1f);//Vector3.one;

                    if (Mathf.Abs(value - childPoints[i]) > .01f)
                    {
                        scrollbar.value = Mathf.Clamp01( Mathf.Lerp(scrollbar.value, childPoints[i], Time.deltaTime * lerpSpeed) );
                    }
                    
                }
                else
                {
                    panels[i].localScale = Vector3.Lerp(panels[i].localScale, Vector3.one * .7f, .1f);
                }
            }
        }
    }

    public void AddPanel(Card card)
    {
        panels.Add(card.transform);
    }

    public void Setup()
    {
        layoutGroup = GetComponent<HorizontalLayoutGroup>();
        layoutGroup.padding.left = (int)((mainUI.rect.width - cardWidth) / 2f);
        layoutGroup.padding.right = (int)((mainUI.rect.width - cardWidth) / 2f);
        childsCount = panels.Count;

        distance = 1f / ((float)childsCount - 1f);

        for (int i = 0; i < childsCount; i++)
        {
            childPoints.Add(i * distance);
        }

        isSetupReady = true;
    }
}
