using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour
{
    public delegate void OnObstacleHeightScaleHandler(float value);
    public static event OnObstacleHeightScaleHandler OnObstacleHeightScale;
    [SerializeField] private Material bodyMat;
    private void OnTriggerEnter(Collider other)
    {
        float value = (transform.position.y + transform.lossyScale.y) - other.transform.position.y;
        OnObstacleHeightScale?.Invoke(-value * 0.5f);

        GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        piece.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
        piece.transform.localScale = new Vector3(transform.lossyScale.x, value * 0.5f, transform.lossyScale.z);

        piece.GetComponent<MeshRenderer>().material = bodyMat;
        piece.GetComponent<CapsuleCollider>().enabled = false;
        Rigidbody pieceRb = piece.AddComponent<Rigidbody>();

        pieceRb.AddForce(-1, 1, -0.5f, ForceMode.Impulse);
        pieceRb.AddTorque(75, 15, 45);
    }
}
