using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        transform.position = target.position;
    }
}