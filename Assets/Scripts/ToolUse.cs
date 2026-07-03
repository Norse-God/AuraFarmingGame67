using UnityEngine;

public class ToolUse : MonoBehaviour
{
    public GameObject axe;
    public GameObject pickaxe;

    public GameObject player;

    private bool IsActiveAxe;
    private bool IsActivePickaxe;
    private Player_Attaced playerAttack;

    private void Start()
    {
        IsActiveAxe = false;
        IsActivePickaxe = false;

        axe.SetActive(false);
        pickaxe.SetActive(false);

        playerAttack = player.GetComponent<Player_Attaced>();
        playerAttack.enabled = false;
    }

    void Update()
    {
  
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsActiveAxe = !IsActiveAxe;
            IsActivePickaxe = false; 

            axe.SetActive(IsActiveAxe);
            pickaxe.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            IsActivePickaxe = !IsActivePickaxe;
            IsActiveAxe = false; 

            pickaxe.SetActive(IsActivePickaxe);
            axe.SetActive(false);
        }

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool canAttack = false;

        if (Physics.Raycast(ray, out hit, 3f))
        {
            GameObject lookedObject = hit.collider.gameObject;
            if (IsActiveAxe && lookedObject.CompareTag("Tree"))
            {
                canAttack = true;
            }
            else if (IsActivePickaxe && lookedObject.CompareTag("Cobblestone"))
            {
                canAttack = true;
            }
        }

        if (playerAttack.enabled != canAttack)
        {
            playerAttack.enabled = canAttack;
        }
    }
}



