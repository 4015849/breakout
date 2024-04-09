using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class brick4 : MonoBehaviour
{
    private Position explosionPos;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosionPos = collision.gameObject.GetComponent<Position>();
        Debug.Log(explosionPos);
        Destroy(gameObject);
    }
}
