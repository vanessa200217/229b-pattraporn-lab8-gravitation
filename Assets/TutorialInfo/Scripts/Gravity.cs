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
        Rigidbody otherRb = other.rb;

        if (otherRb == null) return;  // ป้องกัน error ถ้า Rigidbody หายไป

        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;

        if (distance == 0) return;  // ป้องกัน division by zero

        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
        Vector3 finalforce = forceMagnitude * direction.normalized;

        otherRb.AddForce(finalforce);
    }
}