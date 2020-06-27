using UnityEngine;

public class DirtPlatformGenerator : MonoBehaviour
{
    public GameObject start;
    public GameObject middle;
    public GameObject end;
    public GameObject spikes;
    public float spikesProbability = 0.1f;

    const int _MIN_LENGTH = 2;

    public void Generate(int inputLength, Transform parentTransform, float targetY, int speed = 5)
    {
        var length = Mathf.Max(inputLength, _MIN_LENGTH);
        var position = parentTransform.position;
        position.y += targetY;

        Internals.GenerateTile(start, parentTransform, position, speed);

        position.x += 1;

        for (int i = 0; i < length - 2; i++, position.x++)
        {
            if (Random.Range(0f, 1f) < spikesProbability)
                Internals.GenerateTile(spikes, parentTransform, position, speed);
            else
                Internals.GenerateTile(middle, parentTransform, position, speed);
        }

        Internals.GenerateTile(end, parentTransform, position, speed);
    }
}
