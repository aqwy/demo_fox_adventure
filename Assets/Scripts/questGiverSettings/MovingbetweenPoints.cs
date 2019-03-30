using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingbetweenPoints : MonoBehaviour
{
    private bool dirRight = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= -1f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -13f)
        {
            dirRight = true;
        }
    }  
}
