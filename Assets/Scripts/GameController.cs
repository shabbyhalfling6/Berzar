using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public GameObject gameOverCameraPosition;

    private float targetFOV = 50.0f;
    private float smoothFactor = 0.1f;

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if (pauseMenu.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }

        if(player == null)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetFOV, smoothFactor * Time.deltaTime);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, gameOverCameraPosition.transform.position, Time.deltaTime * smoothFactor);
            gameOverMenu.SetActive(true);
        }
    }
}
