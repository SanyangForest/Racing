using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PenguinController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    public float moveSpeed = 5.0f;
    private bool isColliding = false;
    private GameManager gameManager;
    private bool isPenguinActive = false; // 게임 시작 시 비활성화
    public float minSpeed = 0.1f;
    public float maxSpeed = 2.0f;
    private int betAmount = 0; // 팽귄이 받을 배팅 금액
    private int penguinNumber; // 팽귄 번호

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(RandomizeSpeed());
    }

    void Update()
    {
        if (isPenguinActive)
        {
            if (!isColliding)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPenguinActive)
        {
            if (collision.gameObject.CompareTag("OtherObject"))
            {
                gameManager.PenguinCollision();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPenguinActive)
        {
            if (other.gameObject.CompareTag("Penguin"))
            {
                gameManager.PenguinCollision();
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
        isPenguinActive = false;
        rb.velocity = Vector2.zero;
    }

    public void ActivatePenguin()
    {
        isPenguinActive = true;
    }

    public void DeactivatePenguin()
    {
        isPenguinActive = false;
    }

    public IEnumerator RandomizeSpeed()
    {
        while (true)
        {
            float newSpeed = Random.Range(minSpeed, maxSpeed);
            if (isPenguinActive)
            {
                rb.velocity = new Vector2(newSpeed, rb.velocity.y);
            }
            yield return new WaitForSeconds(Random.Range(0.3f, 0.6f)); // 원하는 주기로 설정
        }
    }
    
    public void SetPenguinNumber(int number)
    {
        penguinNumber = number;
    }

    public void SetBetAmount(int amount)
    {
        betAmount = amount;
    }
    public void Reward(int rewardAmount)
    {
        gameManager.Reward(rewardAmount, penguinNumber);
    }
}