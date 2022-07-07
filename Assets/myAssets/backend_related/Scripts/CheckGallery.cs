using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class CheckGallery : MonoBehaviour
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
    public void CheckClick()
    {
        mysql.OpenSql();
        // currently only return 0 or 1 for penguin1
        DataSet queryResult = mysql.Select("userinfo", new string[] { "penguin1" }, new string[] { "`" + "username" + "`", "`" + "password" + "`" }, new string[] { "=", "=" }, new string[] { loginname.text,loginpassword.text });
        if (queryResult != null)
        {
            DataTable table = queryResult.Tables[0];
            if (table.Rows.Count > 0)
            {
                if ((int)(table.Rows[0][0]) == 1)
                    Debug.Log("You have penguin1.");
                else
                    Debug.Log("You don't have penguin1.");
                mysql.CloseSql();
                return;
            }
        }
        Debug.Log("Login failed.");
        mysql.CloseSql();
    }
}
