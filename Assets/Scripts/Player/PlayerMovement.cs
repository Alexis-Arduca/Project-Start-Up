using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool playerAction = false;
    public float moveSpeed;
    private Vector3 movement;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameEventsManager.instance.playerEvents.onActionChange += ChangeAction;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onActionChange -= ChangeAction;
    }

    private void ChangeAction()
    {
        playerAction = !playerAction;
    }

    public void HandleMovement()
    {
        if (playerAction == false) {
            float horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
            float vertical = Input.GetAxisRaw("Vertical") * moveSpeed;

            movement = new Vector3(horizontal, 0f, vertical);

            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
    }
}
