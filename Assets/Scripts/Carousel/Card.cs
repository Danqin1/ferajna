using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Text tittle;
    [SerializeField] private Text description;
    [SerializeField] private Image image;
    [SerializeField] private Text price;


    public void Populate(string _tittle, string _description,string _price, Sprite _sprite)
    {
        tittle.text = _tittle;
        description.text = _description;
        image.sprite = _sprite;
        price.text = _price;
    }
}
