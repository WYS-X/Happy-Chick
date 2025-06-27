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
        obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.35f);
    }
    public void Remove()
    {
        GetComponent<FadeOutAdnDestroy>()?.StartFadeOut();
    }
}
