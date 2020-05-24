using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{

 public Transform[] views;
 public float transitionSpeed; 
 Transform currentView;

 public void Start(){
     currentView = views[0];
 }

 public void cambiarCamaraInst(){
     currentView = views [1];
 }

 public void cambiarCamaraMenu(){
     currentView = views [0];
 }
 

 void LateUpdate () {

  //Lerp position
  transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

  Vector3 currentAngle = new Vector3 (
   Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
   Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
   Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

  transform.eulerAngles = currentAngle;

 }
}
