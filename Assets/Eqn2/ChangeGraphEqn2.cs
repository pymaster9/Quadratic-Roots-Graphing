using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeGraphEqn2 : MonoBehaviour
{
    public GameObject prefab;
    public TMP_InputField aval;
    public TMP_InputField hval;
    public TMP_InputField kval;
    public Toggle achange;
    public Toggle hchange;
    public Toggle kchange;
    public void Graph()
    {
        DrawEqn2.main.Clear();
        GameObject curr = Instantiate(prefab);
        curr.GetComponent<DrawEqn2>().a = int.Parse(aval.text);
        curr.GetComponent<DrawEqn2>().h = int.Parse(hval.text);
        curr.GetComponent<DrawEqn2>().k = int.Parse(kval.text);
        if(achange.isOn)
        {
            curr.GetComponent<DrawEqn2>().variableChanged = 'a';
        }
        else if (hchange.isOn)
        {
            curr.GetComponent<DrawEqn2>().variableChanged = 'h';
        }
        else if (kchange.isOn)
        {
            curr.GetComponent<DrawEqn2>().variableChanged = 'k';
        }
    }
}
