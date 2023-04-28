using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToHand : MonoBehaviour
{
    public Transform rightHandAnchor;

    void Start()
    {
        transform.position = rightHandAnchor.position;
        transform.rotation = rightHandAnchor.rotation * Quaternion.Euler(0, 90, 0);
        transform.SetParent(rightHandAnchor);
    }
}
