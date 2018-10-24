using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
namespace program2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Order order = new Order();
            OrderService service = new OrderService();
            List<OrderDetails> modelList = new List<OrderDetails>();
            OrderDetails od1 = new OrderDetails("fish", "feng", 22);
            ;
            modelList.Add(od1);
            
            service.addOneOrder(ref order);
            Assert.AreEqual(order.orderList, modelList);
        }
    }
}
