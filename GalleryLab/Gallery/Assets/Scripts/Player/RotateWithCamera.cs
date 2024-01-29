using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RotateWithCamera : MonoBehaviour
{
    Transform _cameraTrnsfrm;
    float _rotSpeed;
    // Start is called before the first frame update
    [Inject]
    public void Constructor(PlayerSO playerSO)
    {
        _rotSpeed = playerSO.RotSpeed;
    }
    void Start()
    {
        _cameraTrnsfrm = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float yRot = _cameraTrnsfrm.localEulerAngles.y;
        float newRot = Mathf.LerpAngle(transform.localEulerAngles.y, yRot, Time.deltaTime * _rotSpeed);
        transform.localEulerAngles = new Vector3(0, newRot, 0f);
    }
}
