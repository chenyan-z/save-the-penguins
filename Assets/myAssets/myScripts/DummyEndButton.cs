using MySql.Data.MySqlClient;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DummyEndButton : MonoBehaviour
{
    private string host = "120.77.148.135";
    private string port = "3306";     
    private string userName = "root";
    private string password = "penguinspy123456";
    private string databaseName = "penguintest";
    private MySqlAccess mysql;
    public string myUid;
    
    // the game status id
    // for example, gameStatus = 1, the user will get penguin card1
    public int gameStatus = 1;

    private void Start()
    {
        myUid = GameObject.FindGameObjectWithTag("RegistrationTag").GetComponent<Login>().uid.ToString();
        mysql = new MySqlAccess(host, port, userName, password, databaseName);
        Debug.Log("Current scene: DummyGameScene. Current userid: " + myUid.ToString());
    }

    public void DummyEndButtonClick()
    {
        //Debug.Log("DummyEndButton is clikced.");
        //TO DO: check if the penguin card is already obtained
        if (myUid != "-1")
        {
            mysql.OpenSql();
            string query = mysql.Update("userinfo", "penguin" + gameStatus.ToString(), "1", new string[] { "userid" }, new string[] { "=" }, new string[] { myUid });
            //Debug.Log(query);
            Debug.Log("Congradulation! " + "Uid" + myUid.ToString() + " has " + "penguin" + gameStatus.ToString() + " now! ");
            MySqlCommand cmd = new MySqlCommand(query, mysql.mySqlConnection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Close();
            mysql.CloseSql();
            //jump to next scene
            SceneManager.LoadScene("DummyEndScene");
        }
        else
        {
            Debug.Log("Wrong user id.");
        }
    }
}
