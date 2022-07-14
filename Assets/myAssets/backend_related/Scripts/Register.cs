using MySql.Data.MySqlClient;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    private string host = "120.77.148.135";
    private string port = "3306";     
    private string userName = "root";
    private string password = "penguinspy123456";
    private string databaseName = "penguintest";
    private MySqlAccess mysql; 
    
    // required input data for this script
    public InputField registerName;
    public InputField registerPassword;
 
    private void Start()
    {
        mysql = new MySqlAccess(host, port, userName, password, databaseName);
    }
    public void RegisterClick()
    {
        if (registerName.text != "" && registerPassword.text != null)
        {
            mysql.OpenSql();
            DataSet queryResult = mysql.Select("userinfo", new string[] { "username" }, new string[] { "`" + "username" + "`" }, new string[] { "=" }, new string[] { registerName.text });
            if (queryResult!= null)
            {
                DataTable table = queryResult.Tables[0];
                if (table.Rows.Count > 0)
                // check if username already exists           
                {
                    Debug.Log("Username already existed.");
                }
                else
                {
                    string query = mysql.Insert("userinfo", new string[] { "username", "password" }, new string[] { registerName.text, registerPassword.text });
                    MySqlCommand cmd = new MySqlCommand(query, mysql.mySqlConnection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Close();
                    Debug.Log("Successful registration.");
               }
            }
            mysql.CloseSql();
        }
        else
        {
            Debug.Log("Wrong input format.");
        }
    }
}
