using UnityEngine;

public class HybridGenerator : MonoBehaviour
{
    public GameObject dirtLeft;
    public GameObject dirtRight;
    public GameObject platform;

    public void Generate(Transform parentTransform, float targetY, int speed = 5)
    {
        var position = parentTransform.position;
        position.y += targetY;

        Internals.GenerateTile(dirtLeft, parentTransform, position, speed);
        position.x += 1;
        Internals.GenerateTile(dirtRight, parentTransform, position, speed);
        position.x += 1.5f;
        Internals.GenerateTile(platform, parentTransform, position, speed);
        position.x += 1.5f;
        Internals.GenerateTile(dirtLeft, parentTransform, position, speed);
        position.x += 1;
        Internals.GenerateTile(dirtRight, parentTransform, position, speed);
    }
}
