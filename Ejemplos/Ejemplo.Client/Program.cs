// See https://aka.ms/new-console-template for more information
using Ejemplo.Client.Model;

using Newtonsoft.Json;

using RestSharp;

var client = new RestClient("http://localhost:9090/api");
//var request = new RestRequest("dummies", Method.Get);
//request.AddHeader("Accept", "appication/xml");
//Console.WriteLine("RAW Response(xml): " +
//    client.ExecuteAsync(request).Result.Content);

//Console.WriteLine("======================");

//var request2 = new RestRequest("dummies", Method.Get);
//request2.AddHeader("Accept", "appication/json");
//Console.WriteLine("RAW Response(json): " +
//    client.ExecuteAsync(request).Result.Content);

//Console.WriteLine("======================");


//Dummy? dummy = client.ExecuteAsync<Dummy?>(request).Result.Data;
//Console.WriteLine(dummy);

//Console.WriteLine("======================");

//var request3 = new RestRequest("dummies", Method.Post);
//request3.RequestFormat = DataFormat.Json;
//request3.AddBody(new Dummy() { Text = "New Dummy Object" });
//var dummyResponse = await client.ExecuteAsync<Dummy?>(request3);
//Dummy? dummy3 = dummyResponse.Data;
//Console.WriteLine(dummy3);

var request4 = new RestRequest("dummies", Method.Post);
request4.RequestFormat = DataFormat.Json;
request4.AddJsonBody(new { Text = "New Anonymous Dummy Object" });
var anonymousDummy = JsonConvert.DeserializeAnonymousType(
    client.ExecuteAsync(request4).Result.Content, new { Id = 0, Text = "" });
Console.WriteLine(anonymousDummy.Text);