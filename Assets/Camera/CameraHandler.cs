using Cinemachine;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField]
    private CinemachineVirtualCamera followCam;
    [SerializeField]
    private CinemachineVirtualCamera worldCam;
    private Animator animator;
    private Quaternion defaultCamRotation;
    private GameObject player;
    private bool isFocused = false;
    [Header("Atributos")]
    [SerializeField]
    private float panSpeed = 20f;
    [SerializeField]
    private float zoomSpeed = 100f;
    [SerializeField]
    private float zoomInMax = 40f;
    [SerializeField]
    private float zoomOutMax = 100f;

    private void Awake() {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        defaultCamRotation = worldCam.transform.rotation;        
    }

    void Update()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        PanScreen(x,y);
       
        if (Input.mouseScrollDelta.y != 0 || isFocused)
        {
            ZoomScreen(Input.mouseScrollDelta.y);
        }
        if (Input.GetKey(KeyCode.F1))
        {
            CameraFocus(player);
            isFocused = true;
            Switchcam();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            isFocused = false;
            Switchcam();
        }
    }

    private void Switchcam(){
        if(isFocused){
            animator.Play("Follow Camera");
        }else
        {
            animator.Play("World Camera");
        }
    }
     public void CameraFocus(GameObject go){
        followCam.m_LookAt = go.transform;
        followCam.m_Follow = go.transform;
    }
    public void PanScreen(float x, float y){
        if (!isFocused)
        {
            Vector3 direction = PanDirection(x,y);
            this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + direction, Time.deltaTime * panSpeed);
        }
    }
    public Vector3 PanDirection(float x, float y){
        Vector3 direction = Vector3.zero;
        if(y >= Screen.height * .95f){
            direction.z += 1;
        }
        if(y <= Screen.height * 0.05f){
            direction.z -= 1;
        }
        if(x >= Screen.width * .95f){
            direction.x += 1;
        }
        if(x <= Screen.width * 0.05f){
            direction.x -= 1;
        }
        return direction;
    }
    public void ZoomScreen(float increment){
        float fov = worldCam.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov + (increment* -1), zoomInMax, zoomOutMax);
        worldCam.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomSpeed * Time.deltaTime);
    }
}
