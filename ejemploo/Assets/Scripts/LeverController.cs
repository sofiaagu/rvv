using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class LeverController : MonoBehaviour
{
    public XRLever palanca;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        float speedMove = speed * (palanca.value ? 1 : 0);
        Vector3 velocity = new Vector3(0, 0, speedMove);
        transform.position += velocity * Time.deltaTime;
    }
}
