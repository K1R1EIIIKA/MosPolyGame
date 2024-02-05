using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    private CursorLockMode _currentMode;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetPause();
    }

    public void SetPause()
    {
        Debug.Log("Pause");
        if (GameManager.Instance.isWon)
            return;

        if (Time.timeScale == 0)
            Unpause();
        else
            Pause();
    }

    public void Pause()
    {
        _currentMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;
        GameManager.Instance.pauseCanvas.SetActive(true);
    }

    public void Unpause()
    {
        Cursor.lockState = _currentMode;

        Time.timeScale = 1;
        GameManager.Instance.pauseCanvas.SetActive(false);
    }
}