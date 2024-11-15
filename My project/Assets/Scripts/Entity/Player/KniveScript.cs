using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KniveScript : MonoBehaviour
{
    public Vector2 Dir;
    [SerializeField] private GameObject knive;
    [SerializeField] private int damage; 
    [SerializeField] private float lifeSpan;
    [SerializeField] private float speed;    
    private Move moveObject;
    private Coroutine throwRoutine;

    

    private void Start(){
        moveObject = new Move(knive, speed);

        throwRoutine = StartCoroutine("ThrowRoutine");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Ist das getroffene Object wirklich ein Gegner
        other.gameObject.TryGetComponent<Enemy>(out Enemy enemy);
        if (enemy != null){
            // Mache schaden
            //int enemyHp = enemy.HPManager.Hp;
            //enemyHp = enemyHp - damage;
            DestroyKnive();
        }
    }

    //führe über yield return befehle aus, sobald yield return, stoppe und warte solange bis das Messer verschwindet
    private IEnumerator ThrowRoutine(){
        while (true){
            moveObject.MoveEntity(Dir);
            yield return new WaitForSeconds(lifeSpan);

            //dann zerstöre Messer
            DestroyKnive();
        }
    }

    private void DestroyKnive(){
        StopCoroutine(throwRoutine);  
        GameObject.Destroy(knive);
    }
}

