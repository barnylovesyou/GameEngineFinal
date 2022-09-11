using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject plate;
    private bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            // enter activation behaviour here
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Activated");
            Vector3 adjust = new Vector3(0f, -0.025f, 0f);
            activated = true;
            plate.transform.position += adjust;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Deactivated");
            Vector3 adjust = new Vector3(0f, 0.025f, 0f);
            activated = false;
            plate.transform.position += adjust;
        }
    }
}
