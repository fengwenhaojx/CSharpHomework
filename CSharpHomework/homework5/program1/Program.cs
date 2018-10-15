using System;
using System.Collections.Generic;
using System.Linq;
public class OrderDetails
{
    static int orders = 0;
    public int orderNumber;
    public string orderName;
    public string orderOwner;
    public int orderMoney;
    public OrderDetails()
    {
        OrderDetails.orders++;
        this.orderNumber = OrderDetails.orders;
    }
    public OrderDetails(string orName, string orOwner,int orMoney)
    {
        OrderDetails.orders++;
        this.orderNumber = OrderDetails.orders;
        this.orderName = orName;
        this.orderOwner = orOwner;
        this.orderMoney = orMoney;
    }
    public void print()
    {
        Console.WriteLine(this.orderNumber);
        Console.WriteLine(this.orderName);
        Console.WriteLine(this.orderOwner);
        Console.WriteLine(this.orderMoney);
    }
    public void change(string orName, string orOwner,int orMoney)
    {
        this.orderName = orName;
        this.orderOwner = orOwner;
        this.orderMoney = orMoney;
    }
}
public class Order
{
    public List<OrderDetails> orderList = new List<OrderDetails>();
    public void PrintOrder()
    {
        Console.WriteLine("******************************************");
        for (int i = 0; i < orderList.Count; i++)
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
        Console.WriteLine("请输入商品金额：");
        e.orderMoney = Int32.Parse(Console.ReadLine());
        order.orderList.Add(e);
    }
    public void findOrderByNumber(Order order)
    {
        Console.WriteLine("请输入订单号：");
        int num = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < order.orderList.Count; i++)
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
    public void findOrderByName(Order order)
    {
        Console.WriteLine("请输入需查询商品的名称：");
        string orName = Console.ReadLine();
        var m = from n in order.orderList
                where n.orderName.Equals(orName)
                select n;
        int x = 0;
        foreach (var i in m)
        {
            x++;
        }
        if (x == 0)
        {
            Console.WriteLine("没有此名称的商品！");
            return;
        }
        Console.WriteLine("******************************************");
        foreach (var i in m)
        {
            i.print();
        }
        Console.WriteLine("******************************************");
    }
    public void findOrderByOwner(Order order)
    {
        Console.WriteLine("请输入客户的名称：");
        string orOwner = Console.ReadLine();
        var m = from n in order.orderList
                where n.orderOwner.Equals(orOwner)
                select n;
        int x = 0;
        foreach (var i in m)
        {
            x++;
        }
        if (x == 0)
        {
            Console.WriteLine("没有此客户的商品！");
            return;
        }
        Console.WriteLine("******************************************");
        foreach (var i in m)
        {
            i.print();
        }
        Console.WriteLine("******************************************");
    }
    public void findOrderOver10000(Order order)
    {
        var m = from n in order.orderList
                where n.orderMoney>=10000
                select n;
        int x = 0;
        foreach (var i in m)
        {
            x++;
        }
        if (x == 0)
        {
            Console.WriteLine("没有超过10000的商品！");
            return;
        }
        Console.WriteLine("******************************************");
        foreach (var i in m)
        {
            i.print();
        }
        Console.WriteLine("******************************************");
    }
    public void ChangeByNumber(ref Order order)
    {
        Console.WriteLine("请输入订单号：");
        int num = Int32.Parse(Console.ReadLine());
        int i;
        for (i = 0; i < order.orderList.Count; i++)
        {
            if (order.orderList[i].orderNumber == num)
            {
                Console.WriteLine("请重新输入商品名称：");
                order.orderList[i].orderName = Console.ReadLine();
                Console.WriteLine("请重新输入客户名称：");
                order.orderList[i].orderOwner = Console.ReadLine();
                Console.WriteLine("请重新输入商品金额：");
                order.orderList[i].orderMoney = Int32.Parse(Console.ReadLine());
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
            int od = 1;
            Order order1 = new Order();
            OrderService os = new OrderService();
            while (od != 0)
            {
                switch (od)
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
                    case 6:
                        os.findOrderByName(order1);
                        break;
                    case 7:
                        os.findOrderByOwner(order1);
                        break;
                    case 8:
                        os.findOrderOver10000(order1);
                        break;
                }
                Console.WriteLine("1（添加商品）；2（修改商品）；3（删除商品）；4（按订单号查询）；5（打印订单）；6（按名称查询）；7（按客户查询）；8（查找金额大于一万的订单）");
                od = Int32.Parse(Console.ReadLine());
            }
        }
    }
}
