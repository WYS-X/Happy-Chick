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
    }

    // Update is called once per frame
    void Update()
    {
        HandleClick();
        HandleMovement();
    }

    void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsWalking = true;
            ani.SetBool(nameof(IsWalking), true);
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
            ani.SetBool(nameof(IsLaying), true);
            Instantiate(eggPrefab, eggSpawnPoint.position, Quaternion.identity);
        }

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
