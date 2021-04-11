using UnityEngine;



public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;     //a parameter
    [SerializeField] float rotationThrust = 100f;   //cache - references for readability or speed
    [SerializeField] AudioClip mainEngine;    //state - private instance (member) variable

    [SerializeField] ParticleSystem mainEngineParticle;
    Rigidbody rb;

    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
           
    }

    void ProcessThrust(){
        
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrust();

        }
        else
        {
            StopThrust();
        }


    }

    void StopThrust()
    {
        audioSource.Stop();                //stop as we're not thrusting
        mainEngineParticle.Stop();
    }

    void StartThrust()
    {
        //rb.AddRelativeForce(1 , 1 , 1);                    //relative position 1 wrt x ,then y ,then z    
        //rb.AddRelativeForce(Vector3);                    //Vector3 cuz it takes account of speed and the direction object's going
        //rb.AddRelativeForce(0 , 1 , 0);                    //straight up in the air 
        //rb.AddRelativeForce(Vector3.up);                  //another way to write rb.AddRelativeForce(0,1,0);
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);    //Time.deltaTime to make the thrust fps independent
        if (!audioSource.isPlaying)
        {                 //if audio is not playing then play it    
            audioSource.PlayOneShot(mainEngine);        //else is  not here as the sound has to stop when we're not thrusting so its outside 
                                                        //PlayOneshot can play any audio u give as it takes a parameter. Play() doesnt take parameter so not a good choice as we need 
                                                        //to specify which audio we're playing
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A))
        {
            //we're going to change the Z for the rotations
            ApplyRotation(rotationThrust);            //it will take positive val
            
        }

        else if(Input.GetKey(KeyCode.D)){
            
            ApplyRotation(-rotationThrust);  //negative val
            
        }
        
    }

    void ApplyRotation(float rotationThisFrame)
    {   rb.freezeRotation = true;                    //freezing rotation  so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);     
        //rotating on Z axis ,another way to write transform.Rotate(0,0,1);
        //rotating on Z axis ,but in -ve direction.
        rb.freezeRotation = false;                   //unfreezing rotation so the physics system can take over
    }
}