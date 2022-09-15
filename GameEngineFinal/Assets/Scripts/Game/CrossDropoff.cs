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
                GameObject newCross = Instantiate(cross, Vector3.zero, Quaternion.identity);
                newCross.transform.parent = cross1Loc;
                newCross.transform.localPosition = new Vector3(-12.215f, -5.22f, 14.868f);
                cross1 = true;
                other.GetComponent<PlayerVictory>().cross1 = false;
            }
            if (other.GetComponent<PlayerVictory>().cross2)
            {
                GameObject newCross =Instantiate(cross, Vector3.zero, Quaternion.identity);
                newCross.transform.parent = cross2Loc;
                newCross.transform.localPosition = new Vector3(3.249f, -5.475f, 14.867f);
                cross2 = true;
                other.GetComponent<PlayerVictory>().cross2 = false;
            }
        }
    }

}
