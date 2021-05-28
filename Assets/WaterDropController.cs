using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropController : MonoBehaviour
{


    void OnCollisionExit(Collision other)
    {
        float scale = transform.localScale.x - .005f;
        transform.localScale = new Vector3(scale, scale, scale);

    }
    void OnCollisionStay(Collision other)
    {
        float scale = transform.localScale.x;
        if (scale > 0)
        {
            scale = transform.localScale.x - .01f;
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            Destroy(gameObject);
        }


    }
}
