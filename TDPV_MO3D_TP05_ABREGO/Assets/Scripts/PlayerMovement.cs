using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider coll;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        float dirX = moveAction.action.ReadValue<Vector2>().x;
        rb.linearVelocity = new Vector3(dirX * moveSpeed, rb.linearVelocity.y, 0f);

        if (jumpAction.action.WasPressedThisFrame() && IsGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0f);
        }
    }

    private bool IsGrounded()
    {
        float rayLength = coll.bounds.extents.y + 0.1f;
        return Physics.Raycast(transform.position, Vector3.down, rayLength);
    }


}
