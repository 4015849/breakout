using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class brick4 : MonoBehaviour
{
    public ParticleSystem explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosion.Play();
        Debug.Log("explode brick4");
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(brickDestroy());
    }

    IEnumerator brickDestroy()
    {
        yield return new WaitForSeconds(0.36f);
        Destroy(gameObject);
        Debug.Log("destroyed brick4");
    }
}
