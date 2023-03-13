using System;
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

    [SerializeField] private float run;

    private Transform cam;

    private void OnEnable()
    {
        Debug.Log(GetComponent<PlayerController>().player.gameObject.name);

        playerControls = new();
        playerControls.Enable();
        animator = transform.parent.GetComponent<Animator>();
        animator.applyRootMotion = true;
        cam = Camera.main.transform;
    }

    private void Update()
    {
        GetInput();
        Animate();
        Rotate();

    }

    private void GetInput()
    {
        Vector2 vector2d = playerControls.Player.Movement.ReadValue<Vector2>();
        run = playerControls.Player.Run.ReadValue<float>();
        moveDirection = new Vector3(vector2d.x, 0, vector2d.y);
    }

    private void Animate()
    {
        animator.SetFloat("Speed", moveDirection.magnitude, 0.1f, Time.deltaTime);
        animator.SetFloat("Run", run, 0.1f, Time.deltaTime);
    }

    private void Rotate()
    {
        if (moveDirection == Vector3.zero) return;

        Vector3 camRot = cam.transform.TransformDirection(moveDirection);
        camRot.y = 0;

        transform.parent.forward = Vector3.Slerp(transform.parent.forward, camRot, turnSpeed * Time.deltaTime);

    }
}
