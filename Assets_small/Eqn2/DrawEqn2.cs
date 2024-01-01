 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawEqn2 : MonoBehaviour
{
    int scale = 10;
    public float a;
    public float h;
    public float k;
    public float currentvariable;
    public GameObject pref;
    public char variableChanged;
    public float resolution;
    List<GameObject> points;
    public static DrawEqn2 main;
    public List<Color> materials;
    public int pointsPerFrame;
    // Start is called before the first frame update
    void Start()
    {
        main = this;
        points = new List<GameObject>();
    }

    void PlotRoot(int sign)
    {
        try
        {
            float b = -2 * a * h;
            float c = (a * h * h) + k;
            float real = 0, complex = 0;
            float discriminant = (b * b) - 4 * a * c;
            if (discriminant >= 0)
            {
                real = (-b + (sign * Mathf.Sqrt(discriminant))) / (2 * a);

            }
            else
            {
                real = (-b / 2 * a);
                complex = (sign * Mathf.Sqrt(-discriminant)) / (2 * a);
            }
            float x = currentvariable * 10;
            float y = real * 10;
            float z = complex * 10;

            GameObject curr = Instantiate(pref, new Vector3(x, y, z), Quaternion.Euler(Vector3.zero));
            curr.name = sign.ToString();
            curr.GetComponent<Renderer>().material.color = materials[Mathf.RoundToInt(((float)sign / 2) + 0.5f)];
            points.Add(curr);
        }
        catch
        {

        }
    }

    void RunOneFrame()
    {
        float real;
        float complex = 0;
        if (variableChanged == 'a')
        {
            a = currentvariable;
        }
        else if (variableChanged == 'h')
        {
            h = currentvariable;
        }
        else if (variableChanged == 'k')
        {
            k = currentvariable;
        }
        PlotRoot(1);
        PlotRoot(-1);

        currentvariable = -currentvariable;
        if (variableChanged == 'a')
        {
            a = currentvariable;
        }
        else if (variableChanged == 'h')
        {
            h = currentvariable;
        }
        else if (variableChanged == 'k')
        {
            k = currentvariable;
        }
        PlotRoot(1);
        PlotRoot(-1);

        currentvariable = -currentvariable;
        currentvariable += resolution;
    }

    void FixedUpdate()
    {
        for(int x = 0; x < pointsPerFrame; x++)
        {
            try
            {
                RunOneFrame();
            }
            catch
            {

            }
        }
    }

    public void Clear()
    {
        foreach(GameObject curr in points)
        {
            Destroy(curr);
        }
        Destroy(gameObject);
    }
    int Sign(float num)
    {
        if(num == 0) { return 0; }
        else if(num < 0) { return -1; }
        else { return 1; }
    }
}
