﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using program1;
using Microsoft.VisualBasic;
namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            conn.Open();
            service.DataSetToList(ref order, service.DataBaseToSet(conn));
            this.InListBox1();

        }
        
        private void InListBox1()
        {
            foreach(OrderDetails s in order.orderList)
            {
                listBox1.Items.Add(s.orderName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                form2.ShowDialog();
                OrderDetails newOrder = new OrderDetails(Int32.Parse(form2.textBox1.Text)
                    , form2.textBox2.Text
                    , form2.textBox3.Text
                    , Int32.Parse(form2.textBox4.Text)
                    ,form2.textBox5.Text);
                service.addOneOrder(ref order, newOrder);
                service.InseartToDatabase(conn, newOrder);
                listBox1.Items.Add(newOrder.orderName);
            }
            catch(Exception ex)
            {
                textBox6.Text = ex.Message;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                OrderDetails dd = order.orderList[listBox1.SelectedIndex];
                string s = dd.orderNumber
                    +"\r\n"+dd.orderName
                    +"\r\n"+dd.orderOwner
                    +"\r\n"+dd.orderMoney
                    +"\r\n" + dd.phoneNumber;

                textBox5.Text = s;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                form2.ShowDialog();
                for (int i = 0; i < order.orderList.Count; i++)
                {
                    if (order.orderList[i].orderNumber == long.Parse(form2.textBox1.Text))
                    {
                        listBox1.Items.RemoveAt(i);
                    }
                }
                service.deleteByNumber(ref order, long.Parse(form2.textBox1.Text));
                service.deleteByNumberInDatabase(long.Parse(form2.textBox1.Text), conn);
            }
            catch(Exception ex)
            {
                textBox6.Text = ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                form2.ShowDialog();
                OrderDetails dd = service.findOrderByNumber(order, long.Parse(form2.textBox1.Text));
                string s = dd.orderNumber
                    + "\r\n" + dd.orderName
                    + "\r\n" + dd.orderOwner
                    + "\r\n" + dd.orderMoney
                    + "\r\n" + dd.phoneNumber;
                for(int i=0;i<order.orderList.Count;i++)
                {
                    if(order.orderList[i].orderNumber== long.Parse(form2.textBox1.Text))
                    {
                        listBox1.SelectedIndex = i;
                        break;
                    }
                }
                textBox5.Text = s;
            }
            catch (Exception ex)
            {
                textBox6.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                form2.ShowDialog();
                OrderDetails newOrder = new OrderDetails(Int32.Parse(form2.textBox1.Text)
                    , form2.textBox2.Text
                    , form2.textBox3.Text
                    , Int32.Parse(form2.textBox4.Text)
                    ,form2.textBox5.Text);
                service.ChangeByNumber(ref order,order.orderList[listBox1.SelectedIndex].orderNumber, newOrder);
                service.ChangeByNumberInDatabase(conn, order.orderList[listBox1.SelectedIndex].orderNumber, newOrder);
                listBox1.Items[listBox1.SelectedIndex] = form2.textBox2.Text;
            }
            catch (Exception ex)
            {
                textBox6.Text = ex.Message;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
