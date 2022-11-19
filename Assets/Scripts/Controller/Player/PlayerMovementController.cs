using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float playerRotationSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float gravityForce;
    private float movementDirection;
    private PlayerInput playerInput;


    public Transform goundCheckPosition;
    public LayerMask groundMask;
    public Rigidbody rigidbodyPlayer;

    void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.MovementController.Jump.performed += playerJumpInputBinding;
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.MovementController.Jump.performed -= playerJumpInputBinding;
        playerInput.Disable();
    }
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        gravityDirection(Physics.gravity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isGrounded())
            gravityDirection(Physics.gravity);

        playerMovement();
    }

    private void playerMovement()
    {

        movementDirection = playerInput.MovementController.Move.ReadValue<Vector2>().x;
        print("performed " + movementDirection);

        if (movementDirection < 0)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0f, 0f, 0f), Quaternion.Euler(0f, 180f, 0f), playerRotationSpeed * Time.deltaTime);
        }
        else if (movementDirection > 0)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0f, 180f, 0f), Quaternion.Euler(0f, 0f, 0f), playerRotationSpeed * Time.deltaTime);
        }
    }
    public void playerJumpInputBinding(InputAction.CallbackContext inputContext)
    {

        if (inputContext.performed && isGrounded())
        {
            rigidbodyPlayer.velocity = new Vector3(0f, jumpForce, movementDirection * movementSpeed * Time.deltaTime);
        }
        if (inputContext.canceled && isGrounded())
        {
            rigidbodyPlayer.velocity = new Vector3(0f, rigidbodyPlayer.velocity.y * 0.5f, movementDirection * movementSpeed * Time.deltaTime);
        }
    }
    private bool isGrounded()
    {
        return Physics.CheckSphere(goundCheckPosition.position, 0.2f, groundMask);
    }

    private void gravityDirection(Vector3 direction)
    {
        rigidbodyPlayer.AddForce(direction * gravityForce);
    }
}
