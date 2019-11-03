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
    private Animator splashPaintController;

    private SpriteRenderer renderObjectAttached;
    private Collider2D colliderObject;
    private Color unAlphaObject;
    private Color silhouetteObjectAttached;
    private Color fullColorObject;
    private bool objectHasCollider = false;
    private bool objectIsPainted = false;
    private string nameObject;
    public int quantityPaintLose;
    private bool checkPlatform = false;
    private int quantityChildsObject;

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
        if(colliderObject != null)colliderObject.enabled = false;
        quantityChildsObject = objectAttached.GetComponentsInChildren<SpriteRenderer>().Length;  
        for (int i = 0; i < quantityChildsObject; i++)
        {
            if (objectAttached.transform.GetChild(i).GetComponent<SpriteRenderer>() != null && objectAttached.transform.childCount > 0)
            {
                objectAttached.transform.GetChild(i).GetComponent<SpriteRenderer>().color = unAlphaObject;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q) && checkPlatform)
        {
            paintBar.LosePaint(quantityPaintLose);
            splashPaintController.SetTrigger("Splash");
            //Paint();
            if (paintBar.GetQuantityPaint() <= 0)
                PlayerMain.Restart();
        }
    }
    void OnPaint()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (objectIsPainted == false && collision.gameObject.tag == "Player")
        {
            //Debug.Log("Aca entra");
                renderObjectAttached.color = silhouetteObjectAttached;
            for (int i = 0; i < objectAttached.GetComponentsInChildren<SpriteRenderer>().Length; i++)
            {
                objectAttached.GetComponentInChildren<SpriteRenderer>().color = silhouetteObjectAttached;
            }
            
        }
            
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
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
            if (!objectHasCollider && colliderObject != null)
            {
                colliderObject.enabled = true;
                objectHasCollider = true;
            }
            renderObjectAttached.color = fullColorObject;
            objectIsPainted = true;
            if(objectAttached.GetComponent<Animator>() != null)
                    objectAttached.GetComponent<Animator>().SetTrigger("Passive");
        }
    }

}
