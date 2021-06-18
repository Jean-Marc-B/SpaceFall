using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class JoystickMovementForInner : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 1;
    private CharacterController characterController;
    public float gravity = 9.81f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        Vector3 movement = speed * Time.deltaTime * (Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0.1f, 0, 0)) - new Vector3(0, gravity, 0) * Time.deltaTime;

        if (Vector3.Distance(movement,new Vector3(0.0f, 0.0f, 0.0f)) >= 0.07)
        {
            characterController.Move(movement);
        }
        
    }
}
