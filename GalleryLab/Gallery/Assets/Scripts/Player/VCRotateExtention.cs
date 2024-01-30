using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Zenject;
using System;

public class VCRotateExtention : CinemachineExtension
{
    public static event Action<Vector2> OnActivateVCWithRotateExtentionEvent;
    InputService _inputService;

    protected Vector2 _startRotation;
    protected float _verticalSpeed;
    protected float _horizontalSpeed;
    protected float _clampAngleUp;
    protected float _clampAngleDown;
    [Inject]
    public virtual void Constructor(InputService inputService)
    {
        _inputService = inputService;
        _verticalSpeed = 20;
        _horizontalSpeed = 20;
        _verticalSpeed= 20;
        _clampAngleUp = 80;
        _clampAngleDown = 80;
    }

    protected override void Awake()
    {
        base.Awake();
        if (_startRotation == null)
            _startRotation = transform.localEulerAngles;
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if (_inputService == null)
                {
                    return; 
                }
                
                Vector2 input = _inputService.GetMouseDelta();

                _startRotation.x += input.x * Time.deltaTime * _verticalSpeed;
                _startRotation.y += input.y * Time.deltaTime * _horizontalSpeed;

                _startRotation.y = Math.Clamp(_startRotation.y, -_clampAngleDown, _clampAngleUp);

                state.RawOrientation = Quaternion.Euler(-_startRotation.y, _startRotation.x, 0f);
            }
        }
    }
}
