using UnityEngine;

public class TreasureGenerator : MonoBehaviour
{
    public float victoryProbability = 0.15f;
    public GameObject coin;
    public GameObject victory;
    public GameObject platformL;
    public GameObject platformR;

    public void Generate(Transform parentTransform, float targetY, int speed = 5)
    {
        var position = parentTransform.position;
        position.y += targetY;

        Internals.GenerateTile(platformL, parentTransform, position, speed);
        position.x += 1;
        Internals.GenerateTile(platformR, parentTransform, position, speed);

        position.y += 1;
        if (Random.Range(0f, 1f) < victoryProbability)
        {
            Internals.GenerateTile(victory, parentTransform, position, speed);
        }
        else
        {
            Internals.GenerateTile(coin, parentTransform, position, speed);
        }
    }
}
