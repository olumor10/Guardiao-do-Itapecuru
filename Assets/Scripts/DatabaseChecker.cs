using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DatabaseChecker : MonoBehaviour
{
    private const string URL = "https://api-guardiao-do-itapecuru.onrender.com/auth/login"; // Mudar para o link/endpoint correto do backend

    [SerializeField]
    private TMP_InputField m_email;
    [SerializeField]
    private TMP_InputField m_password;
    [SerializeField]
    private TMP_Text errorMessage; // Adiciona um campo para a mensagem de erro

    public void ChecarCadastro()
    {
        Debug.Log($"Email: {m_email.text}, password: {m_password.text}"); // Linha de depuração
        StartCoroutine(ProcuraUsuarioNoBackEnd(URL));
    }

    private IEnumerator ProcuraUsuarioNoBackEnd(string uri)
    {
        string cadastroJSON = JsonUtility.ToJson(new CadastroJSON(m_email.text, m_password.text));
        Debug.Log($"Cadastro JSON: {cadastroJSON}"); // Linha de depuração

        using (UnityWebRequest request = new UnityWebRequest(uri, "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(cadastroJSON);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
                errorMessage.text = "Email ou Senha incorreta! Tente novamente."; // Mensagem de erro genérica
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                // Parse the JSON response
                LoginResponse response = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);
                if (response.message == "Login bem-sucedido!")
                {
                    SceneManager.LoadScene("MainMenu"); // Mude para o nome da sua cena em que o jogo está
                }
                else
                {
                    Debug.Log("Login falhou. Verifique suas credenciais.");
                    errorMessage.text = response.message; // Exibe a mensagem de erro recebida do servidor
                }
            }
        }
    }
}

[System.Serializable]
public class CadastroJSON
{
    public string email;
    public string password;

    public CadastroJSON(string newEmail, string newPassword)
    {
        email = newEmail;
        password = newPassword;
    }
}

[System.Serializable]
public class LoginResponse
{
    public string message;
    public User user;
}

[System.Serializable]
public class User
{
    public string _id;
    public string username;
    public string email;
    public string gender;
    public string ageRange;
    public string token;
}
