using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVariable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateToolTip()
    {
        //GameObject obj = GameObject.Find("Roof");
        string objname = gameObject.GetComponent<BimData>().objectName;
		if (gameObject.GetComponent<BimData>().isDelayed){
			objname = objname+" (DELAYED!)";
		}
        string manager = gameObject.GetComponent<BimData>().projectManager;
		string currentProgress = gameObject.GetComponent<BimData>().currentProgress.ToString();
		string expense = gameObject.GetComponent<BimData>().actualExpense.ToString();
		string text = objname+"\n"+"Progress: "+currentProgress+"% "+"Expense: CHF"+expense+"\n"+"Manager: "+manager;
		

		gameObject.GetComponentInChildren<ToolTip>(true).ToolTipText = text;
    }
}
