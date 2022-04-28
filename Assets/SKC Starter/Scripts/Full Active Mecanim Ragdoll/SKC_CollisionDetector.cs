using UnityEngine;


public class SKC_CollisionDetector : MonoBehaviour
{
    #region Private Vars
    private SKC_SlaveController slaveController;
    private LayerMask layerMask;
    #endregion


    void Start()
    {
        SKC_HumanoidSetUp setUp = this.GetComponentInParent<SKC_HumanoidSetUp>();
        slaveController = setUp.slaveController;
        layerMask = setUp.dontLooseStrengthLayerMask;
    }

    private bool CheckIfLayerIsInLayerMask(int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!CheckIfLayerIsInLayerMask(collision.gameObject.layer))
        {
            slaveController.currentNumberOfCollisions++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!CheckIfLayerIsInLayerMask(collision.gameObject.layer))
        {
            slaveController.currentNumberOfCollisions--;
        }
    }

}
