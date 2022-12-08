using Cinemachine;
using UnityEngine;

public class CinemachinePOVExtension : CinemachineExtension
{
    public float verticalSpeed = 10f;
    public float horizontalSpeed = 10f;
    public GameObject pausePanel;

    private InputManager inputManager;
    private Vector3 startRotation;
    private bool mouseUnlocked;

    protected override void Awake()
    {
        inputManager = InputManager.createInstance();
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        Quaternion previous = new Quaternion();
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim && !pausePanel.activeSelf)
            {
                Vector2 deltaInput = inputManager.Look();
                startRotation.x += Time.fixedDeltaTime * verticalSpeed * deltaInput.x;
                startRotation.y += Time.fixedDeltaTime * horizontalSpeed * deltaInput.y;

                startRotation.y = Mathf.Clamp(startRotation.y, -90, 90);

                state.RawOrientation = Quaternion.Euler(-startRotation.y, startRotation.x, 0f);
                previous = state.RawOrientation;
            }
            else if (pausePanel.activeSelf)
            {
                state.RawOrientation = previous;
            }
        }
    }
}
