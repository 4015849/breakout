using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    public Color mycolor = new Color32(235, 64, 52, 255);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<SpriteRenderer>().material.color == mycolor)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = mycolor;
        }

    }
}
