namespace investec;

public class AccountsResponse
{
    public Data data { get; set; }
    public Links links { get; set; }
    public Meta meta { get; set; }
}

public class Data
{
    public Accounts[] accounts { get; set; }
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
    public string AccountId { get; set; }
    public string AccountNumber { get; set; }
    public string AccountName { get; set; }
    public string ReferenceName { get; set; }
    public string ProductName { get; set; }
    public bool KycCompliant { get; set; }
    public string ProfileId { get; set; }
}

public class AccountBalanceResponse
{
    public AccountBalance Data { get; set; }
}

public class AccountBalance
{
    public string AccountId { get; set; }
    public decimal CurrentBalance { get; set; }
    public decimal AvailableBalance { get; set; }
    public string Currency { get; set; }
    public string? AccountName { get; set; }
}

public class AccountTransactionsResponse
{
    public List<Transaction> Transactions { get; set; }
}

public class Transaction
{
    public string AccountId { get; set; }
    public string Type { get; set; }
    public string TransactionType { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string CardNumber { get; set; }
    public int PostedOrder { get; set; }
    public string PostingDate { get; set; }
    public string ValueDate { get; set; }
    public string ActionDate { get; set; }
    public string TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public decimal RunningBalance { get; set; }
}

public class TransferRequest
{
    public List<Transfer> TransferList { get; set; }
}

public class Transfer
{
    public string BeneficiaryAccountId { get; set; }
    public decimal Amount { get; set; }
    public string MyReference { get; set; }
    public string TheirReference { get; set; }
}

public class TransferResponse
{
    // Define properties based on the response  
}

public class BeneficiariesResponse
{
    public List<Beneficiary> Beneficiaries { get; set; }
}

public class Beneficiary
{
    public string BeneficiaryId { get; set; }

    public string Name { get; set; }
    // Add other properties as needed  
}

public class BeneficiaryCategoriesResponse
{
    public List<BeneficiaryCategory> Categories { get; set; }
}

public class BeneficiaryCategory
{
    public string CategoryId { get; set; }

    public string Name { get; set; }
    // Add other properties as needed  
}

public class BeneficiaryPaymentRequest
{
    public List<Payment> PaymentList { get; set; }
}

public class Payment
{
    public string BeneficiaryId { get; set; }
    public decimal Amount { get; set; }
    public string MyReference { get; set; }
    public string TheirReference { get; set; }
}

public class BeneficiaryPaymentResponse
{
    // Define properties based on the response  
}

public class DocumentsResponse
{
    public List<Document> Documents { get; set; }
}

public class Document
{
    public string DocumentId { get; set; }
    public string Type { get; set; }

    public string Date { get; set; }
    // Add other properties as needed  
}

public class DocumentResponse
{
    // Define properties based on the response  
}