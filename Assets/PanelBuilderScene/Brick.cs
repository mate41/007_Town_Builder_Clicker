using UnityEngine;


public class Brick : MonoBehaviour
{
    public int direction;
    public int type;
    void Start()
    {
        if (direction % 2 == 0)
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    public static void SetBrickDirection (GameObject newBrick, int newDirection)
    {
        newBrick.GetComponent<Brick>().direction = newDirection;
        // Debug.Log("It is " + newBrick.GetComponent<Brick>().direction);
    }
    public static void SetBrickType (GameObject newBrick, int newType)
    {
        newBrick.GetComponent<Brick>().type = newType;

        switch(newBrick.GetComponent<Brick>().type)
        {
            case 0:     // Common brick
                break;
            case 1:     // Concreate
                break;
            case 2:     // Glass
                break;    
        }
    }

}
