using UnityEngine;
using System.Collections;

public class ULibXPooledObject : MonoBehaviour {

	public virtual void OnObjectReuse() { }
    protected void Destroy()
    {
        gameObject.SetActive(false);
    }

}
