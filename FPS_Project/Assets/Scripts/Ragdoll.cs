using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
   public Rigidbody[] rigidbodies;
   private Animator _animator;
    public void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponent<Animator>();

        DeactivateRagdoll();
    }

    public void DeactivateRagdoll()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        _animator.enabled = true;
    }
    public void ActivateRagdoll()
    {
        Debug.Log("Regdoll Activated");
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        _animator.enabled = false;
    }
}
