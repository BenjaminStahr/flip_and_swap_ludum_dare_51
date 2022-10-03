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
    [SerializeField] public Animator timerAnim;


    private CameraBlendInitializer cbi;
    private GameObject player;

    private float timer;

    public bool dark;
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
            Swap();
        }
    }

    public void Swap()
    {
        timer = Time.realtimeSinceStartup;
        dark = !dark;
        cbi.Swap(dark);
        Apply();
    }

    void Apply()
    {
        timerAnim.SetTrigger(dark ? "red" : "blue");
        SwapPlayer(dark);
        lightCam.enabled = !dark;
        darkCam.enabled = dark;
        lightCamControl.Slave = dark;
        darkCamControl.Slave = !dark;
    }

    public void SwapPlayer(bool dark)
    {
        // Local position stays the same!
        Vector2 position = player.transform.localPosition;
        Transform newParent = dark ? darkCamControl.transform.parent : lightCamControl.transform.parent;
        player.transform.SetParent(newParent);
        player.transform.localPosition = position;
    }

    public GameObject FindCorresponding(GameObject levelObject)
    {
        int index = levelObject.transform.GetSiblingIndex();
        GameObject fromlevel = levelObject.transform.parent.gameObject;
        GameObject tolevel;
        if (fromlevel == CurrentLevel.Dark)
        {
            tolevel = CurrentLevel.Light;
        }
        else
        {
            tolevel = CurrentLevel.Dark;
        }
        return tolevel.transform.GetChild(index).gameObject;
    }

    public void SwapLevelObject(GameObject obj)
    {
        GameObject shadow = FindCorresponding(obj);
        Transform oldParent = obj.transform.parent;
        Transform newParent = shadow.transform.parent;
        Vector2 oldp = obj.transform.position;
        Vector2 newp = shadow.transform.position;
        obj.transform.SetParent(newParent);
        shadow.transform.SetParent(oldParent);
        if (obj.CompareTag("Quibble")) 
        {
            //shadow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
           // obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            //newp += new Vector2(0, 1.5f);
            //oldp += new Vector2(0, 1.5f);

        }
        obj.transform.position = newp;
        shadow.transform.position = oldp;
    }

}
