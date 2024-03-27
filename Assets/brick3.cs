using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick3 : MonoBehaviour
{
    public Color mycolor3 = new Color32(255, 248, 134, 255);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<SpriteRenderer>().color == mycolor3)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = mycolor3;
        }
    }
}
