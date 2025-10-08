using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    
    Rigidbody rb;
    Vector3 baseGravity;
    bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        baseGravity = Physics.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        var jump = Input.GetKeyDown(KeyCode.Space);
        if (jump && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        //So we can calibrate gravity easily in the editor
        Physics.gravity = baseGravity * gravityModifier;
    }

    public void OnCollisionEnter(Collision other) {
        isGrounded = true;
    }
}
