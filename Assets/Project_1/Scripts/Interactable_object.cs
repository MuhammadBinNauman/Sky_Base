using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable_object : MonoBehaviour
{

    public bool is_activated = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void interactable_activated()
    {
        if (!is_activated)
        {
            is_activated = true;
            Debug.Log("Interactible is activated");
        }
    }
}
