using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossDropoff : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject portal;
    [SerializeField] GameObject cross;
    [SerializeField] Transform cross1Loc;
    [SerializeField] Transform cross2Loc;
    bool cross1 = false;
    bool cross2=false;
    private void Update()
    {
        if(cross1&&cross2)
        {
            portal.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerVictory>().cross1)
            {
                Instantiate(cross, cross1Loc.position, Quaternion.identity);
                cross1 = true;
                other.GetComponent<PlayerVictory>().cross1 = false;
            }
            if (other.GetComponent<PlayerVictory>().cross2)
            {
                Instantiate(cross, cross2Loc.position, Quaternion.identity);
                cross2 = true;
                other.GetComponent<PlayerVictory>().cross2 = false;
            }
        }
    }

}
