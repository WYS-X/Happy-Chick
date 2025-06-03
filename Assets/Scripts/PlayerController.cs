using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 8f;
    private Vector2 position;
    private bool isMoving = false;
    public GameObject eggPrefab;
    public Transform eggSpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        
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
            isMoving = true;
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    void HandleMovement()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, position, Speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, position) < 0.01f)
            {
                isMoving = false;
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
