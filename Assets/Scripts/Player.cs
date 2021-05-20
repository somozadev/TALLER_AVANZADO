using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    public PlayerAbilities playerAbilities = new PlayerAbilities();

}


[System.Serializable]
public class PlayerAbilities
{
    public bool canPoison;
    public bool canFreeze;
    public bool canFlame;
    
    public event Action onPoisonGlobal;
    public event Action onFreezedGlobal;
    public event Action onBurnedGlobal;
    

    public PlayerAbilities()
    {
        this.canPoison = false;
        this.canFreeze = false;
        this.canFlame = false;
    }

    private void PoisonGlobalAttack() { if (onPoisonGlobal != null) { onPoisonGlobal(); } }
    private void FreezedGlobalAttack() { if (onFreezedGlobal != null) { onFreezedGlobal(); } }
    private void BurnedGlobalAttack() { if (onBurnedGlobal != null) { onBurnedGlobal(); } }



    public void ThrowPoison() { PoisonGlobalAttack(); }
    public void ThrowFreeze() { FreezedGlobalAttack(); }
    public void ThrowBurn() { BurnedGlobalAttack(); }


}
