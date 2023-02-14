using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaygunInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject raygun;
    [SerializeField]
    private GameObject ammmoLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        raygun.SetActive(true);
        ammmoLevel.SetActive(true);
        Destroy(gameObject);
    }
}
