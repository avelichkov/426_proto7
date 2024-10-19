using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] GameObject _spikePrefab;

    void Start()
    {
        Vector3 offset = new Vector3(1f, 0f);
        for (int i = 0; i < 23; i++)
        {
            GameObject instance = Instantiate(_spikePrefab, transform.position + offset * i, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}