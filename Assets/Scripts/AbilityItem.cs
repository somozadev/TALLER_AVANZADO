using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityItem : Item
{
    [SerializeField] AbilityType abilityType;

    public override void PerformPickUp()
    {
        switch (abilityType)
        {
            case AbilityType.VENOM:
                GameManager.Instance.player.playerAbilities.canPoison = true;
                break;
            case AbilityType.FREEZE:
                GameManager.Instance.player.playerAbilities.canFreeze = true;
                break;
            case AbilityType.FLAME:
                GameManager.Instance.player.playerAbilities.canFlame = true;
                break;
        }

        Destroy(gameObject);
    }
}
public enum AbilityType
{
    VENOM,
    FREEZE,
    FLAME
}