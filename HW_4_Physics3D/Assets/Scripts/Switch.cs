using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PlateNumerator
{
    first,
    second
}

public class Switch : MonoBehaviour
{
    public GameObject Cube;
    
    public CatapultTimer Timer;

    public PlateNumerator Plate;
    public void OnTriggerStay(Collider collision)
    {
        transform.Translate(Vector3.down * Time.deltaTime);
        if (Plate == PlateNumerator.first)
        {
            Cube.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (Plate == PlateNumerator.second)
        {
            Timer.StartTimer();
        }
    }

    
}
