using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAgent : MonoBehaviour
{
    [SerializeField] MoveAgent myAgent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RaycastHit hit;
            Debug.DrawLine(myAgent.transform.position, other.transform.position, Color.red, .2f);
            if(Physics.Linecast(myAgent.transform.position,other.transform.position,out hit))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("Player"))
                {
                    myAgent.HostileFound(other.transform);
                }
            }
        }
    }
}
