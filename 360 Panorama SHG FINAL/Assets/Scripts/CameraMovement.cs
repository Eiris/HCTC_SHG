using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour {

	void Awake() {
		#if !UNITY_EDITOR && UNITY_WEBGL
		WebGLInput.captureAllKeyboardInput = false;
		UnityEngine.Debug.Log("Not capturing all key input!! WEB GL!");
		#endif
	}

//	private float speed = 2.0f;
//	private float zoomSpeed = 2.0f;

	private float minFOV = 65;//1f was the original value used
	private float maxFOV = 90; 
	private float sensitivity = 10f;
	private float FOV = 90f;

//	public float minX = -360.0f;
//	public float maxX = 360.0f;
//	
	float minY = -90.0f; //-45.0f was the original value used
	float maxY = 90.0f; //45.0f was the original value used
//
	public float sensX = 100.0f;
	public float sensY = 100.0f;

//	public string myScene_next;
//	public string myScene_previous;

	
	private float rotationY = 0.0f;
	private float rotationX = 180.0f;
	Transform lookAtTarget;
	public bool lerping = false;
	public bool dragging = false;
	
	EventSystem eventSys;

	void Start () {
		this.reloadRotation();
		eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
	}

	void Update () {
		if(!Input.GetMouseButton(0)) {
			dragging = false;
		}

		// Debug.Log("Is over gameobject: " + eventSys.IsPointerOverGameObject());
		if(!eventSys.IsPointerOverGameObject() || dragging) {
			FOV += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
			FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
			Camera.main.fieldOfView = FOV;
//		float scroll = Input.GetAxis("Mouse ScrollWheel");
//		transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);
//		if (Input.GetKey(KeyCode.LeftArrow)){
//			transform.position += Vector3.right * speed * Time.deltaTime;
//		}
//		if (Input.GetKey(KeyCode.RightArrow)){
//			transform.position += Vector3.left * speed * Time.deltaTime;
//		}
//		if (Input.GetKey(KeyCode.DownArrow)){
//			transform.position += Vector3.forward * speed * Time.deltaTime;
//		}
//		if (Input.GetKey(KeyCode.UpArrow)){
//			transform.position += Vector3.back * speed * Time.deltaTime;
//		}
//		if (Input.GetKey(KeyCode.Escape)){
//			transform.position += Vector3.zero ;
//		}
//		if (Input.GetKey(KeyCode.LeftArrow)) {
//			SceneManager.LoadScene(myScene_previous);
//		}
//		if (Input.GetKey (KeyCode.RightArrow)) {
//			SceneManager.LoadScene (myScene_next);
//		}

			if (Input.GetMouseButton (0)) {
				this.dragging = true;
				this.lerping = false;
				rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
				rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
				rotationY = Mathf.Clamp (eulerTo360(rotationY), minY, maxY);
				transform.localEulerAngles = new Vector3 (-rotationY, rotationX, transform.localEulerAngles.z);
			} 
		}

		if (lerping) {
			this.smoothLookTowards();
		}
	}

	public void LookTowards(Transform target) {
		this.lerping = true;
		this.lookAtTarget = target;
	}

	void smoothLookTowards() {
		Vector3 direction = this.lookAtTarget.position - transform.position;
		Quaternion lookOnLook = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookOnLook, Time.deltaTime * 4);
		this.reloadRotation();
		if(Quaternion.Angle(transform.rotation, lookOnLook) < 1) {
			this.lerping = false;
		}
	}

	void reloadRotation() {
		rotationX = transform.localRotation.eulerAngles.y;
		rotationY = -transform.localRotation.eulerAngles.x;
	}

	float eulerTo360(float eulerValue) {
		while(Mathf.Abs(eulerValue) > 180) {
			if(eulerValue > 0) {
				eulerValue -= 360;
			} else if(eulerValue < 0) {
				eulerValue += 360;
			}
		}
		return eulerValue;
	}

//	void OnGUI(){
//		
//		if (GUILayout.Button ("RestoreFOV")) {
//			Camera.main.fieldOfView = FOV;
//		}
//	}
}
