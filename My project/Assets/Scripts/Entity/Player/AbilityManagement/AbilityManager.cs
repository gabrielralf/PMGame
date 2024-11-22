using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<PassiveAbility> abilities; 
    [SerializeField] private Entity entity;
    private List<PassiveAbility> activePassiveAbilities = new List<PassiveAbility>();

    void Start()
    {
        entity.HPManager.EntityDied += OnPlayerDeath;
    }
    private void OnPlayerDeath( GameObject player){
        foreach(PassiveAbility activePassiveAbility in activePassiveAbilities)
        {
            activePassiveAbility.Deactivate();
        }
        activePassiveAbilities.Clear();
    }
    private void ActivatePassiveAbility(PassiveAbility passiveAbility){
        if(activePassiveAbilities.Contains(passiveAbility)) return;
        passiveAbility.Activate();
        activePassiveAbilities.Add(passiveAbility);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PassiveAbility>(out PassiveAbility passiveAbility))
        {
            ActivatePassiveAbility(passiveAbility);
        }
    }

    
}
