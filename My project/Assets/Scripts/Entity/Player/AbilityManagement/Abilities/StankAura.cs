using UnityEngine;

public class StankAura : PassiveAbility
{
    [SerializeField] private CircleCollider2D col;
    
    protected override void ActivatePassiveAbility()
    {
        col.gameObject.SetActive(true);
    }   
}
