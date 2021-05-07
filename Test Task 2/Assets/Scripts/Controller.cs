using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller: MonoBehaviour
{
    private float _targetX;
    public float speed;

    void Update()
    {
        var currentPosition = transform.position;
        var targetPosition = currentPosition;
        targetPosition.x = _targetX;
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        _targetX = transform.position.x;
    }

    public void SetTargetPosition(float newPosition)
    {
        _targetX = newPosition;
    }
}
