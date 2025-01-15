using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 movement;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float vertical = Input.GetAxisRaw("Vertical") * moveSpeed;

        movement = new Vector3(horizontal, 0f, vertical);

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
