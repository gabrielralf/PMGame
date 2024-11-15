using UnityEngine;

public class Move
{
    private float speed;

    private GameObject entity;

    private CharacterController characterCtrl;

    public Move(GameObject entity, float speed){
        this.entity = entity;
        this.speed = speed;
        characterCtrl = entity.GetComponent<CharacterController>();
    }

    public void MoveEntity(Vector2 direction){
        characterCtrl.Move(direction * speed * Time.deltaTime);
    }
}
