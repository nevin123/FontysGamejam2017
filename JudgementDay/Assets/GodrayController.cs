using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodrayController : MonoBehaviour {

    [Range(0, 1)]
    public float MinOpacity = 0;
    [Range(0, 1)]
    public float MaxOpacity = 1;

    public float OpacitySmoothing = 1;

    [Space]
    public float OffsetSpeed = 1f;

    bool adding = true;
    float godrayAlpha;
    Material godrayMat;

    void Start()
    {
        godrayMat = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (adding)
        {
            godrayAlpha += OpacitySmoothing * Time.deltaTime;
            transform.position += Vector3.left * OffsetSpeed * Time.deltaTime;
            if (godrayAlpha >= MaxOpacity)
                adding = false;
        } else
        {
            godrayAlpha -= OpacitySmoothing * Time.deltaTime;
            transform.position -= Vector3.left * OffsetSpeed * Time.deltaTime;
            if (godrayAlpha <= MinOpacity)
                adding = true;
        }

        
        Color _godrayColor = godrayMat.color;
        _godrayColor.a = godrayAlpha;
        godrayMat.color = _godrayColor;
    }
}
