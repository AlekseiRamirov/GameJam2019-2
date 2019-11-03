using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    private bool active = false;
    void OnPause()
    {
        if (active == false)
        {
            active = true;
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            active = false;
            pause.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }
}