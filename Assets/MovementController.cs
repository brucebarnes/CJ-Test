using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Body Parts")]
    public GameObject body;
    public GameObject head;
    public GameObject upperArmRight;
    public GameObject lowerArmRight;
    public GameObject upperArmLeft;
    public GameObject lowerArmLeft;
    public GameObject hips;
    public GameObject upperLegLeft;
    public GameObject lowerLegLeft;
    public GameObject upperLegRight;
    public GameObject lowerLegRight;

    [Header("Force Parts")]
    public float pushForce = 20f;
    public float limbMovementSpeed = 6f;

    private Quaternion startUpperLeftLegRotation;
    private Quaternion startUpperRightLegRotation;
    private Quaternion startLowerLeftLegRotation;
    private Quaternion startLowerRightLegRotation;
    private Quaternion startUpperLeftArmRotation;
    private Quaternion startUpperRightArmRotation;
    private Quaternion startLowerLeftArmRotation;
    private Quaternion startLowerRightArmRotation;
    private Quaternion startBodyRotation;

    private void Awake() 
    {
        SetStartingRotation();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }


    void SetStartingRotation()
    {
        startLowerLeftLegRotation = lowerLegLeft.GetComponent<ConfigurableJoint>().targetRotation;
        startLowerRightLegRotation = lowerLegRight.GetComponent<ConfigurableJoint>().targetRotation;
        startUpperLeftLegRotation = upperLegLeft.GetComponent<ConfigurableJoint>().targetRotation;
        startUpperRightLegRotation = upperLegRight.GetComponent<ConfigurableJoint>().targetRotation;
        startUpperLeftArmRotation = upperArmLeft.GetComponent<ConfigurableJoint>().targetRotation;
        startUpperRightArmRotation = upperArmRight.GetComponent<ConfigurableJoint>().targetRotation;
        startLowerLeftArmRotation = lowerArmLeft.GetComponent<ConfigurableJoint>().targetRotation;
        startLowerRightArmRotation = lowerArmRight.GetComponent<ConfigurableJoint>().targetRotation;
        startBodyRotation = body.GetComponent<ConfigurableJoint>().targetRotation;

    }
    void InputCheck()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeftLeg();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRightLeg();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveArmsUp();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveArmsDown();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {

        }
        if(Input.GetKeyDown(KeyCode.D))
        {

        }
        if(Input.GetKeyDown(KeyCode.W))
        {

        }
        if(Input.GetKeyDown(KeyCode.S))
        {

        }

        //Press Space Bar to Reset
        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel(Application.loadedLevel);
        //press P to start slowmo mode
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0.4f;
            else
                Time.timeScale = 1;
        }
    }

    void MoveArmsUp()
    {
        //Set Target Rotation of Upper Arm to 90 degrees parallel
        //Lerp is from rotation, to rotation, speed)
        upperArmRight.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Lerp(upperArmRight.GetComponent<ConfigurableJoint>().targetRotation, new Quaternion(0,0,-1,1), limbMovementSpeed );
        upperArmLeft.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Lerp(upperArmLeft.GetComponent<ConfigurableJoint>().targetRotation, new Quaternion(0,0,1,1), limbMovementSpeed );
    }

    void MoveArmsDown()
    {
        upperArmRight.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Lerp(upperArmRight.GetComponent<ConfigurableJoint>().targetRotation, startUpperRightArmRotation, limbMovementSpeed );
        upperArmLeft.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Lerp(upperArmLeft.GetComponent<ConfigurableJoint>().targetRotation, startUpperLeftArmRotation, limbMovementSpeed );  
    }

    void MoveLeftLeg()
    {
        upperLegLeft.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Lerp(upperLegLeft.GetComponent<ConfigurableJoint>().targetRotation, new Quaternion(.5f,0,0,1),6);
        lowerLegLeft.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Lerp(lowerLegLeft.GetComponent<ConfigurableJoint>().targetRotation, new Quaternion(1,0,0,1),10);
    }

    void MoveRightLeg()
    {
        upperLegRight.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Lerp(upperLegRight.GetComponent<ConfigurableJoint>().targetRotation, new Quaternion(.5f,0,0,1), 6);
        lowerLegRight.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Lerp(lowerLegRight.GetComponent<ConfigurableJoint>().targetRotation, new Quaternion(1,0,0,1), 10);
    }

}
