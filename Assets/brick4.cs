using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick4 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("one hit");
        Destroy(gameObject);
    }
}
