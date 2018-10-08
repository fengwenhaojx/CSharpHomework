using System;
using System.Collections.Generic;
public class OrderDetails
{
    static int orders = 0;
    public int orderNumber;
    public string orderName;
    public string orderOwner;
    public OrderDetails()
    {
        OrderDetails.orders++;
        this.orderNumber = OrderDetails.orders;
    }
    public OrderDetails(string orName,string orOwner)
    {
        OrderDetails.orders++;
        this.orderNumber = OrderDetails.orders;
        this.orderName = orName;
        this.orderOwner = orOwner;
    }
    public void print()
    {
        Console.WriteLine(this.orderNumber);
        Console.WriteLine(this.orderName);
        Console.WriteLine(this.orderOwner);
    }
    public void change(string orName,string orOwner)
    {
        this.orderName = orName;
        this.orderOwner = orOwner;
    }
}
public class Order
{
    public List<OrderDetails> orderList = new List<OrderDetails>();
    public void PrintOrder()
    {
        Console.WriteLine("******************************************");
        for (int i=0;i<orderList.Count;i++)
        {
            orderList[i].print();
        }
        Console.WriteLine("******************************************");
    }
}
public class OrderService
{
    public void addOneOrder(ref Order order)
    {
        OrderDetails e = new OrderDetails();
        Console.WriteLine("请输入商品名称：");
        e.orderName = Console.ReadLine();
        Console.WriteLine("请输入客户名称：");
        e.orderOwner = Console.ReadLine();
        order.orderList.Add(e);
    }
    public void findOrderByNumber(Order order)
    {
        Console.WriteLine("请输入订单号：");
        int num = Int32.Parse(Console.ReadLine());
        for(int i=0;i<order.orderList.Count;i++)
        {
            if (order.orderList[i].orderNumber == num)
            {
                Console.WriteLine("******************************************");
                order.orderList[i].print();
                Console.WriteLine("******************************************");
                return;
            }
        }
        Console.WriteLine("没有此订单号的商品！");
    }
    public void ChangeByNumber(ref Order order)
    {
        Console.WriteLine("请输入订单号：");
        int num = Int32.Parse(Console.ReadLine());
        int i;
        for (i=0; i < order.orderList.Count; i++)
        {
            if (order.orderList[i].orderNumber == num)
            {
                Console.WriteLine("请重新输入商品名称：");
                order.orderList[i].orderName = Console.ReadLine();
                Console.WriteLine("请重新输入客户名称：");
                order.orderList[i].orderOwner = Console.ReadLine();
                return;
            }
        }
        Console.WriteLine("没有此订单号的商品！");
    }
    public void deleteByNumber(ref Order order)
    {
        Console.WriteLine("请输入订单号：");
        int num = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < order.orderList.Count; i++)
        {
            if (order.orderList[i].orderNumber == num)
            {
                order.orderList.RemoveAt(i);
                return;
            }
        }
        Console.WriteLine("没有此订单号的商品！");
    }
}
namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int od=1;
            Order order1 = new Order();
            OrderService os = new OrderService();
            while(od!=0)
            {
                switch(od)
                {
                    case 1:
                        os.addOneOrder(ref order1);
                        break;
                    case 2:
                        os.ChangeByNumber(ref order1);
                        break;
                    case 3:
                        os.deleteByNumber(ref order1);
                        break;
                    case 4:
                        os.findOrderByNumber(order1);
                        break;
                    case 5:
                        order1.PrintOrder();
                        break;
                }
                Console.WriteLine("1（添加商品）；2（修改商品）；3（删除商品）；4（查询商品）；5（打印订单）");
                od = Int32.Parse(Console.ReadLine());
            }
        }
    }
}
