using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCollider : MonoBehaviour
{
    public CubesManager cubesManager;
    public GameObject stickman;
    [SerializeField]
    private float fallTime = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubeWall cubeWall))
        {
            cubeWall.GetComponent<Collider>().enabled = false;
            cubesManager.Fall(fallTime);
            stickman.transform.DOMoveY(1f * cubesManager.numberOfCubes, fallTime);
            Debug.Log("Down");
        }
        if (other.TryGetComponent(out Finish finish))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            cubesManager.Finish();
            stickman.GetComponent<Animator>().SetTrigger("Finish");
            Debug.Log("Finish");
        }
    }
}
