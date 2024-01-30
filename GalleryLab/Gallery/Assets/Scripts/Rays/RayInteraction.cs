using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public abstract class RayInteraction : MonoBehaviour
{
    const float c_maxDistance = 2;
    public string ObjectName;

    public float Radius { get; protected set; } = 0.2f;

    protected float _cameraCenterXPosition;

    protected float _cameraCenterYPosition;

    protected RaycastHit _rayCastHit;

    protected GameObject HitObject;

    protected Ray _throwingRay;

    protected Camera _camera { get; set; }

    private void Start()
    {
        _camera = GetComponent<Camera>();
        onStart();
    }

    protected void CatchRay()
    {
        _cameraCenterXPosition = _camera.pixelWidth / 2;

        _cameraCenterYPosition = _camera.pixelHeight / 2;

        Vector3 origin = new Vector3(_cameraCenterXPosition, _cameraCenterYPosition, 0);

        _throwingRay = _camera.ScreenPointToRay(origin);

        if (Physics.SphereCast(_throwingRay, Radius, out _rayCastHit))
        {
            HitObject = _rayCastHit.transform.gameObject;
            ObjectName = HitObject.name;
            onHitRay();
        }
        else
        {
            onMissRay();
        }
    }
    protected void CatchRay(LayerMask layerMask)
    {
        _cameraCenterXPosition = _camera.pixelWidth / 2;

        _cameraCenterYPosition = _camera.pixelHeight / 2;

        Vector3 origin = new Vector3(_cameraCenterXPosition, _cameraCenterYPosition, 0);

        _throwingRay = _camera.ScreenPointToRay(origin);

        if (Physics.SphereCast(_throwingRay, Radius, out _rayCastHit, c_maxDistance,
            ~layerMask))
        {
            HitObject = _rayCastHit.transform.gameObject;
            ObjectName = HitObject.name;
            onHitRay();
        }
        else
        {
            onMissRay();
        }
    }

    public abstract void onHitRay();
    public abstract void onMissRay();
    public abstract void onStart();

    
}
