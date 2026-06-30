using UnityEngine;

public class choose_camera : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public Transform tr;

    private bool choose = true;

    void Start()
    {
        transform.position = tr.position + Vector3.up * 1.7f;
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (choose)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
                choose = false;
            }
            else
            {
                cam2.SetActive(false);
                cam1.SetActive(true);
                choose = true;
            }

        }
    }
}
