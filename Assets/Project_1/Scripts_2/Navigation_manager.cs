using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation_manager : Manager<Navigation_manager>
{

    public float normal_height = 1.2f;

    private walk_On_Surface walkOnSurface;
    // Start is called before the first frame update
    void Start()
    {
        walkOnSurface = GetComponent<walk_On_Surface>();
    }

    private void OnEnable()
    {
        AltRealityARManager.onExperienceStart += OnExperianceStart;
        AltRealityARManager.onExperienceReset += OnExperianceReset;
    }

    private void OnDisable()
    {
        AltRealityARManager.onExperienceStart -= OnExperianceStart;
        AltRealityARManager.onExperienceReset -= OnExperianceReset;
    }

    private void OnExperianceStart()
    {
        walkOnSurface.enabled = true;
    }

    private void OnExperianceReset()
    {
        walkOnSurface.enabled = false;
    }
}
