using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

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
    // This will send the register information to playfab
    // if successful it will register the user's account
    public void RegisterUser() 
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UserNameRegisterInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordRegisterInput.text,

            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    // This will send the information to playfab to login
    public void LoginUser() 
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailLoginInput.text,
            Password = PasswordLoginInput.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    // Success message to display when called.
    private void OnLoginSuccess(LoginResult result) 
    {
        MessageText.text = "Success, loggin in!";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This the request sent to playfab to reset the password 
    public void RecoverUserPassword() 
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailRecoveryInput.text,
            TitleId = "7DFD1",
        };
        
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnErrorRecovery);

    }

    // If the request is successful this message will be sent.
    public void OnRecoverySuccess(SendAccountRecoveryEmailResult obj) 
    {
        OpenLoginPage();
        MessageText.text = "Recovery Email sent!";
    }

    // Invalid Email message
    private void OnErrorRecovery(PlayFabError result) 
    {
        MessageText.text = "Invalid Email";
    }

    // Error message sent based on the erroeMessage
    private void OnError(PlayFabError Error) 
    {
        MessageText.text = Error.ErrorMessage;
        Debug.Log(Error.GenerateErrorReport());
    }

    // Opens the login scene when an account is successfully resgistered
    private void OnRegisterSuccess(RegisterPlayFabUserResult Result) 
    {
        MessageText.text = "New Account is Created";
        OpenLoginPage();
    }

    // activates the loginpage panel and deactivates the other two panels
    public void OpenLoginPage() 
    {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(false);
        TopText.text ="Login";
    }

    // activates the Register Panel and deactivates the other two panels
    public void openRegisterPage() 
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
        RecoveryPage.SetActive(false);
        TopText.text = "Register";
    }

    // activates the Recovery panel and deactivates the other two panels
    public void openRecoveryPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(true);
        TopText.text = "Recover Password";
    }
    #endregion
}
