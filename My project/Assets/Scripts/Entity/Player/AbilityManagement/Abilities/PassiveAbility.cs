using UnityEngine;

public abstract class PassiveAbility : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int id{get;}

    protected abstract void ActivatePassiveAbility();

    public void Activate()
    {
        ActivatePassiveAbility();
    }
    protected abstract void DeactivatePassiveAbility();

    public void Deactivate()
    {
        DeactivatePassiveAbility();
    }
        
    
}
