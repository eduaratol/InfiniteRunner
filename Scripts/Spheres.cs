using UnityEngine;

public enum SphereType
{
    Score, Help, Evil
}

public class Spheres : MonoBehaviour
{
    public SphereType sphereType;

    private void OnTriggerEnter(Collider other)
    {
		if(other.tag == "Player")
		{
            if(sphereType.ToString() == "Score")
            {
                Controller.score++;
                Controller.velocity += 0.01f;
            }
            else if(sphereType.ToString() == "Help")
            {
                if (Controller.life < 5)
                {
                    Controller.life++;
                }
                Controller.score++;
                Controller.velocity += 0.01f;
            }
            else if (sphereType.ToString() == "Evil")
            {
                if (Controller.life > 0)
                {
                    Controller.life--;
                }
            }
            other.GetComponent<Controller>().CatchObject(this.gameObject);
        }
    }
}