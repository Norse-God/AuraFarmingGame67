using UnityEditor;
using UnityEngine;

public class Second_camera_script : MonoBehaviour
{
    public Transform target;
    public float distance = 0f;
    public float height = 0;
    public float rotateSpeed = 120f;
    public GameObject player_model1;
    public GameObject player_model2;

    private float angle;
    private float yRotation = 0f;

    void Start()
    {
        yRotation = target.eulerAngles.y;
    }


    void LateUpdate()
    {
        player_model1.GetComponent<SkinnedMeshRenderer>().enabled = true;
        player_model2.GetComponent<SkinnedMeshRenderer>().enabled = true;

        if (target == null) return;

        angle += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;

        Vector3 offset = Quaternion.Euler(0f, angle, 0f) * new Vector3(0f, height, -distance);
        transform.position = target.position;
        transform.position += offset;
        transform.LookAt(target.position);
    }

}
