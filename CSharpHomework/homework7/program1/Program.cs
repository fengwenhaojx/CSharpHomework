using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace program1
{
    [Serializable]
    public class OrderDetails
    {
        public int orderNumber;
        public string orderName;
        public string orderOwner;
        public int orderMoney;
        public OrderDetails(int num, string name, string owner, int money)
        {

            orderNumber = num;
            orderName = name;
            orderOwner = owner;
            orderMoney = money;
        }
        public void print()
        {
            Console.WriteLine(this.orderNumber);
            Console.WriteLine(this.orderName);
            Console.WriteLine(this.orderOwner);
            Console.WriteLine(this.orderMoney);
        }
        public void change(int num, string orName, string orOwner, int orMoney)
        {
            this.orderNumber = num;
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
        public void addOneOrder(ref Order order,OrderDetails e)
        {
            for(int i=0;i<order.orderList.Count;i++)
            {
                if (e.orderNumber == order.orderList[i].orderNumber)
                    throw new Exception($"orderNumber already exist!");
            }
            order.orderList.Add(e);
        }
        public OrderDetails findOrderByNumber(Order order,int num)
        {
            for (int i = 0; i < order.orderList.Count; i++)
            {
                if (order.orderList[i].orderNumber == num)
                {
                    return order.orderList[i];
                }
            }
            throw new Exception($"ordernumber doesn't exist!");
            
        }
        public List<OrderDetails> findOrderByName(Order order,string name)
        {
            var m = from n in order.orderList
                    where n.orderName.Equals(name)
                    select n;
            if (m == null) throw new Exception($"ordername doesn't exist!");
            else
            {
                return (m as List<OrderDetails>);
            }
        }
        public List<OrderDetails> findOrderByOwner(Order order,string owner)
        {
            var m = from n in order.orderList
                    where n.orderOwner.Equals(owner)
                    select n;
            if (m == null) throw new Exception($"owner doesn't exist!");
            else
            {
                return (m as List<OrderDetails>);
            }
        }
        public List<OrderDetails> findOrderOver10000(Order order)
        {
            var m = from n in order.orderList
                    where n.orderMoney >= 10000
                    select n;
            if (m == null) throw new Exception($"no goods' price over 10000!");
            else return (m as List<OrderDetails>);
        }
        public void ChangeByNumber(ref Order order,int num,OrderDetails e)
        {
            for (int i = 0; i < order.orderList.Count; i++)
            {
                if (order.orderList[i].orderNumber == num)
                {
                    order.orderList[i] = e;
                    return;
                }
            }
            throw new Exception($"orderNumber doesn't exist!");
        }
        public void deleteByNumber(ref Order order,int num)
        {
            for (int i = 0; i < order.orderList.Count; i++)
            {
                if (order.orderList[i].orderNumber == num)
                {
                    order.orderList.RemoveAt(i);
                    return;
                }
            }
            throw new Exception($"orderNumber doesn't exist!");
        }
        //导出XML文件
        public void Export(Order order)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(Order));
            string xmlFileName = "sss.xml";
            xmlSerialize(xmlser, xmlFileName, order);
        }
        private void xmlSerialize(XmlSerializer ser, string fileName, object obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();

        }
        //导入XML文件
        public void Import(ref Order order)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(Order));
            order = xmlDeserialize(xmlser, "sss.xml") as Order;
        }
        private object xmlDeserialize(XmlSerializer ser, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            object obj = ser.Deserialize(fs);
            fs.Close();
            return obj;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            OrderService service = new OrderService();
            OrderDetails a = new OrderDetails(1, "fish", "feng", 234);
            OrderDetails b = new OrderDetails(2, "fish", "feng", 234);
            service.addOneOrder(ref order, a);
            service.addOneOrder(ref order, b);
            //service.findOrderByNumber(order, 1).print();
            order.PrintOrder();
            
        }
    }
}

