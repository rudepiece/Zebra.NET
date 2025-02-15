namespace Zebra.NET;

public class AuthenticationResponse
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public int expires_in { get; set; }
    public string scope { get; set; }
}

public class AuthorisationResponse
{
    public string auth_token { get; set; }
}