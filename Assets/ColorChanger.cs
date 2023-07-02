using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Material[] materials;
    int color;
    GameObject Line;
    private void Start()
    {
        Line = GameObject.Find("Line");
        color = Random.Range(0, materials.Length);
        gameObject.GetComponent<Renderer>().material = materials[color];
    }
    void Update()
    {
        transform.Translate(new Vector2(-22, 0) * Time.deltaTime);

        if (transform.position.x < Line.transform.position.x)
        {
            Line.GetComponent<manager>().SetNewColor(color);
            Destroy(gameObject);
        }
    }
}
