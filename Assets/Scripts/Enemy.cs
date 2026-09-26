using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool IsDead { get; private set; }

    public float SpawnTime { get; private set; }


    private void Awake()
    {
        SpawnTime = Time.time;
        IsDead = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsDead = true;
        }
    }
}
