using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    public Transform Mario;

    public Vector2 maxXAndY;
    public Vector2 minXAndY;

    public float xMargin = 1f;
    public float yMargin = 1f;
    public float xSmooth = 8f;
    public float ySmooth = 8f;

    public float Over_X = -100f;

    void Awake()
    {
        Mario = GameObject.FindGameObjectWithTag("Mario").transform;
    }

    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - Mario.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - Mario.position.y) > yMargin;
    }

    void FixedUpdate()
    {
        if (Mario.position.x >= -15.614)
            TrackMario();
    }

    void TrackMario()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, Mario.position.x, xSmooth * Time.deltaTime);
        }

        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, Mario.position.y, ySmooth * Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        if (Over_X < targetX)
        {
            Over_X = targetX;
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }

    void Update()
    {
        Mario = GameObject.FindGameObjectWithTag("Mario").transform;
    }
}
