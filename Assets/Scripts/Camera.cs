using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //Camera offset relative to player
    [SerializeField] float _offset;
    [SerializeField] float _smoothSpeed;
    private Transform _player;

    void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (!_player) return;
        Vector3 playerPos = _player.transform.position;
        Vector3 targetPos = new Vector3(playerPos.x,playerPos.y + _offset,-100f);
        transform.position = Vector3.Lerp(transform.position, targetPos, _smoothSpeed);
    }
}
