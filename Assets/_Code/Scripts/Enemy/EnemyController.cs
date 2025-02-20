using Assets._Code.Scripts.Enemy;
using Assets._Code.Scripts.Enemy.States;
using Assets._Code.Scripts.Util;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameManagerController gameManagerController;

    EnemyBaseState currentState;

    public EnemyAliveState AliveState = new EnemyAliveState();
    public EnemyDeathState DeathState = new EnemyDeathState();
    public EnemyWinState WinState = new EnemyWinState();

    public Rigidbody body;

    void Start()
    {
        gameManagerController = GameObject.FindGameObjectWithTag(Tags.GameManager).GetComponent<GameManagerController>();

        currentState = AliveState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }
}
