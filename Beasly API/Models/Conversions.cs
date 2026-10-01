using System.Text;
using System.Text.Json;

namespace Stuffle.Isaiah.Chapter23.Models
{
    public static class Conversions
    {
        public static StringContent CreateStringContentObject
            (System.Object objJsonRequestBody)
        {
            //Create a Stringcontent object from the JsonRequestBody object
            string strSerializedJsonRequestBody = 
                JsonSerializer.Serialize(objJsonRequestBody);
            StringContent objStringContent = new(strSerializedJsonRequestBody, Encoding.UTF8, "application/json");
            return objStringContent;
        }

        public static async Task<JsonDocument> CreateJsonDocumentObject
            (HttpResponseMessage objHttpResponseMessage)
        {
            // Create a JsonDocument object from the HttpResponseMessage object
            string strHttpResponseMessageContent = 
                await objHttpResponseMessage.Content.ReadAsStringAsync();
            JsonDocument objJsonDocument = 
                JsonDocument.Parse(strHttpResponseMessageContent);
            return objJsonDocument;
        }
    }
}
