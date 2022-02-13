using UnityEngine;

public class SelectableCharacter : MonoBehaviour {

    public SpriteRenderer selectImage;

    private void Awake() {
        if(selectImage !=null) selectImage.enabled = false;
    }

    //Turns off the sprite renderer
    public void TurnOffSelector()
    {
        if (selectImage != null) selectImage.enabled = false;
    }

    //Turns on the sprite renderer
    public void TurnOnSelector()
    {
        if (selectImage != null) selectImage.enabled = true;
    }

}
