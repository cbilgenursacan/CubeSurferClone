using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    GameObject startButton;
    GameObject mainCube;
    [SerializeField] GameObject music;

    private void Start()
    {
        startButton = GameObject.Find("StartBtn");
        mainCube = GameObject.Find("MainCube");
    }
    public void Starter()
    {
        startButton.SetActive(false);
        mainCube.GetComponent<PlayerMovement>().enabled = true;
        music.SetActive(true);
    }
}
