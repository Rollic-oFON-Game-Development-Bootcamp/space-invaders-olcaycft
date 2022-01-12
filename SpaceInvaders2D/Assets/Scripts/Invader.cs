using System;
using System.Collections;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    private float animationTime = 1f;
    private int animationFrame;
    public static  event Action killed;
    
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer spriteRenderer => _spriteRenderer = GetComponent<SpriteRenderer>();

    private void Awake()
    {
        Invaders.speedChanged += ChangeAnimationSpeed;
        StartCoroutine(nameof(AnimateSprite));
    }

    private void ChangeAnimationSpeed(float newAnimationTime)
    {
        animationTime = newAnimationTime;
    }
    private IEnumerator AnimateSprite()
    {
        while (true)
        {
            animationFrame++;
            if (animationFrame >=animationSprites.Length)
            {
                animationFrame = 0;
            }

            spriteRenderer.sprite = animationSprites[animationFrame];
            yield return new WaitForSeconds(animationTime);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            killed?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
