using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    public UnityEvent OnMain;
    public UnityEvent OnMenu;
    public UnityEvent OnContact;
    public UnityEvent OnGallery;

    [SerializeField] private Button main;
    [SerializeField] private Button menu;
    [SerializeField] private Button contact;
    [SerializeField] private Button gallery;

    void Start()
    {
        main.onClick.AddListener(Main);
        menu.onClick.AddListener(Manu);
        contact.onClick.AddListener(Gallery);
        gallery.onClick.AddListener(Contact);
    }

    private void OnDestroy()
    {
        main.onClick.RemoveListener(Main);
        menu.onClick.RemoveListener(Manu);
        main.onClick.RemoveListener(Gallery);
        menu.onClick.RemoveListener(Contact);
    }

    private void Main()
    {
        OnMain.Invoke();
    }

    private void Manu()
    {
        OnMenu.Invoke();
    }

    private void Gallery()
    {
        OnGallery.Invoke();
    }

    private void Contact()
    {
        OnContact.Invoke();
    }
}
