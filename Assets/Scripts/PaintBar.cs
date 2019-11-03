using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaintBar : MonoBehaviour
{
    [SerializeField] private Scrollbar _paintBar;
    [SerializeField] private float _paint = 100;
    private float _paintBody;
    public Scene currentScene;
    public string nameScene;


    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        nameScene = currentScene.name;
        _paintBody = _paint;
    }

    public void LosePaint(float lose)
    {
        _paintBody -= lose;
        _paintBar.size = _paintBody / _paint;
    }

    public float GetQuantityPaint()
    {
        return _paintBody;
    }

    public void GameOver()
    {
        if (GetQuantityPaint() < 1)
        {
            SceneManager.LoadScene(nameScene);
        }
    }



}    
