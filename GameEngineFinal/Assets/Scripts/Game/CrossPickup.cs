using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPickup : MonoBehaviour
{
    [SerializeField] bool cross1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(cross1)
            {
                other.GetComponent<PlayerVictory>().cross1 = true;
                Destroy(this.transform.parent.gameObject);
            }
            else
            {
                other.GetComponent<PlayerVictory>().cross2= true;
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
}
