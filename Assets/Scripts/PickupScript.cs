using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PickupScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private Transform tray;
    private bool movetarget = false;

    // character and object  transform 
    [SerializeField]
    private Transform CharacterHand;
    private Transform labEquipment;

    private Transform referenceIK;
    [SerializeField]
    private TwoBoneIKConstraint twoBoneIK;
    private RigBuilder rigBuilder;

    private void Start()
    {
        animator = GetComponent<Animator>();
        // twoBoneIK = GetComponent<TwoBoneIKConstraint>();
        rigBuilder = GetComponent<RigBuilder>();
    }
    private void FixedUpdate()
    {
        if (movetarget)
        {
            labEquipment.position = Vector3.Lerp(labEquipment.position, tray.position, Time.deltaTime * 1);
            if (tray.position.magnitude - labEquipment.position.magnitude < 0.2f)
            {
                labEquipment.position = tray.position;
                labEquipment.rotation = tray.rotation;
            }
        }
    }
    private void ResetAnimatorandrig(bool enabled)
    {
        foreach (RigLayer layer in rigBuilder.layers)
        {
            layer.active = enabled;
        }
    }
    public void GetlabEquipment(Transform Equipment, Transform reference)
    {
        labEquipment = Equipment;
        referenceIK = reference;

    }
    public void Pickup()
    {
        //trigger pickup animation
        animator.SetTrigger("PickUp");
        labEquipment.SetParent(CharacterHand);
        twoBoneIK.data.target = referenceIK;
        rigBuilder.enabled = true;
        // ResetAnimatorandrig(true);


    }
    public void Pour()
    {
        //trigger pour animation

        animator.SetTrigger("Pour");

    }
    public void Place()
    {
        // trigger place animation
        animator.SetTrigger("Place");
        Debug.Log("placed");
        movetarget = !movetarget;
        labEquipment.SetParent(null);
        twoBoneIK.data.target = null;
        rigBuilder.enabled = true;
        ResetAnimatorandrig(true);
        animator.SetTrigger("Cancelled");
    }
    public void Shake()
    {
        animator.SetTrigger("Shake");
    }

}
