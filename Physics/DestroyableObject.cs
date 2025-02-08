using UnityEngine;
using System.Collections.Generic;
//using Unity.VisualScripting;
public class DestroyableObject : MonoBehaviour
{
    public List<Transform> partsObjects;
    public Transform main;
    private void Start()
    {
       
        ConnectAll();
    }
    public void ConnectAll()
    {
        main.gameObject.AddComponent<Part>().isConnectedToMain = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) != main)
            {
                partsObjects.Add(transform.GetChild(i));
            }
        }
        
        foreach (Transform t in partsObjects)
        {
            t.gameObject.AddComponent<Part>();
        }
    }

}
public class Part : MonoBehaviour
{
    public bool isConnectedToMain;
    public Part connectedTo;
    public List<Part> connectedToMe;
    public bool explode;

    private void Start()
    {
        connectedToMe = new List<Part>();
    }
    public void UnConnect()
    {
        if(connectedTo) connectedTo.connectedToMe.Remove(this);
        Vector3 force = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        transform.SetParent(null);
        if(TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(force,ForceMode.Impulse);
        }
        else
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
    public void TryConnect()
    {
        Collider[] nearest = Physics.OverlapSphere(transform.position, transform.localScale.x / 2 + 0.1f);
        foreach(Collider c in nearest)
        {
            if(c.gameObject!=gameObject && c.GetComponent<Part>() && c.GetComponent<Part>().isConnectedToMain)
            {
                isConnectedToMain = true;
                c.GetComponent<Part>().connectedToMe.Add(this);
                connectedTo = c.GetComponent<Part>();
                c.GetComponent<Part>().ApplyConnected();
                break;
            }
        }
    }
    private void Update()
    {
        if (!isConnectedToMain) TryConnect();
        if (explode)
        {
            UnConnect();
            Destroy(this);
        }
    }
    public void ApplyConnected()
    {
        foreach(var c in connectedToMe)
        {
            c.transform.SetParent(transform);
        }
    }

    public void ReCheckConnections()
    {
        if (!connectedTo)
        {
            UnConnect();
        }
    }
}
