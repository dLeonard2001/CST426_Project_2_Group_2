using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] 
    private float verticalSpeed = 10f;
        
    [SerializeField] 
    private float horizontalSpeed = 10f;

    private InputManager inputManager;
    private Vector3 startRotation;

    protected override void Awake()
    {
        inputManager = InputManager.createInstance();
        base.Awake();
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = inputManager.Look();
                startRotation.x += Time.fixedDeltaTime * verticalSpeed * deltaInput.x;
                startRotation.y += Time.fixedDeltaTime * horizontalSpeed * deltaInput.y;
                
                startRotation.y = Mathf.Clamp(startRotation.y, -90, 90);
                
                state.RawOrientation = Quaternion.Euler(-startRotation.y, startRotation.x, 0f);
            }
        }
    }
}
