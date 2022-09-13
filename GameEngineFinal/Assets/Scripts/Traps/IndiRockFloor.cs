using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiRockFloor : Trap
{
    private Vector3 rockLoc;
    [SerializeField]private GameObject Rock;
    private void Start()
    {
        rockLoc = Rock.transform.position;
    }
    public override void Active()
    {
        this.gameObject.SetActive(false);
    }
    public override void Respawn()
    {
        this.gameObject.SetActive(true);
        Rock.transform.position = rockLoc;
        Rock.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Rock.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
