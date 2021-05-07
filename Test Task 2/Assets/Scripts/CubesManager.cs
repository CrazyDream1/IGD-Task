using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubesManager : MonoBehaviour
{
    public GameObject inactiveCubes;
    public int numberOfCubes = 1;
    public UI canvas;
    private int numberOfCubesLost = 0;
    private List<GameObject> activeCubes = new List<GameObject>();

    public void AddCube(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var cube = inactiveCubes.transform.GetChild(0);
            cube.gameObject.SetActive(true);
            cube.GetComponent<Collider>().isTrigger = true;
            cube.transform.parent = this.transform;
            var newPosition = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f + numberOfCubes * 1f, this.transform.position.z);
            cube.transform.position = newPosition;
            activeCubes.Add(cube.gameObject);
            numberOfCubes++;
        }
    }

    public void RemoveCube(GameObject cube)
    {
        cube.GetComponent<Collider>().enabled = false;
        cube.transform.parent = inactiveCubes.transform;
        activeCubes.Remove(cube);
        numberOfCubes--;
        numberOfCubesLost++;
    }

    public void Fall(float fallTime)
    {
        foreach(var cube in activeCubes)
        {
            cube.transform.DOMoveY(cube.transform.position.y - 1f * numberOfCubesLost , fallTime);
        }
        numberOfCubesLost = 0;
    }

    public bool IsEmpty()
    {
        return numberOfCubes == 0;
    }

    public void Finish()
    {
        canvas.Finish();
    }

    public void Loss()
    {
        canvas.Loss();
    }
}
