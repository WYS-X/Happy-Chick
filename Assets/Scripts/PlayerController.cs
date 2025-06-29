using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 8f;
    private Vector2 position;
    public GameObject eggPrefab;
    public Transform eggSpawnPoint;

    private bool IsLaying = false;
    private bool IsWalking = false;

    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();

        if(eggPrefab != null)
        {
            eggPrefab.transform.localScale = new Vector3(2.7f, 2.7f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleClick();
        HandleMovement();
        HandleIdle();
    }

    void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsWalking)
            {
                ani.SetBool(nameof(IsWalking), true);
                IsWalking = true;
            }
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    void HandleMovement()
    {
        if (IsWalking)
        {
            transform.position = Vector2.MoveTowards(transform.position, position, Speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, position) < 0.01f)
            {
                IsWalking = false;
                ani.SetBool(nameof(IsWalking), false);
                LayEgg();
            }
        }
    }

    void HandleIdle()
    {
        if (ani?.HasState(0, Animator.StringToHash("Idle")) == true)
        {
            SetRandomInterval();
        }
    }
    public string blinkTriggerName = "Blink";
    public string chirpTriggerName = "Chirp";
    private float timer = 0f;
    public float blinkInterval = 3f;
    void SetRandomInterval()
    {
        timer += Time.deltaTime;
        if (timer >= blinkInterval)
        {
            if(Random.value > 0.3)
                ani.SetTrigger(blinkTriggerName);
            else
                ani.SetTrigger(chirpTriggerName);
            timer = 0f;
            blinkInterval = Random.Range(3f, 6f);
        }
    }

    public void Blink()
    {

    }
    public void Walk()
    {

    }
    public void LayEgg()
    {
        if(eggPrefab != null && eggSpawnPoint != null)
        {
            IsLaying = true;
            ani.SetTrigger("Laying");
        }

    }
    public void AddEgg()
    {
        GameManager.Instance.AddScore(1);
        Instantiate(eggPrefab, eggSpawnPoint.position, Quaternion.identity);
    }
    public void Eat()
    {

    }
    public void Drink()
    {

    }
    public void Poop()
    {

    }
    public void Sleep()
    {

    }
    public void Fly()
    {

    }
}
