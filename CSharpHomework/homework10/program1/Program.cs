﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
namespace program1
{
    [Serializable]
    public class OrderDetails
    {
        public long orderNumber;//orderDate+behindNum
        public int orderBehindNum;//流水号
        public string orderName;
        public string orderOwner;
        public int orderMoney;
        public string phoneNumber;
        public string orderDate;//日期
        public OrderDetails()
        {

        }
        public OrderDetails(int num, string name, string owner, int money,string phone)
        {
            if(phone.Length!=11)
            {
                throw new Exception($"手机号码位数不为11！");
            }
            else
            {
                orderDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                long date = long.Parse(orderDate);
                orderBehindNum = num;
                orderNumber = date * 1000 + orderBehindNum;
                orderName = name;
                orderOwner = owner;
                orderMoney = money;
                phoneNumber = phone;
            }
            
        }
        public OrderDetails(long orderNumber,int orderBehindNum,string orderName,string orderOwner,int orderMoney,string phoneNumber,string orderDate)
        {
            this.orderNumber = orderNumber;
            this.orderBehindNum = orderBehindNum;
            this.orderName = orderName;
            this.orderOwner = orderOwner;
            this.orderMoney = orderMoney;
            this.phoneNumber = phoneNumber;
            this.orderDate = orderDate;
        }
        public void print()
        {
            Console.WriteLine(this.orderNumber);
            Console.WriteLine(this.orderName);
            Console.WriteLine(this.orderOwner);
            Console.WriteLine(this.orderMoney);
            Console.WriteLine(this.phoneNumber);
        }
        public void change(int num, string orName, string orOwner, int orMoney,string phone,string date)
        {
            this.orderNumber = Int32.Parse(this.orderDate)*1000+num;
            this.orderBehindNum = num;
            this.orderName = orName;
            this.orderOwner = orOwner;
            this.orderMoney = orMoney;
            this.phoneNumber = phone;
            this.orderDate = date;
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
        public OrderDetails findOrderByNumber(Order order,long num)
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
        public void ChangeByNumber(ref Order order,long num,OrderDetails e)
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
        public void deleteByNumber(ref Order order,long num)
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
        public void html(string xslName,string xmlName)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslName);
            XPathDocument xDoc = new XPathDocument(xmlName);
            XmlTextWriter xtWriter = new XmlTextWriter("myHtml.html", null);
            xslt.Transform(xDoc, xtWriter);
            xtWriter.Close();
            
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
        //将一个orderDetail导入数据库
        public void InseartToDatabase(MySqlConnection connection,OrderDetails s)
        {
            String sql = "INSERT INTO orderCase VALUES ("
                        + s.orderNumber.ToString() + ','
                        + '\'' + s.orderName + '\'' + ','
                        + '\'' + s.orderOwner + '\'' + ','
                        + s.orderMoney.ToString() + ','
                        + '\'' + s.phoneNumber + '\'' + ','
                        + '\'' + s.orderDate + '\'' +
                        ");";
            MySqlCommand sqlInsert = new MySqlCommand(sql, connection);
            sqlInsert.ExecuteNonQuery();
            sqlInsert.Dispose();
        }
        public void deleteByNumberInDatabase(long num, MySqlConnection connection)
        {
            String sql = "DELETE FROM ordercase WHERE orderNumber = " + num.ToString() + ";";
            MySqlCommand sqlDelete = new MySqlCommand(sql, connection);
            sqlDelete.ExecuteNonQuery();
            sqlDelete.Dispose();
        }
        public void ChangeByNumberInDatabase(MySqlConnection connection, long num, OrderDetails e)
        {
            String sql = "UPDATE ordercase SET orderName=\'"+e.orderName
                +"\',orderOwner=\'"+e.orderOwner
                +"\',orderMoney=\'"+e.orderMoney.ToString()
                +"\',phoneNumber=\'"+e.phoneNumber
                +"\',orderDate=\'"+e.orderDate+"\' WHERE orderNumber = \'" + num.ToString() + "\';";
            MySqlCommand sqlChange = new MySqlCommand(sql, connection);
            sqlChange.ExecuteNonQuery();
            sqlChange.Dispose();
        }
        //数据库中数据表填充DataSet
        public DataSet DataBaseToSet(MySqlConnection conn)
        {
            String sql = "SELECT * FROM ordercase";
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
            {
                using (DataSet ds = new DataSet())
                {
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
        }
        //将DataSet导入orderList
        public void DataSetToList(ref Order order,DataSet dataSet)
        { 
            DataRow[] rows = dataSet.Tables[0].Select();
            foreach(DataRow row in rows)
            {
                OrderDetails od = new OrderDetails((long)row[0], (int)((long)row[0] % 1000), (string)row[1], (string)row[2], (int)row[3], (string)row[4], (string)row[5]);
                this.addOneOrder(ref order, od);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            OrderService service = new OrderService();
            OrderDetails a = new OrderDetails(1, "fish", "feng", 234, "18398581560");
            OrderDetails b = new OrderDetails(2, "fish", "feng", 234, "18398581560");
            //service.addOneOrder(ref order, a);
            //service.addOneOrder(ref order, b);
            //string username="";
            //string password="";
            String connetStr = "server=127.0.0.1;port=3306;user=root;password=anjiaxin123; database=base1;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                /*
                foreach (OrderDetails s in order.orderList)
                {
                    service.InseartToDatabase(conn, s);           
                }*/

                service.DataSetToList(ref order, service.DataBaseToSet(conn));
                service.deleteByNumber(ref order, 20181129002);
                service.deleteByNumberInDatabase(20181129002, conn);
                order.PrintOrder();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            /*
            
            service.Export(order);
            service.html(".../.../ksfdjkas.xsl", "sss.xml");
            //service.findOrderByNumber(order, 1).print();

            */
        }
    }
}

