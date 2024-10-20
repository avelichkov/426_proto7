using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //Camera offset relative to player
    [SerializeField] float _offset;
    private Transform _player;

    void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            Vector3 playerPos = _player.transform.position;
            transform.position = new Vector3(playerPos.x,playerPos.y + _offset,-100f);
        }
    }
}
