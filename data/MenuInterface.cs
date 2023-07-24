using DeliveryService.data;
namespace Menu.Interface;

public class MenuInterFace
{
    private readonly OrderRepository _orderRepository;

    public MenuInterFace(OrderRepository repository)
    {
        _orderRepository = repository;
    }

}