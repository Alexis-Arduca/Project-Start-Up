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

    public void HandleMovement(Transform cameraTransform)
    {
        if (!playerAction)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            movement = (forward * vertical + right * horizontal).normalized * moveSpeed;

            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
    }
}
