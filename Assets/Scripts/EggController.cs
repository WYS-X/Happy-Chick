using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public float leftTime = 6f;
    private Animator ani;
    public GameObject Chick;
    void Start()
    {
        ani = GetComponent<Animator>();
        Invoke(nameof(PlayLay), leftTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayLay()
    {
        if(ani != null)
        {
            ani.SetTrigger("Crack");
        }
    }

    public void Remove()
    {
        GetComponent<FadeOutAdnDestroy>()?.StartFadeOut();
    }
}
