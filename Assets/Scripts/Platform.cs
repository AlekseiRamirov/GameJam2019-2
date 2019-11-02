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

    public SpriteRenderer renderObjectAttached;
    public BoxCollider2D boxColliderObject;
    public Color unAlphaObject;
    public Color silhouetteObjectAttached;
    public Color fullColorObject;
    public bool objectHasCollider = false;
    public bool objectIsPainted = false;
    public string nameObject;
    public int quantityPaintLose;
    private bool paint = false;
    // Start is called before the first frame update
    void Start()
    {
        renderObjectAttached = objectAttached.GetComponent<SpriteRenderer>();
        silhouetteObjectAttached = new Color(0,0,0,255);
        fullColorObject = new Color(255, 255, 255);
        unAlphaObject = new Color(255, 255, 255, 0);
        renderObjectAttached.color = unAlphaObject;
        nameObject = objectAttached.name;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnPaint(InputValue value)
    {
        paint = (int)value.Get<float>() != 0;
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            paintBar.LosePaint(quantityPaintLose);
            Paint();
            paintBar.GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
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
                boxColliderObject = objectAttached.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
                objectHasCollider = true;
            }
            renderObjectAttached.color = fullColorObject;
            objectIsPainted = true;
        }
    }

}
