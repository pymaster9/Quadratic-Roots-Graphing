using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeGraphEqn3 : MonoBehaviour
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
        DrawEqn3.main.Clear();
        GameObject curr = Instantiate(prefab);
        curr.GetComponent<DrawEqn3>().a = int.Parse(aval.text);
        curr.GetComponent<DrawEqn3>().h = int.Parse(hval.text);
        curr.GetComponent<DrawEqn3>().k = int.Parse(kval.text);
        if(achange.isOn)
        {
            curr.GetComponent<DrawEqn3>().variableChanged = 'a';
        }
        else if (hchange.isOn)
        {
            curr.GetComponent<DrawEqn3>().variableChanged = 'h';
        }
        else if (kchange.isOn)
        {
            curr.GetComponent<DrawEqn3>().variableChanged = 'k';
        }
    }
}
