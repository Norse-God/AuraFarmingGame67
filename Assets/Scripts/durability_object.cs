using UnityEngine;

public class durability_object : MonoBehaviour
{

    private float max_durability = 100;
    private float current_durability;

    void Start()
    {
        current_durability = max_durability;
    }

    public void TakeDamage(float damage)
    {
        current_durability -= damage;
        if (current_durability <= 0)
        {
            Break();
        }

    }


    
    private void Break()
    {
        Destroy(gameObject);
    }
}
