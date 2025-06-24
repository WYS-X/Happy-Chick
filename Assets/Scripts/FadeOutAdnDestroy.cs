using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutAdnDestroy : MonoBehaviour
{
    public float duration = 0.1f;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void StartFadeOut()
    {
        StartCoroutine(FadeAndDestroy());
    }

    private IEnumerator FadeAndDestroy()
    {
        float time = 0f;
        Color color = renderer.color;

        while(time < duration)
        {
            float alpha = Mathf.Lerp(1, 0, time / duration);
            renderer.color = new Color(color.r, color.g, color.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }
        renderer.color = new Color(color.r, color.g, color.b, 0);
        Destroy(gameObject);
    }
}
