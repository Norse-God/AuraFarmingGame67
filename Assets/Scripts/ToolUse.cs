using UnityEngine;

public class ToolUse : MonoBehaviour
{
    public GameObject axe;
    public GameObject pickaxe;
    private bool IsActiveAxe;
    private bool IsActivePickaxe;

    private void Start()
    {
        IsActiveAxe = false;
        IsActivePickaxe = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (IsActiveAxe)
            {
                axe.SetActive(!IsActiveAxe);
                IsActiveAxe = !IsActiveAxe;
            }
            else 
            {
                axe.SetActive(!IsActiveAxe);
                IsActiveAxe = !IsActiveAxe;
                pickaxe.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (IsActivePickaxe)
            {
                pickaxe.SetActive(!IsActivePickaxe);
                IsActivePickaxe = !IsActivePickaxe;
            }
            else
            {
                pickaxe.SetActive(!IsActivePickaxe);
                IsActivePickaxe = !IsActivePickaxe;
                axe.SetActive(false);
            }
        }
    }



}

