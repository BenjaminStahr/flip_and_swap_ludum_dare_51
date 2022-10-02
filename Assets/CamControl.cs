using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CamControl : MonoBehaviour
{
    public float moveSpeed = 1;
    private GameObject following;
    private Rigidbody2D physics;

    float targetViewDistance;

    bool slave;
    
    [SerializeField]
    private CamControl other;

    public bool Slave { get => slave; set => slave = value; }


    private void Awake()
    {
        following = GameObject.FindGameObjectWithTag("Player");
        targetViewDistance = -transform.position.z;
    }

    // Start is called before the first frame update
    private void Start()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Slave)
        {
            // Local positions should be same!
            transform.localPosition = other.transform.localPosition;
            return;
        }

        if (following != null)
        {
            Vector3 fp = following.transform.position;
            if (fp.y < -3.5f)
            {
                fp.y = -3.5f;
            }

            Vector2 delta = fp - transform.position;
            if (delta.magnitude > 30)
            {
                delta = delta.normalized * 30f;
            }
            physics.AddForce(moveSpeed * delta.sqrMagnitude * delta.normalized);
        }
        Vector3 p = transform.position;
        p.z += 0.05f * ((-targetViewDistance) - p.z);
        transform.position = p;
    }

    public void SetViewDistance(float targetDistance)
    {
        targetViewDistance = targetDistance;
    }
}