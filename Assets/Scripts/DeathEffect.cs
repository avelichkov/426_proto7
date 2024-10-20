using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] float _deathAnimLength;
    void Start()
    {
        StartCoroutine(Death());
    }
    private IEnumerator Death()
    {
        GameManager.instance.isGameOver = true;
        yield return new WaitForSeconds(_deathAnimLength);
        GameManager.instance.deathAnimOver = true;
    }
}