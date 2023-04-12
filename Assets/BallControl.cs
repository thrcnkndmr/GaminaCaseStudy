using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallControl : MonoBehaviour {

    public float speed; // topun hızı
    public float maxSpeed; // topun maksimum hızı
    public float maxRotationAngle; // topun maksimum dönüş açısı (derece cinsinden)
    public Rigidbody rigidBody;
    public Transform rotationPivot; // topun dönüş pivotu

    private Vector3 lastPosition;
    private Quaternion lastRotation;

    void Start () {
        lastPosition = transform.position;
        lastRotation = rotationPivot.rotation;
    }

    void FixedUpdate () {
        // Topun hareketini hesapla
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rigidBody.AddForce(movement * speed);

        // Topun maksimum hızını kontrol et
        if (rigidBody.velocity.magnitude > maxSpeed) {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }

        // Topun dönüş açısını kontrol et
        Quaternion rotationDelta = rotationPivot.rotation * Quaternion.Inverse(lastRotation);
        float angle = Quaternion.Angle(Quaternion.identity, rotationDelta);
        if (angle > maxRotationAngle) {
            rotationDelta = Quaternion.Slerp(Quaternion.identity, rotationDelta, maxRotationAngle / angle);
            rotationPivot.rotation = lastRotation * rotationDelta;
        }

        // Topun duvarlardan geçmesini engelle
        Vector3 direction = transform.position - lastPosition;
        float distance = direction.magnitude;
        if (distance > 0f) {
            RaycastHit hit;
            if (Physics.Raycast(lastPosition, direction.normalized, out hit, distance)) {
                if (hit.collider.gameObject.CompareTag("Wall")) {
                    rigidBody.velocity = Vector3.zero;
                    transform.position = lastPosition;
                    rotationPivot.rotation = lastRotation;
                }
            }
        }

        // Pozisyon ve dönüşü kaydet
        lastPosition = transform.position;
        lastRotation = rotationPivot.rotation;
    }
}