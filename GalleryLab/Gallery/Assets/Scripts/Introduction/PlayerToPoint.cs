using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerToPoint : MonoBehaviour
{
    Transform Point;
    NavMeshAgent _agent;
    Animator _animator;
    int _isWalkingEndParameter;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _isWalkingEndParameter = Animator.StringToHash("IsWalkingEnd");
        _agent.destination = Point.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_agent.remainingDistance < 0.01f)
        {
            enabled = false;
            _animator.SetBool(_isWalkingEndParameter, true);
            IntroEvents.InvokeOnReachedIntroPositionEvent();
        }
    }
    public void SetPoint(Transform position)
    {
        Point = position;
    }
}
