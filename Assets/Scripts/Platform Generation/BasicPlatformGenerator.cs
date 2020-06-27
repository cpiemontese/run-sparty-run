using UnityEngine;

public class BasicPlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public GameObject enemy;
    public float enemyProbability = 0.1f;

    const int _MIN_LENGTH = 1;

    public void Generate(int inputLength, Transform parentTransform, float targetY, int speed = 5)
    {
        var length = Mathf.Max(inputLength, _MIN_LENGTH);
        var position = parentTransform.position;
        position.y += targetY;

        Internals.GenerateTile(platform, parentTransform, position, speed);

        position.x += 2;

        for (int i = 0; i < length - 2; i++, position.x += 2)
        {
            Internals.GenerateTile(platform, parentTransform, position, speed);
        }

        Internals.GenerateTile(platform, parentTransform, position, speed);

        if (Random.Range(0f, 1f) < enemyProbability)
        {
            var enemyPosition = new Vector3(parentTransform.position.x, position.y + 1f, position.z);
            var enemyGameObject = Instantiate(enemy, parentTransform, false);
            enemyGameObject.transform.position = enemyPosition;
        }
    }


}
