using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla o movimento dos objectos sob a esteira
/// </summary>
public class BeltDrag : MonoBehaviour
{

    public static float s_velocidade;
    public static List<Rigidbody> s_moving = new List<Rigidbody>();

    void Start()
    {
        s_velocidade = BeltOffset.s_Velocidade;
    }

    void FixedUpdate()
    {
        foreach(Rigidbody rb in s_moving)
        {
			if (rb.isKinematic)
			{
				continue;
			}

			float yVel = rb.velocity.y;
            Vector3 newVel = Time.deltaTime * s_velocidade * 250f * transform.forward;
            newVel.y = yVel;
			rb.velocity = newVel;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.layer != LayerMask.NameToLayer("Item"))
		{
            if (other.gameObject.TryGetComponent<Rigidbody>(out var otherRb))
			{
                s_moving.Add(otherRb);
			}
		}
	}
    private void OnTriggerExit(Collider other)
    {
        int index = s_moving.IndexOf(other.GetComponent<Rigidbody>());
        if (index != -1)
        {
            s_moving.RemoveAt(index);
        }
    }
}
