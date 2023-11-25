using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class CameraSwitch : MonoBehaviour
{

    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private int priorityBoostAmount = 10;

    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;
    [SerializeField]
    private Canvas hipFireReticleCanvas;
    [SerializeField]
    private Canvas closeAimReticleCanvas;


    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];

        hipFireReticleCanvas.enabled = true;
        closeAimReticleCanvas.enabled = false;
    }

    private void OnEnable() 
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    
    
    }


    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();


    }

    private void StartAim()
    {
        virtualCamera.Priority += priorityBoostAmount;
        hipFireReticleCanvas.enabled = false;
        closeAimReticleCanvas.enabled = true;
    }

    private void CancelAim()
    {
        virtualCamera.Priority -= priorityBoostAmount;
        hipFireReticleCanvas.enabled = true;
        closeAimReticleCanvas.enabled = false;

    }

}
