using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public MoveForward moveForward;
    public GameObject runtimePanel;
    public GameObject startMenu;
    public GameObject finishMenu;
    public GameObject lossMenu;

    public void StartGame()
    {
        moveForward.enabled = true;
        startMenu.SetActive(false);
        runtimePanel.SetActive(true);
    }

    public void Finish()
    {
        moveForward.enabled = false;
        runtimePanel.SetActive(false);
        finishMenu.SetActive(true);
    }

    public void Loss()
    {
        moveForward.enabled = false;
        runtimePanel.SetActive(false);
        lossMenu.SetActive(true);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
