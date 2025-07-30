using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmming : MonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 5f;
    [SerializeField] protected int score = 0;

    private void Start()
    {
        StartCoroutine(this.Farm());
    }

    protected IEnumerator Farm()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.delay);

            this.score = Random.Range(5, 10);
            Score.Instance.AddScore(this.score);

            Debug.Log("Your Score: " + Score.Instance._Score);
        }
    }
}
