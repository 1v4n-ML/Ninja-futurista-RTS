using Cinemachine;
using UnityEngine;

public class PanAndZoom : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    
    
    [SerializeField]
    private bool isFocused = true;

    [SerializeField]
    private float panSpeed = 20f;
    [SerializeField]
    private float zoomSpeed = 100f;
    [SerializeField]
    private float zoomInMax = 40f;
    [SerializeField]
    private float zoomOutMax = 100f;

    private void Awake() {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
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
    }

    public void PanScreen(float x, float y){
        if (isFocused)
        {
            Vector3 direction = PanDirection(x,y);
            this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + direction, Time.deltaTime * panSpeed);
        }
    }
    public void ZoomScreen(float increment){
        float fov = virtualCamera.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov + increment, zoomInMax, zoomOutMax);
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomSpeed * Time.deltaTime);
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
   
}
