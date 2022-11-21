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
    private float movementDirectionX;
    private PlayerInput playerInput;


    public Transform goundCheckPosition;
    public LayerMask groundMask;
    public Rigidbody rigidbodyPlayer;
    public bool manualGravityIsOn = false;

    public CrootController croot;

    public Transform charBody;
    public Vector3 gunDirection;

    public GameObject gunDirVisu;

    public event System.Action OnMoving;
    public event System.Action OnIdle;
    public event System.Action OnJump;

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var gunForward = transform.forward;
        var gunUp = transform.up;

        gunDirection = playerInput.MovementController.Move.ReadValue<Vector2>().x * gunForward + playerInput.MovementController.Move.ReadValue<Vector2>().y * gunUp;
        gunDirection += gunDirection * 100 * Time.deltaTime;
        gunDirVisu.transform.localPosition = gunDirection;
        if (!isGrounded() && manualGravityIsOn)
            gravityDirection(Physics.gravity);

        playerMovement();
    }

    private void playerMovement()
    {
        movementDirectionX = playerInput.MovementController.Move.ReadValue<Vector2>().x;


        rigidbodyPlayer.velocity = new Vector3(rigidbodyPlayer.velocity.x, rigidbodyPlayer.velocity.y, (movementDirectionX * movementSpeed));

        if (movementDirectionX < 0)
        {
            charBody.rotation = Quaternion.Slerp(Quaternion.Euler(0f, 0f, 0f), Quaternion.Euler(0f, 180f, 0f), playerRotationSpeed);
            if (isGrounded()) OnMoving?.Invoke();
        }
        else if (movementDirectionX > 0)
        {
            charBody.rotation = Quaternion.Slerp(Quaternion.Euler(0f, 180f, 0f), Quaternion.Euler(0f, 0f, 0f), playerRotationSpeed);
            if (isGrounded()) OnMoving?.Invoke();
        }
        else
        {
            if (isGrounded()) OnIdle?.Invoke();
        }
    }

    public void playerJumpInputBinding(InputAction.CallbackContext inputContext)
    {
        print("oerff");
        if (inputContext.performed && isGrounded())
        {
            rigidbodyPlayer.velocity = new Vector3(0f, jumpForce, movementDirectionX * movementSpeed * Time.deltaTime);
            OnJump?.Invoke();
        }
        if (inputContext.canceled && isGrounded())
        {
            rigidbodyPlayer.velocity = new Vector3(0f, rigidbodyPlayer.velocity.y * 0.5f, movementDirectionX * movementSpeed * Time.deltaTime);
        }
    }
    private bool isGrounded()
    {
        return Physics.CheckSphere(goundCheckPosition.position, 0.15f, groundMask);
    }

    private void gravityDirection(Vector3 direction)
    {
        rigidbodyPlayer.AddForce(direction * gravityForce);
    }
}
