using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnWorld : MonoBehaviour
{
    List<GameObject> activatable= new List<GameObject>();
    private void Awake()
    {
        var traps = FindObjectsOfType<Trap>();
        for (int i = 0; i < traps.Length; i++)
        {
            activatable.Add(traps[i].gameObject);
        }
        var tripWire = FindObjectsOfType<Tripwire>();
        for (int i = 0; i < tripWire.Length; i++)
        {
            activatable.Add(tripWire[i].gameObject);
        }
    }
    public void Respawn()
    {
        for (int i = 0; i < activatable.Count; i++)
        {
            activatable[i].SetActive(true);
        }
        var traps= FindObjectsOfType<Trap>();
        for(int i = 0; i < traps.Length;i++)
        {
            traps[i].Respawn();
        }
        var bigBad = FindObjectsOfType<ChaseAgent>();
        for (int i = 0; i < bigBad.Length; i++)
        {
            bigBad[i].Respawn();
        }
        var smallBad = FindObjectsOfType<MoveAgent>();
        for (int i = 0; i < smallBad.Length; i++)
        {
            smallBad[i].Respawn();
        }
        var plat = FindObjectsOfType<MovingPlatform>();
        for (int i = 0; i < plat.Length; i++)
        {
            plat[i].Respawn();
        }
    }
}
