using UnityEngine;

public class EnemyAI_Spider : MonoBehaviour {
    enum State { Idle, Patrol, Chase, Attack }
    State currentState = State.Idle;

    public Transform[] patrolPoints;
    int patrolIndex = 0;
    public float speed = 2f;
    public float chaseRange = 5f;
    public float attackRange = 1f;
    public Transform player;

    void Update() {
        switch (currentState) {
            case State.Idle:
                if (Vector2.Distance(transform.position, player.position) < chaseRange)
                    currentState = State.Chase;
                else
                    currentState = State.Patrol;
                break;

            case State.Patrol:
                Patrol();
                break;

            case State.Chase:
                Chase();
                break;

            case State.Attack:
                Attack();
                break;
        }
    }

    void Patrol() {
        Transform target = patrolPoints[patrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
    }

    void Chase() {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, player.position) < attackRange)
            currentState = State.Attack;
    }

    void Attack() {
        Debug.Log("Spider attacks!");
        currentState = State.Chase;
    }
}
