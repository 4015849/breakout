using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick2 : MonoBehaviour
{
    public Color mycolor2 = new Color32(134, 235, 255, 255);
    public Color mycolor3 = new Color32(255, 248, 134, 255);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<SpriteRenderer>().color == mycolor3)
        {
            Debug.Log("three hit");
            Destroy(gameObject);
        }

        if (GetComponent<SpriteRenderer>().color == mycolor2)
        {
            Debug.Log("two hit");
            GetComponent<SpriteRenderer>().color = mycolor3;
        }

        if (GetComponent<SpriteRenderer>().color != mycolor2 && GetComponent<SpriteRenderer>().color != mycolor3)
        {
            Debug.Log("one hit");
            GetComponent<SpriteRenderer>().color = mycolor2;
        }
    }
}
