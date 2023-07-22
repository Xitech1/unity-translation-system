using System;
using TMPro;
using UnityEngine;

public class Translator : MonoBehaviour
{
    private TextMeshProUGUI textMeshText;

    private void Start()
    {
        GetReference();
        ReplaceTextWithTranslatedText();
    }

    private void GetReference()
    {
        textMeshText = GetComponent<TextMeshProUGUI>();
    }

    private string GetStringID()
    {
        if ( textMeshText != null )
        {
            return textMeshText.text;
        }
        
        Debug.LogError($"Get stringID failed on the: {gameObject.name} GameObject. Expect errors in the UI translations. Are you sure the given text is not empty?");
        return "error :(";
    }

    private void ReplaceTextWithTranslatedText()
    {
        var text = LanguageHandler.Instance.GetTranslation( GetStringID() );
        if ( textMeshText != null )
        {
            textMeshText.text = text;
        }
    }
}