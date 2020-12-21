namespace BmesRestApi.Models.Order
{
    public enum OrderStatus
    {
        Canceled =0,
        Closed = 1,
        Completed =2 ,
        OnHold = 3,
        PaymentReview =5,
        PendingPayment = 7,
        Submitted = 9
    }
}
