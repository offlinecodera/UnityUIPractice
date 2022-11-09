using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextInputHandler : MonoBehaviour {

    InputField m_InputField;

    static bool isKeyboardOpen = false;

    static void InputTextFocused() {
        UIScript07 parentscript = new UIScript07();
        parentscript.InputTextFocused();
        isKeyboardOpen = true;
       
    }


    // Start is called before the first frame update
    void Start() {

        m_InputField = GetComponent<InputField>();

    }

    // Update is called once per frame
    void Update() {
        if (m_InputField.isFocused) {
            ////Change the Color of the Input Field's Image to green
            //m_InputField.GetComponent<Image>().color = Color.green;
            if (!isKeyboardOpen) {
                InputTextFocused();
            }
        } else if (!m_InputField.isFocused) {
            isKeyboardOpen = false;
        }

    }
}
