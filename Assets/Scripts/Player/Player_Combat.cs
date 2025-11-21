using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask enemyLayer;
    public int damage;

    public Animator anim;
    public float cooldown;

    private float timer;
    private bool isAttacking;
    private SpriteFlash spriteFlash;

    private void Awake()
    {
        spriteFlash = GetComponent<SpriteFlash>();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0 && isAttacking)
        {
            spriteFlash.Flash();
            isAttacking = false;
        }
    }

    public void Attack()
    {
        if(timer <= 0)
        { 
            anim.SetBool("isAttacking", true);

            timer = cooldown;
            isAttacking = true;
        }
        
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);
        
        if(enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-damage);
        }
    }

    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }
}
