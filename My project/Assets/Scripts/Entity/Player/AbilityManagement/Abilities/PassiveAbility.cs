using UnityEngine;

public abstract class PassiveAbility : MonoBehaviour
{
    [SerializeField] private int damage;

    protected abstract void ActivatePassiveAbility();

}
