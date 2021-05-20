using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] EnemyStats stats = new EnemyStats();
    public EnemyStats getStats { get { return stats; } }

    public virtual void Start()
    {   stats = new EnemyStats(100, 100, 10, 5, StatusState.NORMAL,ENEMY_STATE_MACHINE.IDLE);
        GameManager.Instance.player.playerAbilities.onPoisonGlobal += OnPoisonRecieve;
        GameManager.Instance.player.playerAbilities.onFreezedGlobal += OnFreezedRecieve;
        GameManager.Instance.player.playerAbilities.onBurnedGlobal += OnBurnedRecieve;
    }
    public virtual void OnPoisonRecieve() { getStats.State = StatusState.POISONED;}
    public virtual void OnFreezedRecieve() { getStats.State = StatusState.FREEZED;}
    public virtual void OnBurnedRecieve() { getStats.State = StatusState.BURNED;}

}

[System.Serializable]
public class EnemyStats
{
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private int dmg;
    [SerializeField] private int speed;
    [SerializeField] private StatusState state;
    [SerializeField] private ENEMY_STATE_MACHINE statemachine;


    public int Hp { get { return hp; } set { hp = value; } }
    public int MaxHp { get { return maxHp; } set { maxHp = value; } }
    public int Dmg { get { return dmg; } set { dmg = value; } }
    public int Speed { get { return speed; } set { speed = value; } }
    public StatusState State { get { return state; } set { state = value; } }
    public ENEMY_STATE_MACHINE StateMachine { get { return statemachine; } set { StateMachine = value; } }

    public EnemyStats() { }
    public EnemyStats(int hp, int maxHp, int dmg, int speed, StatusState state, ENEMY_STATE_MACHINE statemachine)
    {
        this.Hp = hp;
        this.MaxHp = maxHp;
        this.Dmg = dmg;
        this.Speed = speed;
        this.State = state;
        this.statemachine = statemachine;
    }
}

public enum StatusState
{
    NORMAL,
    POISONED,
    FREEZED,
    BURNED,

}