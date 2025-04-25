using UnityEngine;

public class manager : MonoBehaviour
{
    private body sun_body;
    private body body1;
    public GameObject sun;
    public GameObject planet_1;


    public float g;
    public float f;
    public float r;

    private void Start()
    {
        sun_body = sun.GetComponent<body>();
        body1 = planet_1.GetComponent<body>();
    }

    void Update()
    {
        r = Vector2.Distance(sun.transform.position, planet_1.transform.position);
        f = g * (sun_body.mass * body1.mass) / (r * r);
    }

}
