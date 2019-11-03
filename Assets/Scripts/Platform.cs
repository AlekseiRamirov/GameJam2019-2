using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject objectAttached;

    [SerializeField]
    private PaintBar paintBar;

    [SerializeField]
    private SplashPaintController splashPaintController;

    private SpriteRenderer renderObjectAttached;
    private Collider2D colliderObject;
    private Color unAlphaObject;
    private Color silhouetteObjectAttached;
    private Color fullColorObject;
    private bool objectHasCollider = false;
    private bool objectIsPainted = false;
    private string nameObject;
    private int quantityPaintLose;
    private bool checkPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        renderObjectAttached = objectAttached.GetComponent<SpriteRenderer>();
        colliderObject = objectAttached.GetComponent<Collider2D>();
        silhouetteObjectAttached = new Color(0,0,0,255);
        fullColorObject = new Color(255, 255, 255);
        unAlphaObject = new Color(255, 255, 255, 0);
        renderObjectAttached.color = unAlphaObject;
        nameObject = objectAttached.name;
        colliderObject.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q) && checkPlatform)
        {
            paintBar.LosePaint(quantityPaintLose);
            Paint();
            paintBar.GameOver();
        }
    }
    void OnPaint()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (objectIsPainted == false && collision.gameObject.tag == "Player")
        {
            Debug.Log("Aca entra");
                renderObjectAttached.color = silhouetteObjectAttached;
            
        }
            
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            paintBar.LosePaint(quantityPaintLose);
            Paint();
            if (paintBar.GetQuantityPaint() <= 0)
                PlayerMain.Restart();
        }
        checkPlatform = true;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        checkPlatform = false;
        if (!objectIsPainted)
        {
            renderObjectAttached.color = unAlphaObject;
        }
    }

    public void Paint()
    {
        if (objectAttached.name == nameObject)
        {
            if (!objectHasCollider)
            {
                colliderObject.enabled = true;
                objectHasCollider = true;
            }
            //splashPaintController.PlayAnimationSplash();
            renderObjectAttached.color = fullColorObject;
            objectIsPainted = true;
        }
    }

}
