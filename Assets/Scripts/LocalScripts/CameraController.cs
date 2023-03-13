using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraLocation
{
    FPS,
    TPS,
    ENVIRONMENT
}
public class CameraController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SwitchCamera(CameraLocation type)
    {
        animator.Play(type.ToString());
    }
}
