using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashPaintController : MonoBehaviour
{

    public Animator animatorSplashPaint;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimationSplash()
    {
        animatorSplashPaint.Play("SplashPaint");
    }
}
