using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossActionType
{
    Idle,
    Moving,
    AvoidingObstacle,
    Patrolling,
    Attacking
}

switch (eCurState)
{
    case BossActionType.Idle:
        HandleIdleState();
        break;
 
    case BossActionType.Moving:
        HandleMovingState();
        break;
 
    case BossActionType.AvoidingObstacle:
        HandleAvoidingObstacleState();
        break;
 
    case BossActionType.Patrolling:
        HandlePatrollingState();
        break;
 
    case BossActionType.Attacking:
        HandleAttackingState();
        break;
}
