using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public Transform Pointer;

    private Ray Ray;
    private RaycastHit Hit;
    private void LateUpdate()
    {
        RayHit(Ray, Hit);
    }

    public void RayHit(Ray ray, RaycastHit hit)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(ray, out hit))
        {
            Pointer.position = hit.point;

            if (hit.collider.gameObject.GetComponent<Selectable>())
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

                if (Input.GetKey(KeyCode.Mouse0) && hit.collider.gameObject.GetComponent<Selectable>())
                {
                    hit.collider.gameObject.GetComponent<Selectable>().Select();
                }             
            }
           
        }
    }


}
