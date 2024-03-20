using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleControl : MonoBehaviour
{
    public float speed=5;
    public float maxX=7.5f;
    float movementHorizontal;
    private AudioSource boing;

    // Start is called before the first frame update
    void Start()
    {
        boing = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if((movementHorizontal>0 && transform.position.x < maxX) || (movementHorizontal<0 && transform.position.x > -maxX))
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boing.Play();
    }
}