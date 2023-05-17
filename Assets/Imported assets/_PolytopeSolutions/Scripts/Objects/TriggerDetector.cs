#define DEBUG
//#undef DEBUG
//#define DEBUG2
#undef DEBUG2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PolytopeSolutions.Pbjects {
    [RequireComponent(typeof(Collider))]
    public class TriggerDetector : MonoBehaviour {
        [SerializeField] private List<string> tagsToDetect = new List<string>();
        [SerializeField] private UnityEvent onValidCollisionEnter;
        [SerializeField] private UnityEvent onValidCollisionStay;
        [SerializeField] private UnityEvent onValidCollisionExit;
        private bool secondAnimationTriggered = false;
        public float threashold = 30f;

        private void Start() {
            for (int i = 0; i < this.tagsToDetect.Count; i++) {
                this.tagsToDetect[i] = this.tagsToDetect[i].ToLower();
            }
        }

        private void OnTriggerEnter(Collider other)  {
            if (this.tagsToDetect.Contains(other.tag.ToLower())) {
                #if DEBUG
                Debug.Log("Trigger detector ["+gameObject.name+"]: Object entered with valid tag: " + other.tag);
                #endif
                if (this.onValidCollisionEnter != null) 
                    this.onValidCollisionEnter.Invoke();
            }
        }
        private void OnTriggerStay(Collider other)  {
            if (this.tagsToDetect.Contains(other.tag.ToLower())) {
                #if DEBUG
                Debug.Log("Trigger detector ["+gameObject.name+"]: Object stayed with valid tag: " + other.tag);
                #endif
                float angle = Mathf.Abs(180f - Vector3.Angle(Vector3.up, other.gameObject.transform.forward));
                #if DEBUG
                Debug.Log("Trigger detector ["+gameObject.name+"]: Angle measured: " + angle);
                #endif
                if (this.onValidCollisionStay != null && angle > threashold && !secondAnimationTriggered) { 
                    this.onValidCollisionStay.Invoke();
                    secondAnimationTriggered = true;
                }
            }
        }
        private void OnTriggerExit(Collider other)  {
            if (this.tagsToDetect.Contains(other.tag.ToLower())) {
                #if DEBUG
                Debug.Log("Trigger detector ["+gameObject.name+"]: Object exited with valid tag: " + other.tag);
                #endif
                secondAnimationTriggered = false;
                if (this.onValidCollisionExit != null) 
                    this.onValidCollisionExit.Invoke();
            }
        }
    }
}