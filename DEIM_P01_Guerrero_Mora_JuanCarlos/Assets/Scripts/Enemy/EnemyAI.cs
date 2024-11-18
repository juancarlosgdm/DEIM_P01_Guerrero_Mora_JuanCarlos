using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState { Stopped, Move, Follow, Attack, Dead }

    private EnemyState state;

    private float health = 4;

    private AIPath pathAgent;

    [SerializeField] private Transform playerTrf;

    [SerializeField] private float followRange;

    [SerializeField] private LayerMask followLayerMask;

    [SerializeField] private ParticleSystem particles;

    private void Awake()
    {
        pathAgent = GetComponent<AIPath>();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Follow;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != EnemyState.Dead)
        {
            if (health <= 0)
            {
                GoToDeath();
            }
            else
            {
                switch (state)
                {
                    case EnemyState.Stopped:
                        if (InFollowRange())
                        {

                        }
                        break;
                    case EnemyState.Move:
                        break;
                    case EnemyState.Follow:
                        if (!InFollowRange())
                        {
                            GoToStopped();
                        }
                        else if (InAttackRange())
                        {
                            GoToAttack();
                        }
                        else
                        {
                            pathAgent.destination = playerTrf.position;
                        }
                        break;
                    case EnemyState.Attack:
                        break;
                }
            }
        }
    }

    private void GoToAttack()
    {
        state = EnemyState.Attack;
        pathAgent.canMove = false;
    }

    private void GoToDeath()
    {
        state = EnemyState.Dead;
    }

    private void GoToStopped()
    {
        state = EnemyState.Stopped;
        pathAgent.canMove = false;
        particles.Stop();
        particles.Clear();
    }


    private bool InAttackRange()
    {
        return false;
    }

    private bool InFollowRange()
    {
        bool res = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTrf.position - transform.position, followRange, followLayerMask);
        if ((hit.collider != null) && (hit.collider.CompareTag("Player"))) {
            res = true;
        }

        return res;
    }
}