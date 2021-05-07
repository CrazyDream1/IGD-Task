using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;

    void Update()
    {
        var currentPosition = transform.position;
        transform.position = Vector3.MoveTowards(currentPosition, currentPosition + transform.forward * speed, speed * Time.deltaTime);
    }
}
