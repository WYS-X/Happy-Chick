using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (Chick != null)
        {
            Chick.transform.localScale = new Vector3(1.5f, 1.5f, 0f);
        }
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
    public void AddSubChick()
    {
        var position = transform.position;
        var obj = Instantiate(Chick, transform.position, Quaternion.identity);
    }
    public void Remove()
    {
        GetComponent<FadeOutAdnDestroy>()?.StartFadeOut();
    }
}
