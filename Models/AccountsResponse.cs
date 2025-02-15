namespace Zebra.NET;

public class AccountsResponse
{
    public Data data { get; set; }
    public Links links { get; set; }
    public Meta meta { get; set; }
}

public class Data
{
    public List<Accounts> accounts { get; set; }
}

public class Accounts
{
    public string accountId { get; set; }
    public string accountNumber { get; set; }
    public string accountName { get; set; }
    public string referenceName { get; set; }
    public string productName { get; set; }
    public bool kycCompliant { get; set; }
    public string profileId { get; set; }
    public string profileName { get; set; }
}

public class Links
{
    public string self { get; set; }
}

public class Meta
{
    public int totalPages { get; set; }
}

public class Account
{
    public string accountId { get; set; }
    public string accountNumber { get; set; }
    public string accountName { get; set; }
    public string referenceName { get; set; }
    public string productName { get; set; }
    public bool kycCompliant { get; set; }
    public string profileId { get; set; }
}

public class AccountBalanceResponse
{
    public AccountData data { get; set; }
    public Links links { get; set; }
    public Meta meta { get; set; }
}

public class AccountData
{
    public string accountId { get; set; }
    public decimal currentBalance { get; set; }
    public decimal availableBalance { get; set; }
    public decimal budgetBalance { get; set; }
    public decimal straightBalance { get; set; }
    public decimal cashBalance { get; set; }
    public string currency { get; set; }
}

public class AccountTransactionsResponse
{
    public List<Transaction> transactions { get; set; }
}

public class Transaction
{
    public string accountId { get; set; }
    public string type { get; set; }
    public string transactionType { get; set; }
    public string status { get; set; }
    public string description { get; set; }
    public string cardNumber { get; set; }
    public int postedOrder { get; set; }
    public string postingDate { get; set; }
    public string valueDate { get; set; }
    public string actionDate { get; set; }
    public string transactionDate { get; set; }
    public decimal amount { get; set; }
    public decimal runningBalance { get; set; }
}

public class TransferRequest
{
    public string accountId { get; set; }
    public List<Transfer> transferList { get; set; }
}

public class Transfer
{
    public string beneficiaryAccountId { get; set; }
    public decimal amount { get; set; }
    public string myReference { get; set; }
    public string theirReference { get; set; }
}

public class TransferResponse
{
    public TransferResponseData data { get; set; }
    public Links Links { get; set; }
    public Meta Meta { get; set; }
}

public class TransferResponseData
{
    public List<TransferResult> TransferResponses { get; set; }
    public string ErrorMessage { get; set; }
}

public class TransferResult
{
    public string PaymentReferenceNumber { get; set; }
    public string PaymentDate { get; set; }
    public string Status { get; set; }
    public string BeneficiaryName { get; set; }
    public string BeneficiaryAccountId { get; set; }
    public bool AuthorisationRequired { get; set; }
}

public class BeneficiariesResponse
{
    public List<Beneficiary> beneficiaries { get; set; }
}

public class Beneficiary
{
    public string beneficiaryId { get; set; }
    public string name { get; set; }
}

public class BeneficiaryCategoriesResponse
{
    public List<BeneficiaryCategory> categories { get; set; }
}

public class BeneficiaryCategory
{
    public string categoryId { get; set; }
    public string name { get; set; }
}

public class BeneficiaryPaymentRequest
{
    public List<Payment> paymentList { get; set; }
}

public class Payment
{
    public string beneficiaryId { get; set; }
    public decimal amount { get; set; }
    public string myReference { get; set; }
    public string theirReference { get; set; }
}

public class BeneficiaryPaymentResponse
{
    // Define properties based on the response  
}

public class DocumentsResponse
{
    public List<Document> documents { get; set; }
}

public class Document
{
    public string documentId { get; set; }
    public string type { get; set; }
    public string date { get; set; }
}

public class DocumentResponse
{
    // Define properties based on the response  
}
