using System.Collections;
using System.Collections.Generic;
using Unity.Netcode.Components;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerControls playerControls;

    [SerializeField] private Animator animator;

    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private float turnSpeed;
    private void OnEnable()
    {
        Debug.Log(GetComponent<PlayerController>().player.gameObject.name);

        playerControls = new();
        playerControls.Enable();
        animator = transform.parent.GetComponent<Animator>();
        animator.applyRootMotion = true;
    }

    private void Update()
    {

        Vector2 vector2d = playerControls.Player.Movement.ReadValue<Vector2>();
        moveDirection = new Vector3(vector2d.x, 0 ,vector2d.y);
        animator.SetFloat("Speed", moveDirection.magnitude, 0.05f, Time.deltaTime);
        Rotate();

    }

    private void Rotate()
    {
        if (moveDirection == Vector3.zero) return;

        Quaternion lookRotatation = Quaternion.LookRotation(moveDirection);

        transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, lookRotatation, Time.deltaTime * turnSpeed);

    }
}
