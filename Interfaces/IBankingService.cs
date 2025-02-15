namespace Zebra.NET.Interfaces;

public interface IBankingService
{
    public Task<AccountsResponse> GetAccounts();
    public Task<AccountBalanceResponse> GetAccountBalance(string accountId);
    public Task<AccountTransactionsResponse> GetAccountTransactions(string accountId, string fromDate = null, string toDate = null, string transactionType = null);
    public Task<TransferResponse> TransferMultiple(TransferRequest transferRequest);
    public Task<BeneficiariesResponse> ListBeneficiaries();
    public Task<BeneficiaryCategoriesResponse> ListBeneficiaryCategories();
    public Task<BeneficiaryPaymentResponse> MakeBeneficiaryPayment(string accountId, BeneficiaryPaymentRequest paymentRequest);
    public Task<DocumentsResponse> GetDocuments(string accountId, string fromDate, string toDate);
    public Task<DocumentResponse> GetDocument(string accountId, string documentType, string documentDate);
}