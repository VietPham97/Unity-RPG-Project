using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour 
{
    public float attackSpeed = 1f;
    float attackCooldown;

    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack (CharacterStats targetStats)
    {
        if (attackCooldown <= 0)
        {
			targetStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;  // Reset the attackCooldown, the greater the attackSpeed, the smaller the attackCooldown
        }
    }
}
