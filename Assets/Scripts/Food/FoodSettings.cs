using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pizza
{
    public string name;
    public string description;
    public Sprite sprite;
    public string price;
}

[System.Serializable]
public class Set
{
    public string name;
    public string description;
    public Sprite sprite;
    public string price;
}

[System.Serializable]
public class Sandwich
{
    public string name;
    public string description;
    public Sprite sprite;
    public string price;
}

[System.Serializable]
public class Snack
{
    public string name;
    public string description;
    public Sprite sprite;
    public string price;
}

[System.Serializable]
public class Salat
{
    public string name;
    public string description;
    public Sprite sprite;
    public string price;
}

[CreateAssetMenu(menuName = "Ferajna/FoodSettings")]
public class FoodSettings : ScriptableObject
{
    [SerializeField] private List<Pizza> pizzas;
    [SerializeField] private List<Sandwich> sandwiches;
    [SerializeField] private List<Snack> snacks;
    [SerializeField] private List<Set> sets;
    [SerializeField] private List<Salat> salats;

    public List<Pizza> Pizzas => pizzas;
    public List<Snack> Snacks => snacks;
    public List<Sandwich> Sandwiches => sandwiches;
    public List<Set> Sets => sets;
    public List<Salat> Salats => salats;
}
