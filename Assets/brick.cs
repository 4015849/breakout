using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>().material.color == new Color32(214, 163, 184, 255))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = new Color32(214, 163, 184, 255);
        }
    }
}
