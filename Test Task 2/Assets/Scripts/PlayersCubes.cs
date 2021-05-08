using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayersCubes : MonoBehaviour
{
    public CubesManager cubesManager;
    public Animator animator;
    public GameObject stickman;
    [SerializeField]
    private float pickUpTime = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubeWall cubeWall))
        {
            cubesManager.RemoveCube(this.gameObject);
            if (cubesManager.IsEmpty())
            {
                stickman.GetComponent<Animator>().SetTrigger("Loss");
                cubesManager.Loss();
                Debug.Log("Game End");
            }
            Debug.Log("Wall");
        }
        if (other.TryGetComponent(out CubePickUp cubePickUp))
        {
            cubePickUp.gameObject.SetActive(false);
            stickman.transform.position = new Vector3(stickman.transform.position.x, stickman.transform.position.y + 1, stickman.transform.position.z);
            //stickman.transform.DOMoveY(stickman.transform.position.y + 1 * cubePickUp.numberOfCubes, pickUpTime);
            animator.SetTrigger("Jump");
            cubesManager.AddCube(cubePickUp.numberOfCubes);
            Debug.Log("Pick up a cube(s)");
        }
    }
}
