using UnityEngine;

public class EnemyStats : CharacterStats 
{
    public override void Die()
    {
        base.Die();

        // TODO Add ragdoll effect / death animation

        Destroy(gameObject);
    }
}
