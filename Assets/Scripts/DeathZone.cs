using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathZone : MonoBehaviour
{
    public bool regenerateBackground = true;
    public bool destroyNonPlayerObjects = true;
    public Generator cloudGenerator;
    public List<string> backgroundTags = new List<string>() { "Cloud", "Mountain" };

    // Handle gameobjects collider with a deathzone object
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // if player then tell the player to do its FallDeath
            other.gameObject.GetComponent<CharacterController2D>().FallDeath();
        }

        if (backgroundTags.Contains(other.gameObject.tag) && regenerateBackground)
        {
            cloudGenerator.Generate();
        }

        if (destroyNonPlayerObjects)
        {
            // not player so just kill object - could be falling enemy for example
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // if player then tell the player to do its FallDeath
            other.gameObject.GetComponent<CharacterController2D>().FallDeath();
        }

        if (backgroundTags.Contains(other.gameObject.tag) && regenerateBackground)
        {
            cloudGenerator.Generate();
        }

        if (destroyNonPlayerObjects)
        {
            // not player so just kill object - could be falling enemy for example
            Destroy(other.gameObject);
        }
    }
}
