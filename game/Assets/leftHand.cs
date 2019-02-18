using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class leftHand : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject projectile;
    private GameObject MainCamera;
    private float Speed = 1f;
    private bool isRotating = false;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;
    int charge = 0;
    int attack = 0;
    bool tap = true;
    bool tap2 = true;
    public int speed;
    public int speed2;
    // Start is called before the first frame update
    void Awake()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //int right = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void SetRotate(GameObject Temporary_Bullet_Handler, GameObject camera)
    {
        //You can call this function for any game object and any camera, just change the parameters when you call this function
        transform.rotation = Quaternion.Lerp(Temporary_Bullet_Handler.transform.rotation, camera.transform.rotation, Speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown("joystick button 8") || Input.GetKeyDown("joystick button 9"))
        {
            if (tap=true)
            {
                attack++;
                if (attack == 1)
                {
                    //GameObject canvas = new GameObject("canvas");
                    //string textString = "fireball";
                    //Text text = canvas.AddComponent<Text>();
                    //text.text = textString;
                    //Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
                    //text.font = ArialFont;
                    //text.material = ArialFont.material;
                    //return text;
                    print("fireball");
                }
                else if (attack == 2)
                {
                    print("shield");
                }
                else if (attack > 2)
                {
                    attack = 0;
                    print("lightning");
                }
            }

        }
        else tap = true;

        if (Input.GetKey("joystick button 14") || Input.GetKey("joystick button 15"))
        {
            charge++;
            if (charge%30 == 0 && charge < 1000)
            {
                print("charge: " + charge);
            }
            else if (charge >= 300)
            {
                print("Maxed");
                charge--;
            }
            if ((Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("joystick button 5")) && charge >= 160)
            {
                /*
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(projectile, Bullet_Emitter.transform.position, MainCamera.transform.rotation) as GameObject;
                float force = 40;
                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
                //(-0.4, 0.6, 0.5, 0.5
                //Retrieve the Rigidbody component from the instantiated Bullet and control it.                                              
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force./

                //Temporary_Bullet_Handler.transform.position += Temporary_Bullet_Handler.transform.forward * Time.deltaTime * force;
                //Temporary_RigidBody.AddForce(110,1,1);
                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.*/
                transform.rotation = MainCamera.transform.rotation;
                transform.Rotate(Vector3.left * 90);
                print(transform.rotation);
                if (attack == 0)
                {
                    GameObject instBullet;
                    instBullet = Instantiate(projectile, GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.rotation) as GameObject;
                    //instBullet.transform.Rotate(MainCamera.transform.rotation);
                    instBullet.transform.Rotate(Vector3.left * 90);
                    Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                    instBulletRigidbody.AddForce(GameObject.FindGameObjectWithTag("MainCamera").transform.eulerAngles * speed * -1);
                    Destroy(instBullet, 5f);
                    charge = 0;
                    print("fireball");
                }
                else if (attack == 1)
                {
                    transform.Rotate(Vector3.left * 90);
                    GameObject instBullet;
                    instBullet = Instantiate(projectile, GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.rotation) as GameObject;
                    //instBullet.transform.Rotate(MainCamera.transform.rotation);
                    instBullet.transform.Rotate(Vector3.left * 90);
                    Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
                    instBulletRigidbody.AddForce(GameObject.FindGameObjectWithTag("MainCamera").transform.eulerAngles * speed);
                    Destroy(instBullet, 5f);
                    charge = 0;
                    print("lightning");
                }
            }
        }
        else charge = 0;

        //set emitter thing
        //Bullet_Emitter.transform.position = this.transform.position;
    }
}