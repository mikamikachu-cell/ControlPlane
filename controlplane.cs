using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlplane : MonoBehaviour
{
public float speed = 10f;
public float pitchSpeed = 2f;
public float rollSpeed = 1f;
public float yawSpeed = 1f;

private Rigidbody rb;
private float rollInput;
private float pitchInput;
private float yawInput;

void Start()
{
    rb = GetComponent<Rigidbody>();
}

void Update()
{
    rollInput = Input.GetAxis("Horizontal");
    pitchInput = Input.GetAxis("Vertical");
    yawInput = Input.GetAxis("Yaw");
}

void FixedUpdate()
{
    // Calculate the airplane's forward and sideways velocities
    Vector3 forwardVelocity = transform.forward * speed * pitchInput;
    Vector3 sidewaysVelocity = transform.right * speed * rollInput;

    // Apply forces to move the airplane
    rb.AddForce(forwardVelocity);
    rb.AddForce(sidewaysVelocity);

    // Calculate the airplane's pitch, roll, and yaw rotations
    float pitchRotation = pitchInput * pitchSpeed * Time.deltaTime;
    float rollRotation = -rollInput * rollSpeed * Time.deltaTime;
    float yawRotation = -yawInput * yawSpeed * Time.deltaTime;

    // Apply rotations to tilt the airplane
    Quaternion targetRotation = Quaternion.Euler(pitchRotation, yawRotation, rollRotation);
    rb.MoveRotation(rb.rotation * targetRotation);
}
}
