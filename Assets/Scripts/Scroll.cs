using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 1f;
    [Range(-1, 1)]
    public int direction = -1;

    void Update()
    {
        transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0f, 0f), Space.World);
    }
}
