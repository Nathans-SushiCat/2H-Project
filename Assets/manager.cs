using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class manager : MonoBehaviour
{
    [SerializeField] Material[] materials;
    [SerializeField] GameObject cube;
    GameObject lastplacedCube = null;
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] GameObject Circle;
    float randomOffset;
    public int currentcolor = 0;
    int speed;
    private void Start()
    {
        speed = int.Parse(File.ReadAllText(Application.persistentDataPath + "//Settings" + "Settings.text"));
    }
    void Update()
    {
        if (lastplacedCube == null || lastplacedCube.transform.position.x <= 10-randomOffset)
        {
            if(Random.Range(0,100) > 5)
            {
                lastplacedCube = Instantiate(cube, new Vector2(12.5f, 0), Quaternion.identity);
                randomOffset = Random.Range(0f, 6f);
            }
            else
            {
                lastplacedCube = Instantiate(Circle, new Vector2(12.5f, 0), Quaternion.identity);
                randomOffset = Random.Range(0f, 6f);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
            bool[] hits = new bool[cubes.Length];
            for(int i = 0; i < cubes.Length-1; i++)
            {
                hits[i] = cubes[i].GetComponent<Cube>().PressedSpace(currentcolor);
            }
            if (!hits.Contains(true))
            {
                AddScore(-1);
            }
        }

    }
    public void SetNewColor(int col)
    {
        currentcolor = col;
        gameObject.GetComponent<Renderer>().material = materials[col];
    }
    public void AddScore(int value)
    {
        score += value;
        scoreTxt.text = "" + score;
    }
    public int getSpeed()
    {
        return speed;
    }
}
