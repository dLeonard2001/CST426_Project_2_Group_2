using System;
using Cinemachine;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] 
    private float verticalSpeed = 10f;
        
    [SerializeField] 
    private float horizontalSpeed = 10f;

    private InputManager inputManager;
    private Vector3 startRotation;
    private bool mouseUnlocked;

    protected override void Awake()
    {
        inputManager = InputManager.createInstance();
        base.Awake();
    }

    private void Update()
    {
        if (inputManager.unlock_mouse())
            changeMouseStatus(mouseUnlocked);
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim && !mouseUnlocked)
            {
                Vector2 deltaInput = inputManager.Look();
                startRotation.x += Time.fixedDeltaTime * verticalSpeed * deltaInput.x;
                startRotation.y += Time.fixedDeltaTime * horizontalSpeed * deltaInput.y;
                
                startRotation.y = Mathf.Clamp(startRotation.y, -90, 90);
                
                state.RawOrientation = Quaternion.Euler(-startRotation.y, startRotation.x, 0f);
            }
        }
    }

    private void changeMouseStatus(bool status)
    {
        if (status)
            mouseUnlocked = false;
        else
            mouseUnlocked = true;
    }
}
