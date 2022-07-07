using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    private string host = "120.77.148.135";
    private string port = "3306";     
    private string userName = "root";
    private string password = "penguinspy123456";
    private string databaseName = "penguintest";
    private MySqlAccess mysql;

     // required input data for this script
    public InputField loginname;
    public InputField loginpassword;
   
    private void Start()
    {
        mysql = new MySqlAccess(host, port, userName, password, databaseName);
    }
    public void LoginClick()
    {
        mysql.OpenSql();
        DataSet queryResult = mysql.Select("userinfo", new string[] { "username" }, new string[] { "`" + "username" + "`", "`" + "password" + "`" }, new string[] { "=", "=" }, new string[] { loginname.text,loginpassword.text });
        if (queryResult != null)
        {
            DataTable table = queryResult.Tables[0];
            if (table.Rows.Count > 0)
            {
                Debug.Log("Login successfully." + " Username: " + table.Rows[0][0]);
                mysql.CloseSql();
                return;
            }
        }
        Debug.Log("Login failed.");
        mysql.CloseSql();
    }
}