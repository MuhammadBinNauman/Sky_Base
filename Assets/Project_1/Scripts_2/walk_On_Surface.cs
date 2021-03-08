using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_On_Surface : MonoBehaviour
{

    public LayerMask groundLayer;

    [Range(.1f, 2f)]
    public float fallspeed = 1f;
    private Transform maincamera;
    private bool is_grounded;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main.transform;
    }


    // Update is called once per frame
   private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(maincamera.position, Vector3.down, out hit, 50f, groundLayer))
        {
            float heightDifference = hit.distance - Navigation_manager.Instance.normal_height;

            if (heightDifference > 0.1f)
            {
                is_grounded = false;
            }

            else if (heightDifference < 0.1f)
            {
                is_grounded = true;
                transform.position = new Vector3(transform.position.x, transform.position.y - heightDifference, transform.position.z);
            }
        }
        else
        {
            is_grounded = false;
        }

        if (!is_grounded)
        {
            transform.Translate(0, -fallspeed * Time.deltaTime, 0);
        }
    }
}
