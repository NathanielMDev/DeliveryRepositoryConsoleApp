namespace DeliveryService.data;

public enum OrderStatus { OrderReceived, Scheduled, EnRoute, Complete, Canceled }

public class OrderModel
{
    private static int OrderCount = 0;

    public OrderModel(int customerId, string itemNumber, int itemQuanity)
    {
        OrderCount++;
        OrderNumber = OrderCount;
        CustomerId = customerId;
        OrderDate = DateTime.Now;
        DeliveryDate = DateTime.Now.AddDays(5);
        ItemNumber = itemNumber;
        ItemQuanity = itemQuanity;
    }

    // Properties 
    public int OrderNumber { get; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string ItemNumber { get; set; }
    public int ItemQuanity { get; set; }
    public OrderStatus OrderStatus { get; set; }
}