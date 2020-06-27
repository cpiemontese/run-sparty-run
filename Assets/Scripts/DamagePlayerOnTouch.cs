using UnityEngine;

public class DamagePlayerOnTouch : MonoBehaviour
{
    public int damageAmount = 10;
    public AudioClip onTouchClip = null;
    public bool destroyEnemy = true;

    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        DamageIfPlayer(collider);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DamageIfPlayer(collision.collider);
    }

    void DamageIfPlayer(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterController2D player = collision.gameObject.GetComponent<CharacterController2D>();
            if (player.playerCanMove)
            {
                PlaySound();
                player.ApplyDamage(damageAmount);
            }
        }

        if (collision.tag == "Enemy" && destroyEnemy)
        {
            PlaySound();
            Destroy(collision.gameObject);
        }
    }

    void PlaySound()
    {
        if (_audioSource != null && onTouchClip != null)
            _audioSource.PlayOneShot(onTouchClip);
    }
}
