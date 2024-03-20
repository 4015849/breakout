using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ball : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    Rigidbody2D rb;
    int score = 0;
    int lives = 5;
    public TextMeshProUGUI scoreTxt;
    public GameObject[] livesImage;
    public GameObject gameOver;
    public GameObject youWin;
    int brickCount;
    public GameObject paddle;
    private AudioSource bonk;
    public GameObject readyTxt;
    public GameObject goTxt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brickCount = FindObjectOfType<LevelGenerator>().transform.childCount;
        rb.velocity = Vector2.down * 10f;
        bonk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY)
        {
            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.down;
                rb.velocity = Vector2.zero;
                lives--;
                livesImage[lives].SetActive(false);
                paddle.transform.position = new Vector3(0, (float)-4.5, 0);
                goTxt.SetActive(false);
                StartCoroutine(ballWait());
            }

        }

        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            bonk.Play();
            Destroy(collision.gameObject);
            score += 10;
            scoreTxt.text = score.ToString("00000");
            brickCount--;
            if (brickCount <= 0)
            {
                youWin.SetActive(true);
                Time.timeScale = 0;
                goTxt.SetActive(false);
                readyTxt.SetActive(false);
            }
        }
    }

    void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
        goTxt.SetActive(false);
        readyTxt.SetActive(false);
    }

    IEnumerator ballWait()
    {
        readyTxt.SetActive(true);
        yield return new WaitForSeconds(1);
        readyTxt.SetActive(false);
        goTxt.SetActive(true);
        rb.velocity = Vector2.down * 10f;
        StartCoroutine(textOff());
    }

    IEnumerator textOff()
    {
        yield return new WaitForSeconds(1);
        goTxt.SetActive(false);
    }
}
