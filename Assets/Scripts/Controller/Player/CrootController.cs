using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrootController : MonoBehaviour
{
    private Quaternion gunRotation;
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = new PlayerInput();
        gunRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        var shootDirection = (mousePos - transform.position).normalized;
        var angle = Mathf.Atan2(shootDirection.z, shootDirection.y) * Mathf.Rad2Deg;
        rotateGun();
    }

    void rotateGun()
    {
        var angle = playerInput.MovementController.Move.ReadValue<Vector2>();
        gunRotation *= Quaternion.Euler(Vector3.right * angle * 5f);
        transform.rotation = gunRotation;
    }
}
