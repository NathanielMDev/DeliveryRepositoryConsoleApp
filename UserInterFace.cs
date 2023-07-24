using DeliveryService.data;

namespace DeliveryService;

public class MenuInterface
{
    private readonly OrderRepository _orderList = new OrderRepository();

    private bool keepRunning = true;

    public void Run()
    {
        while (keepRunning)
        {
            ClearConsole();
            DisplayTitle();
            DisplayMenu();
            ExecuteUserInput(GetUserInput());
        }
    }

    private void DisplayMenu()
    {
        System.Console.WriteLine($"1 . . . Add New Order \t \t2 . . . Look Up Order");
        System.Console.WriteLine($"\n");
        System.Console.WriteLine($"3 . . . Look All Orders \t4 . . . Update Order");
        System.Console.WriteLine($"\n");
        System.Console.WriteLine($"5 . . . Delete Order \t \t6 . . . Exit");
        System.Console.WriteLine($"\n");

    }

    private string GetUserInput()
    {
        System.Console.Write("Enter your selection: ");
        string userInput = Console.ReadLine();
        return userInput;
    }

    private void ExecuteUserInput(string userInput)
    {
        switch (userInput)
        {
            case "1":
                AddNewOrder();
                break;
            case "2":
                LookUpOrder();
                break;
            case "3":
                DisplayAllOrders();
                break;
            case "4":
                UpdateOrder();
                break;
            case "5":
                DeleteOrder();
                break;
            case "6":
                keepRunning = false;
                break;
            default:
                System.Console.WriteLine("Invaild Character...Press any key to continue");
                Console.ReadKey();
                break;
        }
    }
    private void ClearConsole()
    {
        Console.Clear();
    }

    private void DisplayTitle()
    {
        Console.WriteLine($"\t_ Warner _\t_ Transit _\t_ Federal _\t_ Delivery _\t_ Service _");

        System.Console.WriteLine($"\n");
    }

    private void AddNewOrder()
    {
        System.Console.Write("\nPlease Enter Customer ID: ");
        int customerId = int.Parse(Console.ReadLine());
        System.Console.Write("\nPlease Enter Item Number: ");
        string itemNumber = Console.ReadLine();
        System.Console.Write("\nPlease Enter Item Quanity: ");
        int itemQuanity = int.Parse(Console.ReadLine());

        OrderModel order = new OrderModel(customerId, itemNumber, itemQuanity);

        _orderList.AddOrderToList(order);
        System.Console.WriteLine($"\n\tAwesome!\n \n\tHere's your new order:");
        DisplayOrder(order);
    }

    private void LookUpOrder()
    {
        System.Console.Write("Please Enter Order Id: ");
        int orderId = int.Parse(Console.ReadLine());

        OrderModel order = _orderList.GetOrderById(orderId);
        DisplayOrder(order);
    }

    private void DisplayOrder(OrderModel order)
    {
        System.Console.WriteLine($"\n\tCustomer ID: {order.CustomerId} \tOrder Number: {order.OrderNumber} \n\n \tItem Number: {order.ItemNumber} \tItem Quantity: {order.ItemQuanity} \n\n \tOrderStatus: {order.OrderStatus} \n\n \tDelivery Date: {order.DeliveryDate}\n");
        System.Console.ReadLine();
    }

    private void DisplayAllOrders()
    {
        List<OrderModel> displayOrders = _orderList.GetOrderList();
        foreach (OrderModel order in displayOrders)
        {
        System.Console.WriteLine($"\nOrder Number: {order.OrderNumber}");
        System.Console.WriteLine($"\n\tCustomer ID: {order.CustomerId} \tItem Number: {order.ItemNumber} \tItem Quantity: {order.ItemQuanity}\n\n\tOrderStatus: {order.OrderStatus} \n\n\tDelivery Date: {order.DeliveryDate}\n");
        }
        Console.Read();
    }

    private void UpdateOrder()
    {
        System.Console.Write("\nEnter Order Number: ");
        int orderNumber = int.Parse(Console.ReadLine());

        System.Console.Write("\nPlease Enter Updated Customer ID: ");
        int customerId = int.Parse(Console.ReadLine());
        System.Console.Write("\nPlease Enter Updated Item Number: ");
        string itemNumber = Console.ReadLine();
        System.Console.Write("\nPlease Enter Updated Item Quanity: ");
        int itemQuanity = int.Parse(Console.ReadLine());

        OrderModel order = new OrderModel(customerId, itemNumber, itemQuanity);
        _orderList.UpdateOrder(orderNumber, order);
        
        System.Console.WriteLine($"\nOrder Number: {order.OrderNumber} has been updated!");
        System.Console.WriteLine("\nPress any key to return to menu...");
        System.Console.ReadLine();
    }

    private void DeleteOrder()
    {
        System.Console.WriteLine("Enter Order Number you'd like to Delete: ");
        int orderNumber = int.Parse(Console.ReadLine());
        OrderModel deleted = _orderList.GetOrderById(orderNumber);
        DisplayOrder(deleted);
        _orderList.DeleteOrderFromList(orderNumber);
        System.Console.WriteLine($"\nYou've deleted Order Number: {orderNumber}");
        System.Console.WriteLine($"\nPress any key to return to Menu");
        Console.ReadLine();
    }

}
