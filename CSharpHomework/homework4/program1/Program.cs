using System;
//事件参数
public class RingEventArgs:EventArgs
{
    public string str="时间到了";
}
//事件委托
public delegate void RingEventHandler(object sender, RingEventArgs e);
public class Ring
{
    //事件申明
    public event RingEventHandler Ringing;
    public System.DateTime setTime;
    public void RingPre()
    {
        while(setTime>System.DateTime.Now)
        {
            System.Threading.Thread.Sleep(1000);
        }
        //通知外界
        if (Ringing != null)
        {
            RingEventArgs args = new RingEventArgs();
            Ringing(this, args);
        }
    }

}
namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.DateTime settime=new System.DateTime();
            Console.WriteLine("请设置闹钟将在多少时间后响起（用秒为单位）：");
            int s = Int32.Parse(Console.ReadLine());
            System.DateTime startTime = System.DateTime.Now;
            Console.WriteLine(s+"秒后将响铃：");
            settime = (startTime).AddSeconds(s);
            //注册事件
            var ring = new Ring();
            ring.setTime = settime;
            ring.Ringing += show;
            ring.RingPre();
        }
        //事件响应方法
        static void show(object sender,RingEventArgs e)
        {
            Console.WriteLine(""+e.str);
        }
    }
}
