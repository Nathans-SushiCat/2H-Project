using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cube : MonoBehaviour
{
    [SerializeField] Material[] materials;
    [SerializeField] int color;
    GameObject Line;
    bool pressable = false;
    float[] LineOffsetPos = {0f, 0f};
    int speed;
    // Start is called before the first frame update
    void Start()
    {
        Line = GameObject.Find("Line");
        speed = Line.GetComponent<manager>().getSpeed();
        color = Random.Range(0, materials.Length);
        gameObject.GetComponent<Renderer>().material = materials[color];
        LineOffsetPos[0] = Line.transform.position.x + (Line.transform.localScale.x / 2) + (transform.localScale.x / 2);
        LineOffsetPos[1] = Line.transform.position.x - (Line.transform.localScale.x / 2) - (transform.localScale.x / 2);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-speed,0)* Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Mainmenu");
        }

        if (transform.position.x < LineOffsetPos[0]) // Check if on Line
        {
            pressable = true;
            if (transform.position.x < LineOffsetPos[1])
            { //Behind the Line
                if(Line.GetComponent<manager>().currentcolor == color)
                {
                    Line.GetComponent<manager>().AddScore(-1);
                }
                Destroy(gameObject);
            }
        }
    }

    public bool PressedSpace(int material)
    {
        if (pressable && material == color)
        {
            Destroy(gameObject);
            Line.GetComponent<manager>().AddScore(1);
            return true;
        }
        else
        {
            return false;
        }
    }
}
