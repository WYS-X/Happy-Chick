using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public float leftTime = 5f;
    void Start()
    {
        Destroy(gameObject, leftTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
