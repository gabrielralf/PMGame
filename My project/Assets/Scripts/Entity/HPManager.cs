using UnityEngine;

public class HPManager
{
    private int hp;
    private int hp_max;
    private bool dead;
    private GameObject entity;
    public delegate void Died(GameObject died_entity);
    public event Died EntityDied;

    public int Hp{
        get => hp;
        set { 
            if (value > hp_max){
                hp = hp_max;
            }

            else if (value <= 0){
                hp = 0;
                dead = true;
                EntityDied?.Invoke(entity);
            }
        }
    }

    public HPManager(int hp_max, GameObject entity) {
        this.hp_max = hp_max;
        this.entity = entity;
        Hp = hp_max;
    }

    public int GetHpMax() => hp_max;

    public void SetHpMax(int hp_max_new) {hp_max = hp_max_new;}
}
