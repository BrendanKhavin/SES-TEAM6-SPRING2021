using System.Reflection.Emit;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Reflection.Metadata;
using System.Net;
using System.IO;
using System;
using System.Collections.Specialized;
using System.Text.Json;
namespace PROJ.Services
{
  public class RecommendService
  {
    public string[] GetRecommendation(string user_id)
    {

      string url = "http://localhost:8000/recommend/" + user_id;
      // string url = "https://recommendations-r-us.herokuapp.com/recommend/" + user_id;

      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      string result = "";

      using (var response = (HttpWebResponse)(request.GetResponse()))
      {
        using (var responseStream = response.GetResponseStream())
        {
          using (var sr = new StreamReader(responseStream))
          {
            result =  sr.ReadToEnd();
          }
        }
      }

      var codes = JsonSerializer.Deserialize<string[]>(result);

      return codes;
    }
  }
}
