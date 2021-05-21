using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy
{
    [SerializeField] GameObject poisonLight, freezeLight, fireLight;
    [SerializeField] Animator animator;


    private void GetHit(int amount)
    {
        getStats.Hp -= amount;
        if (getStats.Hp <= 0)
        {
            animator.SetTrigger("Die");
            StartCoroutine(WaitAndDie());
        }
        else
            animator.SetTrigger("Take Damage");
    }

    private IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(3f);
       
        Destroy(gameObject);
    }

    #region  STATUS_EFFECTS
    public override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }
    
    public override void OnBurnedRecieve()
    {
        base.OnBurnedRecieve();
        TriggerFireLight();
        GetHit(20);
    }
    public override void OnPoisonRecieve()
    {
        base.OnPoisonRecieve();
        TriggerPoisonLight();
        GetHit(40);
    }
    public override void OnFreezedRecieve()
    {
        base.OnFreezedRecieve();
        TriggerFreezeLight();
        GetHit(5);

    }


    private void TriggerPoisonLight()
    {
        poisonLight.SetActive(true);
        freezeLight.SetActive(false);
        fireLight.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(WaitToDeactivate(poisonLight));
    }
    private void TriggerFreezeLight()
    {
        freezeLight.SetActive(true);
        poisonLight.SetActive(false);
        fireLight.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(WaitToDeactivate(freezeLight));
    }
    private void TriggerFireLight()
    {
        fireLight.SetActive(true);
        poisonLight.SetActive(false);
        freezeLight.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(WaitToDeactivate(fireLight));
    }

    IEnumerator WaitToDeactivate(GameObject light)
    {
        yield return new WaitForSeconds(2f);
        light.SetActive(false);
    }
    #endregion


}

public enum ENEMY_STATE_MACHINE
{
    IDLE,
    MOVING,
    DAMAGED,
    ATTACK,
    DIE
}