using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour
{
    public string meleeButton;
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPosition;
    public float attackRange;
    public float attackPower;

    // Start is called before the first frame update
    void Start()
    {
        // Set my input button if not set by designer.
        if (meleeButton == null)
            meleeButton = transform.GetComponentInParent<PlayerInput>().playerMelee;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenAttack <= 0.0f)
        {
            // Attack.
            if(Input.GetKeyDown(meleeButton))
            {
                // Gather all the enemies within melee attack range.
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange);
                // Go through each and damage them.
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    // Check that I'm not attacking myself.
                    if(enemiesToDamage[i].transform != this.transform)
                        // Damage the enemy's health.
                        enemiesToDamage[i].GetComponent<PlayerHealth>().DamageHealth(attackPower);
                }
            }
            // Reset the timer.
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
