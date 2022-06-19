using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MovementBase
{
    private Joystick joystick;

    private void Start()
    {
        joystick = UIManager.Instance.uiGamePlay.joystick;
    }

    private void Update()
    {
        if (GameController.GameState)
        {
            Move();
        }

        UpdateMovementSpeed();
        UpdateCameraZoom();
    }

    private void Move()
    {
        if (joystick.Direction != Vector2.zero && agentBase.agent.isOnNavMesh)
        {
            Vector3 direction = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);

            agentBase.agent.Move(direction * agentBase.agent.speed * Time.deltaTime);

            Vector3 lookDirection = new Vector3(direction.x, 0, direction.z);
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 30 * Time.deltaTime);
        }
    }

    private float zoomRate = 0;
    private void UpdateCameraZoom()
    {
        zoomRate = Mathf.Lerp(zoomRate, joystick.Direction.sqrMagnitude * -.6f, Time.deltaTime * 3f);
        CameraController.Instance.zoomRate = zoomRate;
    }
}