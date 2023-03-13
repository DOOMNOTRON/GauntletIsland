using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class LogInPagePlayFab : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TopText;
    [SerializeField] TextMeshProUGUI MessageText;
    
    [Header("Login")]
    [SerializeField] TMP_InputField EmailLoginInput;
    [SerializeField] TMP_InputField PasswordLoginInput;
    [SerializeField] GameObject LoginPage;

    [Header("Register")]
    [SerializeField] TMP_InputField UserNameRegisterInput;
    [SerializeField] TMP_InputField EmailRegisterInput;
    [SerializeField] TMP_InputField PasswordRegisterInput;
    [SerializeField] GameObject RegisterPage;

    [Header("Recovery")]
    [SerializeField] TMP_InputField EmailRecoveryInput;
    [SerializeField] GameObject RecoveryPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Button Functions

    public void RegisterUser() 
    {
        //if ()
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UserNameRegisterInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordRegisterInput.text,

            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    private void OnError(PlayFabError Error) 
    {
        MessageText.text = Error.ErrorMessage;
        Debug.Log(Error.GenerateErrorReport());
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult Result) 
    {
        MessageText.text = "New Account is Created";
        OpenLoginPage();
    }

    public void OpenLoginPage() 
    {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(false);
        TopText.text ="Login";
    } 

    public void openRegisterPage() 
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
        RecoveryPage.SetActive(false);
        TopText.text = "Register";
    }

    public void openRecoveryPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(true);
        TopText.text = "Recover Password";
    }
    #endregion
}
