using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Zenject;

public class RotateWithCamera : MonoBehaviour
{
    Transform _cameraTrnsfrm;
    float _rotSpeed;
    bool _isActive;
    // Start is called before the first frame update
    [Inject]
    public void Constructor(PlayerSO playerSO)
    {
        _rotSpeed = playerSO.RotSpeed;
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
        _cameraTrnsfrm = Camera.main.transform;
        _isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
            return;
        float yRot = _cameraTrnsfrm.localEulerAngles.y;
        float newRot = Mathf.LerpAngle(transform.localEulerAngles.y, yRot, Time.deltaTime * _rotSpeed);
        transform.localEulerAngles = new Vector3(0, newRot, 0f);
    }
    public void OnEndIntro()
    {
        _isActive = true;
    }
}
