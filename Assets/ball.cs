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
    public int lives = 5;
    public TextMeshProUGUI scoreTxt;
    public GameObject[] livesImage;
    public GameObject gameOver;
    public GameObject youWin;
    int brickCount;
    public GameObject paddle;
    private AudioSource bonk;
    public GameObject readyTxt;
    public GameObject goTxt;
    public float bounds = 0.05f;
    public bool launched = false;
    public GameObject pauseMenu;
    public int brick1Count;
    public int brick2Count;
    public int brick3Count;
    public int brick4Count;
    public GameObject level1;
    public GameObject level2;
    public GameObject nextLevel1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * 10f;
        brick1Count = GameObject.FindGameObjectsWithTag("brick1").Length * 4;
        brick2Count = GameObject.FindGameObjectsWithTag("brick2").Length * 3;
        brick3Count = GameObject.FindGameObjectsWithTag("brick3").Length * 2;
        brick4Count = GameObject.FindGameObjectsWithTag("brick4").Length;
        brickCount = brick1Count + brick2Count + brick3Count + brick4Count;
        bonk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
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
                launched = false;
                StartCoroutine(ballWait());
            }

        }

        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }

        if(launched == true)
        {
            if (rb.velocity.y > -bounds && rb.velocity.y < bounds)
            {
                Debug.Log("ball stuck, forcing velocity down");
                rb.velocity += Vector2.down;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("brick1") || collision.gameObject.CompareTag ("brick2") || collision.gameObject.CompareTag ("brick3") || collision.gameObject.CompareTag ("brick4"))
        {
            bonk.Play();
            score += 10;
            scoreTxt.text = score.ToString("00000");
            brickCount--;
            if (brickCount <= 0)
            {
                Debug.Log("next level");
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
        launched = true;
        StartCoroutine(textOff());
    }

    IEnumerator textOff()
    {
        yield return new WaitForSeconds(1);
        goTxt.SetActive(false);
    }

    void nextLevel()
    {
        nextLevel1.SetActive(true);
        transform.position = Vector3.down;
        rb.velocity = Vector2.zero;
        paddle.transform.position = new Vector3(0, (float)-4.5, 0);
        readyTxt.SetActive(false);
        goTxt.SetActive(false);
        launched = false;
    }

    public void nextLevelClick()
    {
        level2.SetActive(true);
        StartCoroutine(ballWait()); 
    }
}
