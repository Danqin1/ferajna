using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private Button main;
    [SerializeField] private GameObject menuPanel;

    void Start()
    {
        main.onClick.AddListener(() => {
            menuPanel.SetActive(true);
            main.gameObject.SetActive(false);
            });
    }

    private void OnDestroy()
    {
        main.onClick.RemoveAllListeners();
    }

    public void CloseMainMenu()
    {
        menuPanel.SetActive(false);
        main.gameObject.SetActive(true);
    }
}
