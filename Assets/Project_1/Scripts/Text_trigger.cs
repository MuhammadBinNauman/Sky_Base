using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_trigger : MonoBehaviour
{
    public bool is_activated = false;
    public GameObject text;
    public float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("here");
        if (is_activated)
        {
            time = time + Time.fixedDeltaTime;
            Time.timeScale = 0.1f;
            Debug.Log(time);
            if (time > 30f)
            {
                text.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void interactable_activated()
    {
        if (!is_activated)
        {
            Debug.Log("2here");
            is_activated = true;
            text.SetActive(true);
            time = time + Time.fixedDeltaTime;
        }
        if (time > 10f)
        {
            text.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
