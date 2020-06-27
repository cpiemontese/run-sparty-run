using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] props;
    [Range(0f, 5f)]
    public float area = 1f;
    public bool generateContinuosly = false;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.5f;
    public float minSpeed = 1f;
    public float maxSpeed = 2f;
    public CharacterController2D player;

    float _timer;

    void Awake()
    {
        _timer = 0f;

        if (props == null)
        {
            Debug.LogWarning("Generator: no prop assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!generateContinuosly)
            return;

        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            // Generate prop
            _timer = Random.Range(minSpawnTime, maxSpawnTime);
            Generate();
        }
    }

    public GameObject Generate()
    {
        var idx = Random.Range(0, props.Length);
        var prop = Instantiate(props[idx], transform, false);

        var moveWithPlayer = prop.GetComponent<MoveWithPlayer>();
        moveWithPlayer.player = player;

        var scroll = prop.GetComponent<Scroll>();
        scroll.speed = Random.Range(minSpeed, maxSpeed);

        var propY = Random.Range(-area, area);
        prop.transform.Translate(new Vector3(0f, propY, 0f));
        return prop;
    }
}
