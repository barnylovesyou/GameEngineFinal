using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> locations;
    [SerializeField] private float speed;
    private Vector3 startLoc;
    private int curLoc=0;
    private bool forward = true;
    // Start is called before the first frame update
    void Start()
    {
        startLoc = locations[0].position;
        this.transform.position = startLoc;
        curLoc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = locations[curLoc].position - this.transform.position;
        if (dir.magnitude>1)
        {
            dir.Normalize();
            this.transform.Translate(dir*Time.deltaTime * speed);
        }
        else
        {
            NextLoc();
        }
    }
    public void Respawn()
    {
        transform.position = startLoc;
        curLoc = 0;
        forward = true;
    }
    void NextLoc()
    {
        if (curLoc >= locations.Count - 1)
        {
            forward = false;
        }
        else if(curLoc<=0)
        {
            forward = true;
        }
        curLoc += forward ? 1 : -1;
    }
}
