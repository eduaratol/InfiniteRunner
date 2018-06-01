using UnityEngine;

public class TouchButton : MonoBehaviour
{
    public string MethodName;
    
	void OnMouseDrag()
	{
        Controller.player.GetComponent<Controller>().SendMessage (MethodName);
	}
}