using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_hotspot : MonoBehaviour
{

    private Transform mainCamera;
    private Transform arSessionOrigin;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
        arSessionOrigin = mainCamera.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ontap()
    {
        float distance = Vector3.Distance(transform.position, mainCamera.position);
        Vector3 destenation = transform.position - mainCamera.localPosition;
        LeanTween.move(arSessionOrigin.gameObject, destenation + Vector3.up, distance / 2f);
    }
}
