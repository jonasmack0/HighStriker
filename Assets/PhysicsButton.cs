using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] public float threshold = .1f;
    [SerializeField] public float deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    private float collisionSpeed;
    private Vector3 rocketDirection = Vector3.up;
    private bool rocketStarted = false;
    public float minY = 0.1f;
    public float maxY = 0.698f;

    public Rigidbody rocket;
    public float forceMultiplier = 1.0f;
    public UnityEvent onPressed, onReleased;     

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();

        //float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        //transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        collisionSpeed = collision.relativeVelocity.magnitude;
        Debug.Log("Collision speed: " + collisionSpeed);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");

        if (!rocketStarted)
        {
            if (collisionSpeed > 0.1f)
            {
                rocket.AddForce(rocketDirection * collisionSpeed * forceMultiplier, ForceMode.Impulse);
                rocketStarted = true;
            }
        }
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released"); 
    }
}
