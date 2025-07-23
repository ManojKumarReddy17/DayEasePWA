namespace Domain.DomainModels
{
    public class PlaceOrderResponseModel
    {
        public string OrderId { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
