using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintBar : MonoBehaviour
{
    [SerializeField] private Scrollbar _paintBar;
    [SerializeField] private float _paint = 100;
    private float _paintBody;

    void Start()
    {
        _paintBody = _paint;
    }

    public void LosePaint(float lose)
    {
        _paintBody -= lose;
        _paintBar.size = _paintBody / _paint;
    }



}    
