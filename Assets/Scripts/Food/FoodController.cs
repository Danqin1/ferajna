using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] private FoodSettings settings;
    [SerializeField] private Card foodPanelPrefab;
    [Space]
    [SerializeField] private GameObject pizzaPanel;
    [SerializeField] private GameObject setsPanel;
    [SerializeField] private GameObject sandwichesPanel;
    [SerializeField] private GameObject snacksPanel;
    [SerializeField] private GameObject salatsPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private float lerpSpeed = 0.05f;
    [Space(10)]
    [SerializeField] private Transform pizzaRoot;
    [SerializeField] private Transform setsRoot;
    [SerializeField] private Transform sandwichesRoot;
    [SerializeField] private Transform snacksRoot;
    [SerializeField] private Transform salatsRoot;

    private GameObject currentPanel;

    void Start()
    {
        currentPanel = mainPanel;
        Setup();
    }

    public void OnBack()
    {
        if(mainPanel.activeSelf)
        {
            AppController.Instance.ChangeState(AppState.Main);
        }
        else
        {
            ChangeToMain();
        }
    }

    private void CloseCurrent()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut(currentPanel));
    }

    private void ChangeToMain()
    {
        CloseCurrent();
        currentPanel = mainPanel;
        StartCoroutine(FadeIn(currentPanel));
    }

    public void ChangeToPizza()
    {
        CloseCurrent();
        currentPanel = pizzaPanel;
        StartCoroutine(FadeIn(currentPanel));
    }

    public void ChangeToSets()
    {
        CloseCurrent();
        currentPanel = setsPanel;
        StartCoroutine(FadeIn(currentPanel));
    }

    public void ChangeToSandwiches()
    {
        CloseCurrent();
        currentPanel = sandwichesPanel;
        StartCoroutine(FadeIn(currentPanel));
    }

    public void ChangeToSnacks()
    {
        CloseCurrent();
        currentPanel = snacksPanel;
        StartCoroutine(FadeIn(currentPanel));
    }

    public void ChangeToSalats()
    {
        CloseCurrent();
        currentPanel = salatsPanel;
        StartCoroutine(FadeIn(currentPanel));
    }

    private IEnumerator FadeOut(GameObject panel)
    {
        if (!panel.activeSelf) yield break;

        var renderer = panel.GetComponent<CanvasGroup>();
        renderer.interactable = false;

        float lerp = 1;
        while (lerp > 0)
        {
            renderer.alpha = lerp;
            lerp -= lerpSpeed;
            yield return null;
        }

        renderer.alpha = 0;
        renderer.blocksRaycasts = false;
        panel.SetActive(false);

        yield return null;
    }

    private IEnumerator FadeIn(GameObject panel)
    {
        var renderer = panel.GetComponent<CanvasGroup>();
        renderer.interactable = false;
        panel.SetActive(true);

        float lerp = 0;
        while (lerp < 1)
        {
            renderer.alpha = lerp;
            lerp += lerpSpeed;
            yield return null;
        }

        renderer.alpha = 1;
        renderer.interactable = true;
        renderer.blocksRaycasts = true;

        yield return null;
    }

    private void Setup()
    {
        var content = pizzaRoot.GetComponent<Content>();

        settings.Pizzas.ForEach(p =>
        {
            var card = Instantiate(foodPanelPrefab, pizzaRoot);
            card.Populate(p.name, p.description,p.price, p.sprite);
            content.AddPanel(card);
        });

        content.Setup();

        content = snacksRoot.GetComponent<Content>();

        settings.Snacks.ForEach(p =>
        {
            var card = Instantiate(foodPanelPrefab, snacksRoot);
            card.Populate(p.name, p.description, p.price, p.sprite);
            content.AddPanel(card);
        });

        content.Setup();

        content = sandwichesRoot.GetComponent<Content>();

        settings.Sandwiches.ForEach(p =>
        {
            var card = Instantiate(foodPanelPrefab, sandwichesRoot);
            card.Populate(p.name, p.description, p.price, p.sprite);
            content.AddPanel(card);
        });

        content.Setup();

        content = setsRoot.GetComponent<Content>();

        settings.Sets.ForEach(p =>
        {
            var card = Instantiate(foodPanelPrefab, setsRoot);
            card.Populate(p.name, p.description, p.price, p.sprite);
            content.AddPanel(card);
        });

        content.Setup();

        content = salatsRoot.GetComponent<Content>();

        settings.Salats.ForEach(p =>
        {
            var card = Instantiate(foodPanelPrefab, salatsRoot);
            card.Populate(p.name, p.description, p.price, p.sprite);
            content.AddPanel(card);
        });

        content.Setup();
    }
}
