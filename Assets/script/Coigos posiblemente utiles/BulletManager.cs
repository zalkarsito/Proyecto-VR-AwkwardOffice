using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameController gameController;
    void Start()
    {
        gameController = Object.FindFirstObjectByType<GameController>();
    }
    void OnCollisionEnter(Collision obj)
    {
        Debug.Log("Derribado");
        gameController.TargetHit(obj.gameObject);
        if (obj.gameObject.CompareTag("Cans"))
        {
            Destroy(gameObject);
        }
        
    }
}