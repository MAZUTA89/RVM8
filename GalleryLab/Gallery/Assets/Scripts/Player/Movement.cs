using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Zenject;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    int _blendCode;
    int _moveCode;


    Transform _cameraTransform;

    InputService _inputService;

    CharacterController _characterController;

    Animator _animator;

    private Vector3 _velocity;

    float _speed = 2f;
    float _gravity = -9.8f;

    public bool _groundedPlayer;

    bool _isActive;

    Vector3 _movement;

    [Inject]
    public void Constructor(InputService inputService, PlayerSO playerSO)
    {
        _inputService = inputService;
        _speed = playerSO.Speed;
        _gravity = playerSO.Gravity;
    }
    private void OnEnable()
    {
        IntroEvents.OnEndIntroEvent += OnEndIntro;
    }
    private void OnDisable()
    {
        IntroEvents.OnEndIntroEvent -= OnEndIntro;
    }
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _cameraTransform = Camera.main.transform;
        _groundedPlayer = true;

        _blendCode = Animator.StringToHash("Blend");
        _moveCode = Animator.StringToHash("Move");
        _isActive = false;
    }

    void Update()
    {
        if (!_isActive)
            return;
        if (_characterController.isGrounded && _velocity.y < 0f)
        {
            _velocity.y = 0f;
        }

        Vector2 input = _inputService.GetMovement();

        MoveParameter(input);

        BlendParametet(input);

        _movement = _cameraTransform.right * input.x + _cameraTransform.forward * input.y;

        _movement = Vector3.ClampMagnitude(_movement, _speed * Time.deltaTime);

        _characterController.Move(_movement);

        _velocity.y += _gravity * Time.deltaTime;

        _characterController.Move(_velocity);
    }

    void MoveParameter(Vector2 input)
    {
        if (input == Vector2.zero)
        {
            _animator.SetBool(_moveCode, false);
        }
        else
        {
            _animator.SetBool(_moveCode, true);
        }
    }

    void BlendParametet(Vector2 input)
    {
        _animator.SetFloat(_blendCode, input.y);
    }

    public void OnEndIntro()
    {
        _isActive = true;
    }
}
