using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustBoost = 1000f;
    [SerializeField] float rotationBoost = 20f;

    Rigidbody rb;

    float horizontalRotation;
    bool verticalThrust;

    private void Awake()
    {
        GetAccessToComponents();
    }

    void GetAccessToComponents()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrustInput();
        ProcessRotationInput();
    }

    void ProcessThrustInput()
    {
        if (Input.GetButton("Fire1"))
        {
            verticalThrust = true;
        }
        else
        {
            verticalThrust = false;
        }
    }

    void ProcessRotationInput()
    {
        horizontalRotation = (Input.GetAxisRaw("Horizontal"));
    }

    private void FixedUpdate()
    {
        ThrustShip();
        RotateShip();
    }

    private void ThrustShip()
    {
        if (verticalThrust)
        {
            rb.AddRelativeForce(Vector3.up * thrustBoost * Time.fixedDeltaTime);
        }
    }

    private void RotateShip()
    {
        rb.freezeRotation = true;
        rb.transform.Rotate(Vector3.forward * rotationBoost * -horizontalRotation * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
