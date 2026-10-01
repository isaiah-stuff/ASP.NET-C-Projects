using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Stuffle.Isaiah.Chapter23.Models;
using Elfie.Serialization;

namespace Stuffle.Isaiah.Chapter23.Pages;
[BindProperties]
public class REST_API_ExampleModel : PageModel
{
    private readonly IHttpClientFactory IHttpClientFactory;
    public ChatWithCustomerService…Model(IHttpClientFactory IHCF)
    {
        IHttpClientFactory = IHCF;
    }

    public string MessageColor;
    public string Message;
    public string Answer;

    public string Question { get; set; }

    public void OnGet()
    {
        // Set the message.
        MessageColor = "Green";
        Message = "Please ask your question and click Ask.";
    }

    public async Task OnPostAskAsync()
    {

        // Set the base endpoint URL.
        string strBaseEndpointUrl = "https://api.openai.com/v1/";

        // Create the HttpClient object.
        HttpClient objHttpClient = IHttpClientFactory
                        .CreateClient("SportsPlayClientCustomerService");

        // Define the JsonRequestBody object.
        var objJsonRequestBody = new
        {
            model = "gpt-4o",
            messages = new[]
                        {
                    new { role = "system", content = "You are a helpful
                        customer service representative. Only answer
                        questions about clothing, footwear, and sports
                        equipment. Provide the source of your answer when
                        possible." },
                    new { role = "user", content = Question }
            }
        };

        // Create the StringContent object.
        using StringContent objStringContent = Conversions
            .CreateStringContentObject(objJsonRequestBody);

        // Submit the user's question.
        using HttpResponseMessage objHttpResponseMessage = await
            objHttpClient.PostAsync
            ($"{strBaseEndpointUrl}chat/completions", objStringContent);

        // Create The JsonDocument object.
        using JsonDocument objJsonDocument = await Conversions
            .CreateJsonDocumentObject(objHttpResponseMessage);

        // Get the answer from the JsonDocument object.
        Answer = objJsonDocument.RootElement
            .GetProperty("choices")[0].GetProperty("message")
            .GetProperty("content").GetString();

        // Set the message.
        MessageColor = "Green";
        Message = "Please feel free to refine your question and click Ask.";

    }
}
