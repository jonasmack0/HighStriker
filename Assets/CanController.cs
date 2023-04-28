using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanController : MonoBehaviour
{
    [SerializeField] private float m_fallThreshold = 45.0f;
    private bool m_isFallen = false;

    void FixedUpdate()
    {
        if (!m_isFallen)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            float angle = Vector3.Angle(transform.up, Vector3.up);
            if (angle > m_fallThreshold)
            {
                m_isFallen = true;
                //rb.isKinematic = true;

                GameObject counterObject = GameObject.Find("Counter");
                if (counterObject != null)
                {
                    CounterController counterController = counterObject.GetComponent<CounterController>();
                    if (counterController != null)
                    {
                        counterController.IncrementCount();
                    }
                }

                Destroy(gameObject, 3.0f); // Destroy the can after 3 seconds
            }
        }
    }
}