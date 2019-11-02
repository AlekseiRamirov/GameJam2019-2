using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBar : MonoBehaviour
{
    private Transform bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        //SetSize(5f);
    }

    // Update is called once per frame
    void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
