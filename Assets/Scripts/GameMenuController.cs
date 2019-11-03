using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    void OnPause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
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