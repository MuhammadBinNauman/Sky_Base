using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_manager : MonoBehaviour
{
    public Camera main_camera;
    public LayerMask interactable_AR_Object;
    private Interactable current_interactable;
    private Vector3 startTouchPos;
    private float start_interact_distence;

    void Start()
    {
        main_camera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DetectFingierInEditor();

       // DetectFingierInPhone();

        move_interactable();
    }


    private void move_interactable()
    {
        if (current_interactable)
        {
            Vector3? touch_position = GetTouchPosition();

            if (!touch_position.HasValue) return;

            Vector3 current_Touch_Position_In_World = main_camera.ScreenToWorldPoint((Vector3)touch_position);
            current_interactable.Move(current_Touch_Position_In_World);
        }
    }

    private Vector3? GetTouchPosition()
    {
        return new Vector3(Input.mousePosition.x, Input.mousePosition.y, start_interact_distence);
        if (Input.touchCount == 0) return null;

        Vector3 touch_position = Input.GetTouch(0).position;
        return new Vector3(touch_position.x, touch_position.y, start_interact_distence);
    }

    private void DetectFingierInEditor()
    {
        Ray ray;
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            ray = main_camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50f, interactable_AR_Object))
            {
                Interactable interactable = hit.rigidbody.GetComponent<Interactable>();

                if (interactable)
                {
                    current_interactable = interactable;
                    start_interact_distence = hit.distance;
                    startTouchPos = main_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, start_interact_distence));

                    current_interactable.OnTouchDown(startTouchPos);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (current_interactable)
            {
                current_interactable.OnTouchUp();
            }
            current_interactable = null;
        }
    }



    private void DetectFingierInPhone()
    {
        if (Input.touchCount == 0)
        {
            if (current_interactable)
            {
                current_interactable.OnTouchUp();
            }
            current_interactable = null;
            return;

        }
        Ray ray;
        RaycastHit hit;

        Vector3 touchposition = Input.GetTouch(0).position;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = main_camera.ScreenPointToRay(touchposition);

            if (Physics.Raycast(ray, out hit, 50f, interactable_AR_Object))
            {
                Interactable interactable = hit.rigidbody.GetComponent<Interactable>();

                if (interactable)
                {
                    current_interactable = interactable;
                    start_interact_distence = hit.distance;
                    startTouchPos = main_camera.ScreenToWorldPoint(new Vector3(touchposition.x, touchposition.y, start_interact_distence));

                    current_interactable.OnTouchDown(startTouchPos);
                }
            }
        }
    }
}
