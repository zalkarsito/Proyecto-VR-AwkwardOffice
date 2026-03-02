using UnityEngine;

public class shootBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public float speed = 5;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            GameObject ball = Instantiate(prefab, transform.position, Quaternion.identity);
            Rigidbody ballRG = ball.GetComponent<Rigidbody>();
            ballRG.linearVelocity = transform.forward * speed;
        }

    }
}