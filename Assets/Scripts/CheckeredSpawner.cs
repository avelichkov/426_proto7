using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckeredSpawner : MonoBehaviour
{
    [SerializeField] GameObject _squarePrefab;
    [SerializeField] float _squareWidth;
    [SerializeField] int _rowNum;
    [SerializeField] int _colNum;

    void Start()
    {
        bool on = true;
        Vector3 pos = transform.position;
        for (int row = 0; row < _rowNum; row++)
        {
            for (int col = 0; col < _colNum; col++)
            {
                if (on)
                {
                    Vector3 newPos = transform.position + Vector3.up * row * _squareWidth + Vector3.right * col * _squareWidth;
                    Instantiate(_squarePrefab,newPos, Quaternion.identity, this.transform);
                }
                on = !on;
            }
        }

    }
}
