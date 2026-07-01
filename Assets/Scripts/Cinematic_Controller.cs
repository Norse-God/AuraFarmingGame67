using UnityEngine;
using Unity.Cinemachine;

public class Cinematic_Controller : MonoBehaviour
{
    public CinemachineCamera dollyCamera;

    public CinemachineSplineDolly dolly;

    public CinemachineCamera gameplayCamera;

    public float flightDuration = 12f;

    public KeyCode skipKey = KeyCode.Space;


    public int activePriority = 20;
    public int idlePriority = 0;

    private float elapsed;

    private bool cutsceneEnded;

    private void Start()
    {
        dollyCamera.Priority = activePriority;
        gameplayCamera.Priority = idlePriority;

        dolly.CameraPosition = 0f;

        dolly.AutomaticDolly.Enabled = false;
    }

    private void Update()
    {
        if (cutsceneEnded)
            return;

        if (Input.GetKeyDown(skipKey))
        {
            EndCutscene();
            return;
        }


        elapsed += Time.deltaTime;

        float t = Mathf.Clamp01(elapsed / flightDuration);
        dolly.CameraPosition = t;

        if (t >= 1f)
            EndCutscene();
    }

    private void EndCutscene()
    {
        if (cutsceneEnded)
            return;
        cutsceneEnded = true;


        dollyCamera.Priority = idlePriority;
        gameplayCamera.Priority = activePriority;

        Debug.Log("Пролёт по сплайну завершён");
    }

}
