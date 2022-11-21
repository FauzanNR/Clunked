using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrootController : MonoBehaviour
{
    private Quaternion gunRotation;
    private PlayerInput playerInput;
    public GameObject Bullet;
    public Transform shootDirectionAu;
    public Transform shootPosition;
    public PlayerMovementController playerMovementController;

    public Camera camMouse;
    private float angle;
    public float buletFore;
    public Vector3 gunDirection;

    private void OnEnable()
    {
        playerInput = new PlayerInput();

        playerInput.Enable();

        playerInput.MovementController.Fire.performed += shoot;

    }
    private void OnDisable()
    {
        playerInput.MovementController.Fire.performed -= shoot;
        playerInput.Disable();
    }


    private void Update()
    {
        gunDirection = playerMovementController.gunDirection;
        if (gunDirection != Vector3.zero)
            transform.LookAt(shootDirectionAu.position);
    }
    void shoot(InputAction.CallbackContext context)
    {

        var bulet = Instantiate(Bullet, shootPosition.position, Quaternion.identity);
        bulet.GetComponent<Rigidbody>().velocity = transform.forward * buletFore;
    }
}
