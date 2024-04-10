using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick2 : MonoBehaviour
{
    public Color mycolor2 = new Color32(134, 235, 255, 255);
    public Color mycolor3 = new Color32(255, 248, 134, 255);
    public ParticleSystem explosion;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<SpriteRenderer>().color == mycolor3)
        {
            explosion.Play();
            Debug.Log("explode brick2");
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(brickDestroy());
        }

        if (GetComponent<SpriteRenderer>().color == mycolor2)
        {
            GetComponent<SpriteRenderer>().color = mycolor3;
        }

        if (GetComponent<SpriteRenderer>().color != mycolor2 && GetComponent<SpriteRenderer>().color != mycolor3)
        {
            GetComponent<SpriteRenderer>().color = mycolor2;
        }
    }

    IEnumerator brickDestroy()
    {
        yield return new WaitForSeconds(0.36f);
        Destroy(gameObject);
        Debug.Log("destroyed brick2");
    }
}
