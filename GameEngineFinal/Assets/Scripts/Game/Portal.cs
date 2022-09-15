using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform teleport;
    [SerializeField] Canvas win;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleport.position;
            win.gameObject.SetActive(true);
        }
    }
}
