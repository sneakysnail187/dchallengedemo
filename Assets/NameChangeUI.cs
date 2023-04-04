using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameChangeUI : MonoBehaviour
{
    //stores a reference to the NameChange UI
    public GameObject nameChangeUIElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //enable and disable UI of this element
    public void disableUI(){
        GenericUIController.disableUI(nameChangeUIElement);
    }
    public void enableUI(){
        GenericUIController.enableUI(nameChangeUIElement);
    }
}
