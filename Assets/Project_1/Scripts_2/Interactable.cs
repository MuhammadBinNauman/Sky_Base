using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InteractableType { Grab, Force, Spin, Push }

[RequireComponent(typeof(Rigidbody))]

public class Interactable : MonoBehaviour
{

    [Header("Feedback")]
    public Renderer renderer;
    public Color highlight_color = Color.black;
    private Material material;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private Rigidbody rigidbody;
    private Vector3 touch_offset;
    public InteractableType interactableType = InteractableType.Force;

    private float start_angle;
    private Quaternion start_roation;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (renderer == null)
        {
            renderer = GetComponentInChildren<Renderer>();
        }
        material = renderer.material;

        if (highlight_color == Color.black)
        {
            highlight_color = material.color;
        }
        material.EnableKeyword("_EMISSION");

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouchDown(Vector3 startTouchPosition)
    {
        Debug.Log("hi");

        touch_offset = startTouchPosition - transform.position;
        start_roation = rigidbody.rotation;
        start_angle = Mathf.Atan2(startTouchPosition.z- rigidbody.position.z, startTouchPosition.x - rigidbody.position.x);


        if (interactableType == InteractableType.Grab || interactableType == InteractableType.Spin)
        {
            rigidbody.isKinematic = true;
        }

        material.SetColor("_EmissionColor", highlight_color);
    }

    public void OnTouchUp()
    {
        Debug.Log("bye");
        rigidbody.isKinematic = false;

        material.SetColor("_EmissionColor", Color.green);
    }

    public void Move(Vector3 CurrentTouchPosition)
    {
        switch (interactableType)
        {
            case InteractableType.Grab:
                Move_pos(CurrentTouchPosition);
                break;
            case InteractableType.Force:
                AddForce(CurrentTouchPosition);
                break;
            case InteractableType.Spin:
                MoveRotation(CurrentTouchPosition);
                break;
            case InteractableType.Push:
                break;
        }
    }

    private void AddForce(Vector3 currentTouchPosition)
    {
        Vector3 force = currentTouchPosition - rigidbody.position;
        rigidbody.AddForce(force * Time.deltaTime * 2000f);
    }

    private void Move_pos(Vector3 currentTouchPosition)
    {
        Vector3 final_pos = currentTouchPosition - touch_offset;
        rigidbody.MovePosition(final_pos);
    }

    private void MoveRotation(Vector3 currentTouchPosition)
    {
        float current_angle = Mathf.Atan2(currentTouchPosition.z - rigidbody.position.z, currentTouchPosition.x - rigidbody.position.x);
        float angleDifference = current_angle - start_angle;
        angleDifference *= -1f;
        angleDifference *= Mathf.Rad2Deg;

        rigidbody.MoveRotation(start_roation * Quaternion.Euler(0,angleDifference,0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        float relativeForece = collision.relativeVelocity.magnitude;

        audioSource.pitch = Mathf.Clamp(relativeForece / 3f, 0.8f, 2f);
        audioSource.PlayOneShot(audioClip, Mathf.Clamp01(relativeForece * 0.05f));
    }
}
