using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy
{
    [SerializeField] GameObject poisonLight, freezeLight, fireLight;
    [SerializeField] Animator animator;

    


    #region  STATUS_EFFECTS
    public override void Start()
    {
        base.Start();
    }
    public override void OnBurnedRecieve()
    {
        base.OnBurnedRecieve();
        TriggerFireLight();

    }
    public override void OnPoisonRecieve()
    {
        base.OnPoisonRecieve();
        TriggerPoisonLight();

    }
    public override void OnFreezedRecieve()
    {
        base.OnFreezedRecieve();
        TriggerFreezeLight();

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