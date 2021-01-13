using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
	private Material[] originalMaterials;
	private Color[] originalColors;
	private Color newColor;
	private bool isOriginal_cur = true; // control show progress
	private bool isOriginal_del = true; // control show delay
	private bool isOriginal_ovr = true; // control show ovespend
	
	private float currentProgress;
	private bool isDelayed;
	private bool isOver;

    // Start is called before the first frame update
    void Start()
    {
		originalMaterials = gameObject.GetComponent<Renderer>().materials;
		originalColors = new Color[originalMaterials.Length];
		for (var i = 0; i < originalMaterials.Length; i++) {
			originalColors[i] = originalMaterials[i].color;
		}
		// get object attribute
		currentProgress = gameObject.GetComponent<BimData>().currentProgress;
		isDelayed = gameObject.GetComponent<BimData>().isDelayed;
		if (gameObject.GetComponent<BimData>().actualExpense - gameObject.GetComponent<BimData>().budget>0){
			isOver = true;
		}
		else{
			isOver = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	// show currentProgress
    public void updateColor()
    {		
		 if (isOriginal_cur){
			 // at first change color back (in case other show function is in active)
			 for (var i = 0; i < originalMaterials.Length; i++) {
				gameObject.GetComponent<Renderer>().materials[i].color = originalColors[i];
			}
			isOriginal_del = true;
			isOriginal_ovr = true;
			 // update color based on currentProgress
			// newColor = new Color(255/255f, 255/255f, 255/255f); // if 0< currentprogress < 20
			newColor = Color.white;
			if (currentProgress == 100 ){
				newColor = new Color(4/255f, 40/255f, 47/255f);
				// newColor = Color.white;
			}
			else if (currentProgress >= 80 && currentProgress<=99 ){
				newColor = new Color(0/255f, 59/255f, 70/255f);
				// newColor = Color.blue;
			}
			else if (currentProgress >= 60 && currentProgress<=79 ){
				newColor = new Color(7/255f, 87/255f, 91/255f);
				// newColor = Color.yellow;
			}
			else if (currentProgress >= 40 && currentProgress<=59 ){
				newColor = new Color(102/255f, 165/255f, 173/255f);
				//newColor = Color.green;
			}
			else if (currentProgress >= 20 && currentProgress<=39 ){
				newColor = new Color(196/255f, 223/255f, 230/255f);
				// newColor = Color.cyan;
			}
			// use original color for 'not start' construction part
			if (currentProgress != 0){
				for (var i = 0; i < originalMaterials.Length; i++) {
				gameObject.GetComponent<Renderer>().materials[i].color = newColor;
			}
			 isOriginal_cur = false;
			}
			
		 }
		 else{
			for (var i = 0; i < originalMaterials.Length; i++) {
				gameObject.GetComponent<Renderer>().materials[i].color = originalColors[i];
			}
			 isOriginal_cur = true;
		 }
    }
	// show delayed status
	public void showDelay()
    {		
		 if (isOriginal_del){
			 // at first change color back (in case other show function is in active)
			 for (var i = 0; i < originalMaterials.Length; i++) {
				gameObject.GetComponent<Renderer>().materials[i].color = originalColors[i];
			}
			isOriginal_cur = true;
			isOriginal_ovr = true;
			 // update color based on currentProgress
			if (isDelayed){
				for (var i = 0; i < originalMaterials.Length; i++) {
				gameObject.GetComponent<Renderer>().materials[i].color = Color.red;
			}
			 isOriginal_del = false;
			}
			
		 }
		 else{
			for (var i = 0; i < originalMaterials.Length; i++) {
				gameObject.GetComponent<Renderer>().materials[i].color = originalColors[i];
			}
			 isOriginal_del = true;
		 }
    }
	// show delayed status
	public void showOverspend()
    {		
		 if (isOriginal_ovr){
			 // at first change color back (in case other show function is in active)
			 for (var i = 0; i < originalMaterials.Length; i++) {
				gameObject.GetComponent<Renderer>().materials[i].color = originalColors[i];
			}
			isOriginal_cur = true;
			isOriginal_del = true;
			 // update color based on currentProgress
			if (isOver){
				for (var i = 0; i < originalMaterials.Length; i++) {
				gameObject.GetComponent<Renderer>().materials[i].color = Color.red;
			}
			 isOriginal_ovr = false;
			}
			
		 }
		 else{
			for (var i = 0; i < originalMaterials.Length; i++) {
				gameObject.GetComponent<Renderer>().materials[i].color = originalColors[i];
			}
			 isOriginal_ovr = true;
		 }
    }
}
