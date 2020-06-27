using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveWithPlayer : MonoBehaviour
{
    public float moveSpeed = 6f;
    public CharacterController2D player;

    private Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!player.playerCanMove || (Time.timeScale == 0f))
            return;

        var _vx = CrossPlatformInputManager.GetAxisRaw("Horizontal");
    }
}
