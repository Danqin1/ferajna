using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselController : MonoBehaviour
{
    [SerializeField] private PathCreator creator;
    [SerializeField] private float distance;
    [SerializeField] private List<PathFollower> followers;
    [SerializeField] private float spacing = 1f;

    void Start()
    {
        //float distPerFollower = distance / followers.Count;
        for (int i = 0; i < followers.Count; i++)
        {
            followers[i].Setup(new Vector2(spacing * (followers.Count - i), distance - i * spacing), spacing * (followers.Count - i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
