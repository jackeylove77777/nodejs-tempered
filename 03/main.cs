

var timer1 = new System.Timers.Timer();
//设置触发间隔时长
timer1.Interval = 1000;
//设置是否重复执行
timer1.AutoReset = true;
timer1.Elapsed += (sender,e)=>{
    System.Console.WriteLine("Internal call");
};
timer1.Enabled = true;

await Task.Delay(5000);
System.Console.WriteLine("you can enter any key to stop timer1");
System.Console.ReadKey();