using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walls : MonoBehaviour
{
    private AudioSource wallBonk;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        wallBonk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ball)
        {
            wallBonk.Play();
        }
    }
}
