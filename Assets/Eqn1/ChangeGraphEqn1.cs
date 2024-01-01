using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeGraphEqn1 : MonoBehaviour
{
    public GameObject prefab;
    public TMP_InputField aval;
    public TMP_InputField bval;
    public TMP_InputField cval;
    public Toggle achange;
    public Toggle bchange;
    public Toggle cchange;
    public void Graph()
    {
        DrawEqn1.main.Clear();
        GameObject curr = Instantiate(prefab);
        curr.GetComponent<DrawEqn1>().a = int.Parse(aval.text);
        curr.GetComponent<DrawEqn1>().b = int.Parse(bval.text);
        curr.GetComponent<DrawEqn1>().c = int.Parse(cval.text);
        if(achange.isOn)
        {
            curr.GetComponent<DrawEqn1>().variableChanged = 'a';
        }
        else if (bchange.isOn)
        {
            curr.GetComponent<DrawEqn1>().variableChanged = 'b';
        }
        else if (cchange.isOn)
        {
            curr.GetComponent<DrawEqn1>().variableChanged = 'c';
        }
    }
}
