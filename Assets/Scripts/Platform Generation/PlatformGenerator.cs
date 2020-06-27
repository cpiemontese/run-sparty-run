using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Range(0, 5)]
    public int area = 1;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.5f;
    [Range(5, 10)]
    public int platformsSpeed = 5;
    [Range(2, 6)]
    public int dirtPlatformMinLength = 2;
    [Range(6, 10)]
    public int dirtPlatformMaxLength = 6;
    public float dirtPlatformProbability = 0.25f;
    public DirtPlatformGenerator dirtPlatformGenerator;
    public float victoryProbability = 0.1f;
    public GameObject victory;
    public float treasureProbability = 0.2f;
    public TreasureGenerator treasureGenerator;
    [Range(1, 2)]
    public int basicPlatformMinLength = 2;
    [Range(2, 3)]
    public int basicPlatformMaxLength = 6;
    public float basicPlatformProbability = 0.25f;
    public BasicPlatformGenerator basicPlatformGenerator;
    public float hybridProbability = 0.20f;
    public HybridGenerator hybridGenerator;

    // How much should speed be increased by...?
    public int speedBump = 1;
    // Time in minutes at which to increase speed
    public float[] speedBumpTimes = { 1, 2, 3, 4, 5 };

    [SerializeField]
    float _timer;
    [SerializeField]
    int _lastPosition;
    [SerializeField]
    int _currentSpeedBump;
    float _totalTime;

    void Awake()
    {
        _timer = 0f;
        _lastPosition = -1;
        _currentSpeedBump = -1;
        _totalTime = 0f;

        var probabilitiesSum = dirtPlatformProbability
                   + victoryProbability
                   + treasureProbability
                   + basicPlatformProbability
                   + hybridProbability;

        if (!Mathf.Approximately(probabilitiesSum, 1f))
        {
            Debug.LogError("Probabilities should add up to 1");
        }
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        _totalTime += Time.deltaTime;

        if (_currentSpeedBump < speedBumpTimes.Length - 1 && _totalTime >= speedBumpTimes[_currentSpeedBump + 1] * 60)
        {
            _currentSpeedBump += 1;
            platformsSpeed += speedBump;
        }

        if (_timer <= 0f)
        {
            _timer = Random.Range(minSpawnTime, maxSpawnTime);

            var targetY = Random.Range(-area, area);
            // Generate a y position until you generate one different from the previous one
            while (_lastPosition - 1 <= targetY && targetY <= _lastPosition + 1)
            {
                targetY = Random.Range(-area, area);
            }
            _lastPosition = targetY;

            var roll = Random.Range(0f, 1f);
            if (roll < victoryProbability)
            {
                var gameObject = Instantiate(victory, transform, false);
                Scroll scroll = gameObject.GetComponent<Scroll>();
                scroll.speed = platformsSpeed;
            }
            else if (roll < treasureProbability + victoryProbability)
            {
                treasureGenerator.Generate(transform, targetY, platformsSpeed);
            }
            else if (roll < basicPlatformProbability + treasureProbability + victoryProbability)
            {
                basicPlatformGenerator.Generate(Random.Range(basicPlatformMinLength, basicPlatformMaxLength), transform, targetY, platformsSpeed);
            }
            else if (roll < hybridProbability + basicPlatformProbability + treasureProbability + victoryProbability)
            {
                hybridGenerator.Generate(transform, targetY, platformsSpeed);
            }
            else
            {
                dirtPlatformGenerator.Generate(Random.Range(dirtPlatformMinLength, dirtPlatformMaxLength), transform, targetY, platformsSpeed);
            }
        }
    }
}
