using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick3 : MonoBehaviour
{
    public Color mycolor3 = new Color32(255, 248, 134, 255);
    public ParticleSystem explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<SpriteRenderer>().color == mycolor3)
        {
            explosion.Play();
            Debug.Log("explode brick3");
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(brickDestroy());
        }
        else
        {
            GetComponent<SpriteRenderer>().color = mycolor3;
        }
    }
    IEnumerator brickDestroy()
    {
        yield return new WaitForSeconds(0.36f);
        Destroy(gameObject);
        Debug.Log("destroyed brick3");
    }
}
