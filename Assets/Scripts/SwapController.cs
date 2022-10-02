using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraBlendInitializer))]
public class SwapController : MonoBehaviour
{
    [SerializeField] public Camera lightCam;
    [SerializeField] public Camera darkCam;
    [SerializeField] public CamControl lightCamControl;
    [SerializeField] public CamControl darkCamControl;



    private CameraBlendInitializer cbi;
    private GameObject player;

    private float timer;

    private bool dark;
    public bool Dark { get => dark; }

    static SwapController gi;
    // Lets do a Quick and Dirty Singleton here.
    public static SwapController GI
    {
        get => gi;
    }
    private void Awake()
    {
        gi = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.realtimeSinceStartup;
        cbi = GetComponent<CameraBlendInitializer>();
        player = GameObject.FindGameObjectWithTag("Player");
        dark = false;
        Apply();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > timer + 10f)
        {
            timer = Time.realtimeSinceStartup;
            Swap();
        }
    }

    public void Swap()
    {
        dark = !dark;
        cbi.Swap(dark);
        Apply();
    }

    void Apply()
    {
        SwapObject(player, dark);
        lightCam.enabled = !dark;
        darkCam.enabled = dark;
        lightCamControl.Slave = dark;
        darkCamControl.Slave = !dark;
    }

    public void SwapObject(GameObject obj, bool dark)
    {
        // Local position stays the same!
        Vector2 position = obj.transform.localPosition;
        Transform newParent = dark ? darkCamControl.transform.parent : lightCamControl.transform.parent;
        obj.transform.SetParent(newParent);
        obj.transform.localPosition = position;
    }
}
