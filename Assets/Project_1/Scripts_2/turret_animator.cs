using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret_animator : MonoBehaviour
{
    public LayerMask turret_activate;
    public LayerMask turret_activate_2;
    public LayerMask turret_activate_3;
    public LayerMask fire_1;
    public LayerMask fire_2;
    public LayerMask fire_3;
    GameObject Effects;
    public ParticleSystem particle;
    public ParticleSystem particle_2;
    public ParticleSystem particle_3;
    public ParticleSystem particle_4;
    public ParticleSystem particle_5;
    public ParticleSystem particle_6;

    void FixedUpdate()
    {
        FlyInEditor();

        FlyInPhone();
    }

    private void FlyInEditor()
    {
        Ray ray;
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 50, turret_activate))
            {
                particle.Play();
                Debug.Log("is working");
            }
            if (Physics.Raycast(ray, out hit, 50, turret_activate_2))
            {
                particle_2.Play();
                Debug.Log("is working");
            }
            if (Physics.Raycast(ray, out hit, 50, turret_activate_3))
            {
                particle_3.Play();
                Debug.Log("is working");
            }
            if (Physics.Raycast(ray, out hit, 50, fire_1))
            {
                particle_4.Play();
                Debug.Log("is working");
            }
            if (Physics.Raycast(ray, out hit, 50, fire_2))
            {
                particle_5.Play();
                Debug.Log("is working");
            }
            if (Physics.Raycast(ray, out hit, 50, fire_3))
            {
                particle_6.Play();
                Debug.Log("is working");
            }
        }
    }
    private void FlyInPhone()
    {
        if (Input.touchCount == 0) return;

        Ray ray;
        RaycastHit hit;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, 50f, turret_activate))
            {
                particle.Play();
            }
            if (Physics.Raycast(ray, out hit, 50, turret_activate_2))
            {
                particle_2.Play();
            }
            if (Physics.Raycast(ray, out hit, 50, turret_activate_3))
            {
                particle_3.Play();
            }
            if (Physics.Raycast(ray, out hit, 50, fire_1))
            {
                particle_4.Play();
            }
            if (Physics.Raycast(ray, out hit, 50, fire_2))
            {
                particle_5.Play();
            }
            if (Physics.Raycast(ray, out hit, 50, fire_3))
            {
                particle_6.Play();
            }
        }
    }
}
