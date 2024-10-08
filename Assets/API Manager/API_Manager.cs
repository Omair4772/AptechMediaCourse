using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class API_Manager : MonoBehaviour
{
    // Get ACCESS TOKEN
    public string ACCESS_TOKEN = "387233b8be14771303f4b4aa654f46a23d7c75fec47492a472fdc2c17aea85eb";
    
    private const string AUTH_API = "https://simple-books-api.glitch.me/api-clients";
    private const string ORDER_URL = "https://simple-books-api.glitch.me/orders";
    private const string BOOKS_URL = "https://simple-books-api.glitch.me/books";
    //IEnumerator GetAccessToken()
    //{
    //    Define the body content for the POST request

    //   string jsonPayload = "{\"clientName\": \"Mahad\", \"clientEmail\": \"MahadAli@gmail.com\"}";

    //    Convert the string to a byte array
    //    byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
    //    using UnityWebRequest request = new UnityWebRequest(ACCESS_TOKEN, "POST");
    //    request.uploadHandler = new UploadHandlerRaw(postData);
    //    request.downloadHandler = new DownloadHandlerBuffer();
    //    request.SetRequestHeader("Content-Type", "application/json");

    //    Send the request and wait for the response

    //   yield return request.SendWebRequest();

    //    Check for errors
    //    if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
    //        {
    //            Debug.LogError("Error: " + request.error);
    //        }
    //        else
    //        {
    //            Successfully received a response
    //            string jsonResponse = request.downloadHandler.text;
    //            Parse the JSON and extract the accessToken
    //           NewOrderResponse tokenResponse = JsonUtility.FromJson<NewOrderResponse>(jsonResponse);
    //            ACCESS_TOKEN = tokenResponse.orderId;
    //            Debug.Log("Access Token: " + ACCESS_TOKEN);
    //        }
    //}

    void Start()
    {

    //    NewOrder myorder = new NewOrder()
  //      {
           // bookId = 1,
         //   customerName = "John"
       // };

        //StartCoroutine(PlaceNewOrder(myorder));
        
        StartCoroutine(GetAllBooks());


        GetAuthorization authData = new()
        {
            clientName = "OMAIR",
            clientEmail = "omair@gmail.com"
        };

        if(ACCESS_TOKEN == null)
        {
            StartCoroutine(PlaceNewOrder(authData));
        }
    }


    IEnumerator PlaceNewOrder(GetAuthorization authData)
    {
        string jsonData = JsonUtility.ToJson(authData);
        
        using UnityWebRequest request = new(AUTH_API, "POST");
       
        // Convert the string to a byte array
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
       
        request.SetRequestHeader("Content-Type", "application/json");


        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            AuthResponse orderResponse = JsonUtility.FromJson<AuthResponse>(request.downloadHandler.text);

            Debug.Log("Created " + orderResponse.accessToken);
            ACCESS_TOKEN = orderResponse.accessToken;
        }
    }

    IEnumerator GetAllBooks()
    {
        using UnityWebRequest request = UnityWebRequest.Get(BOOKS_URL);
        request.SetRequestHeader("Authorization", $"Bearer {ACCESS_TOKEN}");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            //Debug.log(request.downloadHandler.text);
            List<AllBooks> allBooks = JsonConvert.DeserializeObject<List<AllBooks>>(request.downloadHandler.text);

            foreach (AllBooks book in allBooks) 
            {
                Debug.Log(book.id);
                Debug.Log(book.name);
                Debug.Log(book.type);
                Debug.Log(book.available);
            }
        }
    }

    public class NewOrder
    {
        public int bookId;
        public string customerName;
    }
    public class NewOrderResponse
    {
        public bool created;
        public string orderId;
    }
    public class AllBooks {

        public int id;
        public string name;
        public string type;
        public string available;
    }

    public class GetAuthorization
    {
        public string clientName;
        public string clientEmail;
    }

    public class AuthResponse
    {
        public string accessToken;
    }

}
