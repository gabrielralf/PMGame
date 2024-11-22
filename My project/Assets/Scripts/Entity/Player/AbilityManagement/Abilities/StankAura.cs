using UnityEngine;

public class StankAura : PassiveAbility
{
    [SerializeField] private CircleCollider2D col;
    [SerializeField] private float damagePerSecond;
    [SerializeField] private float cooldown;
    [SerializeField] private float lifeTime; 
    private List<Enemy> enemiesHit;
    private Coroutine cooldownCoroutine;

    protected override void ActivatePassiveAbility()
    {
        col.gameObject.SetActive(true);
        cooldownCoroutine = StartCoroutine(Cooldown());
    }
    protected override void DeactivatePassiveAbility()
    {
        StopCoroutine(cooldownCoroutine);
        col.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the collider belongs to an enemy
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy) && 
            !enemiesHit.Contains(enemy))
        {   
            enemiesHit.Add(enemy);
            
            // Get the enemy component (assuming the enemy has a script with a TakeDamage method)
            enemy.hp = enemy.hp - damagePerSecond * Time.deltaTime;
            
        }
    }
    private IEnumerator Cooldown()
    {  
         while(true){
            float cd;
           
            cd = ?col.gameObject.activeSelf : lifeTime : cooldown;
            if(cd == cooldown) enemiesHit.Clear();
            
            yield return new WaitForSeconds(cd);
            col.gameObject.SetActive(!col.gameObject.activeSelf);
            
        }
    }
}
