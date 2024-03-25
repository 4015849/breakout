using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    public Color mycolor = new Color32(235, 64, 52, 255);
    public Color mycolor2 = new Color32(171, 48, 39, 255);
    public Color mycolor3 = new Color32(105, 29, 23, 255);
    public Color basecolor1 = new Color32(255, 134, 183, 255);
    public Color basecolor2 = new Color32(152, 255, 134, 255);
    public Color basecolor3 = new Color32(134, 235, 255, 255);
    public Color basecolor4 = new Color32(255, 248, 134, 255);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<SpriteRenderer>().color == mycolor3)
        {
            Debug.Log("four hit");
            Destroy(gameObject);
        }

        if (GetComponent<SpriteRenderer>().color == mycolor2)
        {
            Debug.Log("three hit");
            GetComponent<SpriteRenderer>().color = mycolor3;
        }

        if (GetComponent<SpriteRenderer>().color == mycolor)
        {
            Debug.Log("two hit");
            GetComponent<SpriteRenderer>().color = mycolor2;
        }

        if (GetComponent <SpriteRenderer>().color != mycolor && GetComponent<SpriteRenderer>().color != mycolor2 && GetComponent<SpriteRenderer>().color != mycolor3)
        {
            Debug.Log("one hit");
            GetComponent<SpriteRenderer>().color = mycolor;
        }
    }
}
