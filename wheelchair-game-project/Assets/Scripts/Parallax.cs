using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float len;
    private float StartPos;
    public float ParallaxEffect;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        len = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        float RePos = cam.transform.position.x * (1 - ParallaxEffect);
        float Distance = cam.transform.position.x * ParallaxEffect;
        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z);

        if (RePos > StartPos + len)
        {
            StartPos += len;
        }
        else if (RePos < StartPos - len) {
            StartPos -= len;
        }

    }
}
