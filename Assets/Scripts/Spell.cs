using UnityEngine;

public class Spell : MonoBehaviour
{
    private SpellData spellData;
    public float speed = 10f;
    private Vector3 moveDirection;

    public void Initialize(SpellData data, Vector3 direction)
    {
        spellData = data;
        moveDirection = direction;
        Destroy(gameObject, spellData.range / speed);
    }

    private void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Enemy"))
    //     {
    //         var enemyHealth = other.GetComponent<EnemyHealth>();
    //         if (enemyHealth != null)
    //         {
    //             enemyHealth.TakeDamage(spellData.damage);
    //         }
    //         Destroy(gameObject);
    //     }
    // }
}
