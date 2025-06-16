using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBlink : MonoBehaviour
{
    public Animator animator;
    public string blinkTriggerName = "Blink";
    private float timer = 0f;
    private float blinkInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomInterval(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= blinkInterval)
        {
            animator.SetTrigger(blinkTriggerName);
            timer = 0f;
            SetRandomInterval();
        }
    }

    void SetRandomInterval()
    {
        blinkInterval = Random.Range(2f, 5f);
    }
}
