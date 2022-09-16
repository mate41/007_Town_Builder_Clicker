using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject brickPrefab;
    public Material commonBrickMaterial, concreateBrickMaterial, glassBrickMaterial;
    public int brickAmountInLine = 2;

    private static Vector3 newBrickPosition;
    private int brickType;
    private int brickInLineCount;
    private static float brickLength, brickWidth, brickDroppingHeight;
    private bool leftMouseIsDown;
    private bool brickMustBeShifted;
    private int brickDirection;
    void Start()
    {
        Application.targetFrameRate = 120;
        newBrickPosition = new Vector3(0f, 0f, 0f);
        brickLength = 2.5f; brickWidth = 1f;
        brickDroppingHeight = 10f;
        brickInLineCount = 0;
        brickDirection = 1;
        leftMouseIsDown = false;
        brickMustBeShifted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !leftMouseIsDown)
        {
            if (brickInLineCount % brickAmountInLine == 0)
                brickDirection = ChangeBrickDirecrtion(brickDirection);
            if (brickInLineCount % (brickAmountInLine * 2) == 0)
                brickMustBeShifted = !brickMustBeShifted;
                
            if (brickDirection == 1)
            {
                newBrickPosition += new Vector3(0f, 0f, brickLength);
            }
            else if (brickDirection == 2)
            {
                newBrickPosition += new Vector3(brickLength, 0f, 0f);
            }
            else if (brickDirection == 3)
            {
                newBrickPosition += new Vector3(0f, 0f, -brickLength);
            }
            else
            {
                newBrickPosition += new Vector3(-brickLength, 0f, 0f);
            }

            GameObject newBrick = Instantiate(brickPrefab, newBrickPosition, Quaternion.identity);
            // Brick.SetBrickType(newBrick, brickType);
            switch(brickType)
            {   
                case 0:
                    newBrick.GetComponent<Renderer>().material = commonBrickMaterial;
                    break;
                case 1:
                    newBrick.GetComponent<Renderer>().material = concreateBrickMaterial;
                    break;
                case 2:
                    newBrick.GetComponent<Renderer>().material = glassBrickMaterial;
                    break;
            }
            Brick.SetBrickDirection(newBrick, brickDirection);

            newBrickPosition.y = brickDroppingHeight;
            brickInLineCount++;
            leftMouseIsDown = true;
        }
        else 
        {
            leftMouseIsDown = false;
        }
    }

    public static int ChangeBrickDirecrtion (int brickDirection)
    {
        int res;
        if (brickDirection == 4)
        {
            res = 1;
        }
        else
        {
            res = brickDirection + 1;
        }

        // Due to the fact that I'm stupid, every number of brickDirection in this if-block is decreased with one, so 2 -> 1, and so on
        if (brickDirection == 4)
        {
            newBrickPosition -= new Vector3((brickLength + 0.5f * brickWidth) * 0.25f, 0f, (brickLength + 0.5f * brickWidth) * 0.25f);
            // newBrickPosition.x += (brickLength + 0.5f * brickWidth) * 0.5f;
           //newBrickPosition += new Vector3((brickLength + 0.5f * brickWidth)*0.25f, 0f, (brickLength + 0.5f * brickWidth)*0.25f);
        }
        else if (brickDirection == 1)
        {
            // newBrickPosition.x -= (brickLength + 0.5f * brickWidth) * 0.5f;
            newBrickPosition += new Vector3(-(brickLength + 0.5f * brickWidth) * 0.25f, 0f, (brickLength + 0.5f * brickWidth) * 0.25f);
        }
        else if (brickDirection == 2)
        {
            newBrickPosition -= new Vector3(-(brickLength + 0.5f * brickWidth) * 0.25f, 0f, (brickLength + 0.5f * brickWidth) * 0.25f);
            newBrickPosition.z += (brickLength + 0.5f * brickWidth) * 0.5f;
           //newBrickPosition += new Vector3((brickLength - 0.5f * brickWidth)*0.25f, 0f, (brickLength - 0.5f * brickWidth)*0.25f);
        }
        else
        {
            newBrickPosition.z -= (brickLength + 0.5f * brickWidth) * 0.5f;
            newBrickPosition += new Vector3((brickLength + 0.5f * brickWidth) * 0.25f, 0f, (brickLength + 0.5f * brickWidth) * 0.25f);
        }

        return res;
    }
    public void SetBrickType0()
    {
        brickType = 0;
    }
    public void SetBrickType1()
    {
        brickType = 1;
    }
    public void SetBrickType2()
    {
        brickType = 2;
    }
}