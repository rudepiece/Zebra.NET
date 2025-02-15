using System.Text.Json;  
using System.Threading.Tasks;
using Zebra.NET.Interfaces;
using RestSharp;  
using RestSharp.Authenticators;  
using Zebra.NET.Models;  
  
namespace Zebra.NET.Services  
{  
    public class BankingService : IBankingService
    {  
        private readonly RestClient _client;  
  
        public BankingService(Authenticator investecAuthenticator)
        {
            string baseurl = investecAuthenticator.BaseUrl;
            var options = new RestClientOptions(baseurl)  
            {  
                Authenticator = investecAuthenticator  
            };  
            _client = new RestClient(options);  
        }  
  
        public async Task<AccountsResponse> GetAccounts()  
        {  
            var request = new RestRequest("za/pb/v1/accounts", Method.Get);  
            var response = await _client.ExecuteAsync(request);  
            return JsonSerializer.Deserialize<AccountsResponse>(response.Content);  
        }  
  
        public async Task<AccountBalanceResponse> GetAccountBalance(string accountId)  
        {  
            var request = new RestRequest($"za/pb/v1/accounts/{accountId}/balance", Method.Get);  
            var response = await _client.ExecuteAsync(request);  
            return JsonSerializer.Deserialize<AccountBalanceResponse>(response.Content);  
        }  
  
        public async Task<AccountTransactionsResponse> GetAccountTransactions(string accountId, string fromDate = null, string toDate = null, string transactionType = null)  
        {  
            var request = new RestRequest($"za/pb/v1/accounts/{accountId}/transactions", Method.Get);  
            if (!string.IsNullOrEmpty(fromDate))  
            {  
                request.AddParameter("fromDate", fromDate);  
            }  
            if (!string.IsNullOrEmpty(toDate))  
            {  
                request.AddParameter("toDate", toDate);  
            }  
            if (!string.IsNullOrEmpty(transactionType))  
            {  
                request.AddParameter("transactionType", transactionType);  
            }  
            var response = await _client.ExecuteAsync(request);  
            return JsonSerializer.Deserialize<AccountTransactionsResponse>(response.Content);  
        }  
  
        public async Task<TransferResponse> TransferMultiple(TransferRequest transferRequest)  
        {  
            var request = new RestRequest($"za/pb/v1/accounts/{transferRequest.accountId}/transfermultiple", Method.Post);  
            request.AddJsonBody(transferRequest);  
            var response = await _client.ExecuteAsync(request);  
            return JsonSerializer.Deserialize<TransferResponse>(response.Content);  
        }  
  
        public async Task<BeneficiariesResponse> ListBeneficiaries()  
        {  
            var request = new RestRequest("za/pb/v1/accounts/beneficiaries", Method.Get);  
            var response = await _client.ExecuteAsync(request);  
            return JsonSerializer.Deserialize<BeneficiariesResponse>(response.Content);  
        }  
  
        public async Task<BeneficiaryCategoriesResponse> ListBeneficiaryCategories()  
        {  
            var request = new RestRequest("za/pb/v1/accounts/beneficiarycategories", Method.Get);  
            var response = await _client.ExecuteAsync(request);  
            return JsonSerializer.Deserialize<BeneficiaryCategoriesResponse>(response.Content);  
        }  
  
        public async Task<BeneficiaryPaymentResponse> MakeBeneficiaryPayment(string accountId, BeneficiaryPaymentRequest paymentRequest)  
        {  
            var request = new RestRequest($"za/pb/v1/accounts/{accountId}/paymultiple", Method.Post);  
            request.AddJsonBody(paymentRequest);  
            var response = await _client.ExecuteAsync(request);  
            return JsonSerializer.Deserialize<BeneficiaryPaymentResponse>(response.Content);  
        }  
  
        public async Task<DocumentsResponse> GetDocuments(string accountId, string fromDate, string toDate)  
        {  
            var request = new RestRequest($"za/pb/v1/accounts/{accountId}/documents", Method.Get);  
            request.AddParameter("fromDate", fromDate);  
            request.AddParameter("toDate", toDate);  
            var response = await _client.ExecuteAsync(request);  
            return JsonSerializer.Deserialize<DocumentsResponse>(response.Content);  
        }  
  
        public async Task<DocumentResponse> GetDocument(string accountId, string documentType, string documentDate)  
        {  
            var request = new RestRequest($"za/pb/v1/accounts/{accountId}/document/{documentType}/{documentDate}", Method.Get);  
            var response = await _client.ExecuteAsync(request);  
            return JsonSerializer.Deserialize<DocumentResponse>(response.Content);  
        }  
    }  
}  
