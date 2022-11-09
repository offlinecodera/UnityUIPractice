using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript07 : MonoBehaviour {
    public GameObject[] QuestionGroupArr;
    public QAClass07[] qaArr;
    public GameObject AnswerPanel;

    // Start is called before the first frame update
    void Start() {

        qaArr = new QAClass07[QuestionGroupArr.Length];

    }

    // Update is called once per frame
    void Update() {

    }

    public void SubmitAnswer() {
        for (int i = 0; i < qaArr.Length; i++) {
            qaArr[i] = ReqdQuestionAndAnswer(QuestionGroupArr[i]);
        }
        Displayresult();
    }

    QAClass07 ReqdQuestionAndAnswer(GameObject questionGroup) {
        QAClass07 result = new QAClass07();
        GameObject q = questionGroup.transform.Find("Question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

        result.Question = questionGroup.GetComponent<Text>().text;

        var tgGroup = a.GetComponent<ToggleGroup>();
        var textInput = a.GetComponent<InputField>();

        //for input type checkbox
        if (tgGroup != null) {
            for (int i = 0; i < a.transform.childCount; i++) {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn) {

                    result.Answer = a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                    break;

                }
            }
        } else if (textInput != null) {
            result.Answer = a.transform.Find("Text").GetComponent<Text>().text;
        } else if (tgGroup == null && textInput == null) {
            string s = "";
            int counter = 0;
            for (int i = 0; i < a.transform.childCount; i++) {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn) {
                    if (counter != 0) {
                        s = s + ", ";
                    }
                    s = s + a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                }

                if (i == a.transform.childCount - 1) {
                    s = s + ".";
                }

            }

            result.Answer = s;
        }

        return result;
    }

    void Displayresult() {
        AnswerPanel.SetActive(true);
        string s = "";
        for (int i = 0; i < qaArr.Length; i++) {
            s = s + qaArr[i].Question + "\n";
            s = s + qaArr[i].Answer + "\n\n";
        }

        AnswerPanel.transform.Find("Answer").GetComponent<Text>().text = s;
    }

}
// Add this to read the array
[System.Serializable]
public class QAClass07 {
    public string Question = "";
    public string Answer = "";
}

