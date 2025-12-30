using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float turnSpeed = 15.0f;
    public float speed = 1.0f;


    private MeshRenderer _renderer;

    private float turnSpeedX;
    private float turnSpeedY;

    private Material _material;
    private float alpha = 1f;
    private float alphaAhead;

    private bool decreasing = false;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();

        _material = _renderer.material; // Get the material instance (lazy) - avoid modifying the shared material

        StartCoroutine(RandomTurnValueX());
        StartCoroutine(RandomTurnValueY());
        StartCoroutine(ConstantOpacityRise());

        alphaAhead = alpha;
    }

    void Update()
    {
        transform.Rotate(turnSpeed * Time.deltaTime, turnSpeedX * Time.deltaTime, turnSpeedY * Time.deltaTime);

        float t = Mathf.Repeat(Time.time * speed, 1f);
        //_material.color = Color.Lerp(startColor, endColor, t);
        Color color = Color.HSVToRGB(t, 1f, 1f);
        color.a = alpha;
        _material.color = color;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            alphaAhead = Mathf.Max(alphaAhead - 0.2f, 0f);
            //float target = Mathf.Max(alpha - 0.2f, 0f);
            StartCoroutine(OpacityDrop(alphaAhead));
        }
    }

    IEnumerator RandomTurnValueX()
    {
        while (true)
        {
            turnSpeedX = Random.Range(-10.0f, 10.0f);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    IEnumerator RandomTurnValueY()
    {
        while (true)
        {
            turnSpeedY = Random.Range(-10.0f, 10.0f);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    IEnumerator OpacityDrop(float target)
    {
        while (decreasing)
        {
            yield return null;
        }

        decreasing = true;

        while (alpha > target)
        {
            alpha -= Time.deltaTime * 0.5f;
            yield return null;
        }
        alpha = target;

        decreasing = false;
    }

    IEnumerator ConstantOpacityRise()
    {
        while (true)
        {
            if (!decreasing)
            {
                //alpha += Time.deltaTime * 0.1f; - alternative approach
                //alpha = Mathf.Min(alpha, 1f);
                alpha = Mathf.MoveTowards(alpha, 1, Time.deltaTime * 0.1f);
                alphaAhead = alpha;
            }
            yield return null;
        }
    }
}