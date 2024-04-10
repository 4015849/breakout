using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class brick : MonoBehaviour
{
    public Color mycolor = new Color32(152, 255, 134, 255);
    public Color mycolor2 = new Color32(134, 235, 255, 255);
    public Color mycolor3 = new Color32(255, 248, 134, 255);
    public ParticleSystem explosion;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<SpriteRenderer>().color == mycolor3)
        {
            explosion.Play();
            Debug.Log("explode brick1");
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(brickDestroy());
        }

        if (GetComponent<SpriteRenderer>().color == mycolor2)
        {
            GetComponent<SpriteRenderer>().color = mycolor3;
        }

        if (GetComponent<SpriteRenderer>().color == mycolor)
        {
            GetComponent<SpriteRenderer>().color = mycolor2;
        }

        if (GetComponent <SpriteRenderer>().color != mycolor && GetComponent<SpriteRenderer>().color != mycolor2 && GetComponent<SpriteRenderer>().color != mycolor3)
        {
            GetComponent<SpriteRenderer>().color = mycolor;
        }
    }

    IEnumerator brickDestroy()
    {
        yield return new WaitForSeconds(0.36f);
        Destroy(gameObject);
        Debug.Log("destroyed brick1");
    }
}
