using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool IsDead { get; private set; }

    private float _timeToDie = 5;
    private float _timer;
    public float TimeToDie => _timer;

    private void Awake()
    {
        _timer = _timeToDie;
        IsDead = false;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsDead = true;
        }
    }
}
