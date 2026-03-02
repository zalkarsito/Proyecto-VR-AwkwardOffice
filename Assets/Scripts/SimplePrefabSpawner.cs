using UnityEngine;

public class SimplePrefabSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject previewPrefab;
    private GameObject currentPreview;
    private void Start() => currentPreview = Instantiate(previewPrefab);

    void Update()
    {
        // Creamos un Raycast con origen en el mando derecho
        Ray ray = new
        Ray(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch),
        OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) *
        Vector3.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            currentPreview.transform.position = hitInfo.point;
            currentPreview.transform.rotation =
            Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Instantiate(prefab, hitInfo.point,
                Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
            }
        }
    }
}
