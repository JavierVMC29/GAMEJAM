using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange = 4f;
    LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Interactable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(interactorSource.position, interactorSource.forward, out RaycastHit hitInfo, 4f, layerMask, QueryTriggerInteraction.Collide))
            {
                Debug.Log("Raycast 1: ", hitInfo.collider);
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    Debug.Log("Raycast");
                    interactObj.Interact();
                }
            }
        }
    }
}
