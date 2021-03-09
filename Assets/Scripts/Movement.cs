using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Variablen
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 200f;
    Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    // Methoden
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }        
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {

        }
        else if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }       
    }

    void ApplyRotation(float rotationThisFrame)
    {
        // Freezing Rotation from Physics System to manually rotate
        rb.freezeRotation = true;
        // Manual Rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        // Unfreeze Rotiation from Physics System
        rb.freezeRotation = false;
    }
}
