using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;

    public static List<Gravity> otherObjectsLists;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (otherObjectsLists == null)
        {
            otherObjectsLists = new List<Gravity>();
        }

        otherObjectsLists.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (Gravity obj in otherObjectsLists)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }
    void Attract(Gravity other)
    {
        Rigidbody ohter = other.rb;
        
        Vector3 direction = rb.position - ohterRb.position;
        
        float distance = direction.magnitude;
        
        float forceMagnitude = G * ((rb.mass * ohterRb.mass)/Mathf.Pow(distance, 2));
        Vector3 finalforce = forceMagnitude * direction.normalized;
        
        other.AddForce(finalforce);
    }
}