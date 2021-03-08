using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interact : MonoBehaviour
{
    public bool is_in_range = false;
    public KeyCode interactableKey;
    public UnityEvent interactable;
    void Start()
    {

    }


    void Update()
    {
        if (is_in_range)
        {
            
                interactable.Invoke();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            is_in_range = true;
            Debug.Log("player is in range");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            is_in_range = false;
            Debug.Log("player is NOT in range");
        }
    }
}
