using Unity.VisualScripting;
using UnityEngine;

public class Player_Attaced : MonoBehaviour
{
    private float Damage = 25;
    public Transform point;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)){
            Hit_find();
        }
    }

    private void Hit_find()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f))
        {
            durability_object obj = hit.collider.GetComponent<durability_object>();

            if (obj != null)
            {
                obj.TakeDamage(Damage);
                Debug.DrawLine(point.position, hit.point, Color.green);
            }
        }

    }


}

 