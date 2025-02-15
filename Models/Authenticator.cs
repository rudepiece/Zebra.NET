using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace Zebra.NET.Models;

public class Authenticator : IAuthenticator
{
    private string _accessToken;
    public string BaseUrl { get; private set; }
    
    public ValueTask Authenticate(IRestClient client, RestRequest request)
    {
        GetAccessToken(_clientId,_clientSecret);
        request.AddHeader(Constants.AuthorizationHeader, $"Bearer {_accessToken}");
        
        return ValueTask.CompletedTask;
    }
    
    public Authenticator(IConfiguration config, bool sandbox, string? clientId, string? clientSecret, string? apiKey)
    {
        _clientId = clientId ?? Environment.GetEnvironmentVariable(Constants.ClientIdSection);
        _clientSecret = clientSecret ?? Environment.GetEnvironmentVariable(Constants.ClientSecretSection);
        ApiKey = apiKey ?? Environment.GetEnvironmentVariable(Constants.ApiKeySection);
        BaseUrl = sandbox ? Constants.SandboxUrl : Constants.BaseUrl;
        GetAccessToken(_clientId, _clientSecret);
    }
    
    public Authenticator(IConfiguration config, bool sandbox)
    {
        _clientId = config[Constants.ClientIdSection] ?? Environment.GetEnvironmentVariable(Constants.ClientIdSection);
        _clientSecret = config[Constants.ClientSecretSection] ?? Environment.GetEnvironmentVariable(Constants.ClientSecretSection);
        ApiKey = config[Constants.ApiKeySection] ?? Environment.GetEnvironmentVariable(Constants.ApiKeySection);
        BaseUrl = sandbox ? Constants.SandboxUrl : Constants.BaseUrl;
        GetAccessToken(_clientId, _clientSecret);
    }



    private void GetAccessToken(string clientId, string clientSecret)
    {
        var tokenClient = new RestClient(BaseUrl);
        var authZRequest = new RestRequest(Constants.TokenEndpoint, Method.Post);

        authZRequest.Authenticator = new HttpBasicAuthenticator(clientId, clientSecret);
        authZRequest.AddHeader(Constants.ApiKeyHeader, ApiKey);

        authZRequest.AddParameter(Constants.GrantTypeParam, Constants.ClientCredentials, ParameterType.GetOrPost);

        var authZResponse = tokenClient.Execute(authZRequest);

        var authResponse = JsonSerializer.Deserialize<AuthenticationResponse>(authZResponse.Content);

        _accessToken = authResponse.access_token;
    }

    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string ApiKey;
}