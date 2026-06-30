using Unity.VisualScripting;
using UnityEngine;

public class person_Camera : MonoBehaviour
{
    public GameObject player_model1;
    public GameObject player_model2;
    public Transform tr;
    public float mousesensitivity = 120f;
    public GameObject menu;


    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yRotation = tr.eulerAngles.y;
        player_model1.GetComponent<SkinnedMeshRenderer>().enabled = true;
        player_model2.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }

    public void Update()
    {
        if (menu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            Cursor.lockState = CursorLockMode.Locked;
        }
        player_model1.GetComponent<SkinnedMeshRenderer>().enabled = false;
        player_model2.GetComponent<SkinnedMeshRenderer>().enabled = false;

        float mouseX = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        transform.position = tr.position + Vector3.up * 1.7f;
        
    }


}
