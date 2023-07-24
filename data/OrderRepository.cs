namespace DeliveryService.data;

public class OrderRepository
{
    private readonly List<OrderModel> _orderList = new List<OrderModel>();

    // Create
    public void AddOrderToList(OrderModel order)
    {
        _orderList.Add(order);
    }

    // Read
    public List<OrderModel> GetOrderList() => new List<OrderModel>(_orderList);

    public OrderModel? GetOrderById(int orderNumber)
    {
        foreach (var order in _orderList)
        {
            if (order.OrderNumber == orderNumber)
            {
                return order;
            }
        }
        return null;
    }

    // Update
    public bool UpdateOrder(int orderNumber, OrderModel UpdatedOrder)
    {
        OrderModel? oldOrder = GetOrderById(orderNumber);
        if (oldOrder == null)
        {
            return false;
        }
        int index = _orderList.IndexOf(oldOrder);
        _orderList[index] = UpdatedOrder;
        return true;
    }

    // Delete
    public bool DeleteOrderFromList(int orderNumber)
    {
        return _orderList.Remove(GetOrderById(orderNumber));
    }

}