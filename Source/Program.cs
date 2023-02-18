using System.Diagnostics;
using System.Text;
using static System.Console;


//Thread t = new(() => { });



//// ThreadPool
//ThreadPool.QueueUserWorkItem((o) => { 

//});




// ThreadPool
// Asynchronous method
// Cancellation token





//DoSomething del = () => {
//    WriteLine(Thread.CurrentThread.ManagedThreadId);
//    WriteLine(Thread.CurrentThread.IsThreadPoolThread);
//};


//del.BeginInvoke(null, null);


//delegate void DoSomething();





//// WaitCallback
//ThreadPool.QueueUserWorkItem(WaitCallbackMethod);
//ThreadPool.QueueUserWorkItem(WaitCallbackMethod, "xxx");





//var student = new Student { FirstName = "Leyla", LastName = "Shefiyeva" };
//ThreadPool.QueueUserWorkItem(PrintStudent, student, false);


//ThreadPool.GetMinThreads(out int workerThreads, out int cPortThreads);
//WriteLine(workerThreads);
//WriteLine(cPortThreads);


//ThreadPool.GetMaxThreads(out int workerThreads, out int cPortThreads);
//WriteLine(workerThreads);
//WriteLine(cPortThreads);


//ThreadPool.GetAvailableThreads(out int workerThreads, out int cPortThreads);
//WriteLine(workerThreads);
//WriteLine(cPortThreads);


//WriteLine(ThreadPool.ThreadCount);




//ReadLine();













//void PrintStudent(Student student)
//{
//    WriteLine(student.FirstName);
//    WriteLine(student.LastName);
//}


//void WaitCallbackMethod(object? state)
//{
//    WriteLine("-----------------");
//    WriteLine(Thread.CurrentThread.ManagedThreadId);
//    WriteLine(state);
//    WriteLine(Thread.CurrentThread.IsThreadPoolThread);
//    WriteLine(Thread.CurrentThread.IsBackground);
//}



//class Student
//{
//    public string FirstName { get; set; } = null!;
//    public string LastName { get; set; } = null!;
//}

















//////////////////////////////////////////////

//{

//    int operations = 500;
//    var watch = new Stopwatch();




//    watch.Start();
//    UseThread(operations);
//    watch.Stop();

//    WriteLine("Thread Milliseconds :" + watch.ElapsedMilliseconds);

//    watch.Reset();


//    watch.Start();
//    UseThreadPool(operations);
//    watch.Stop();


//    WriteLine("ThreadPool Milliseconds :" + watch.ElapsedMilliseconds);



//    void UseThread(int operation)
//    {
//        using var countdown = new CountdownEvent(operation);
//        WriteLine("Threads !!!");

//        for (int i = 0; i < operation; i++)
//        {
//            var thread = new Thread(() =>
//            {
//                Write($"{Thread.CurrentThread.ManagedThreadId} ");

//                Thread.Sleep(100);
//                countdown.Signal();
//            });

//            thread.Start();
//        }

//        countdown.Wait();
//        WriteLine();
//    }


//    void UseThreadPool(int operation)
//    {
//        using var countdown = new CountdownEvent(operation);

//        WriteLine("ThreadPools !!!");

//        for (int i = 0; i < operation; i++)
//        {
//            ThreadPool.QueueUserWorkItem(_ =>
//            {
//                Write($"{Thread.CurrentThread.ManagedThreadId} ");

//                Thread.Sleep(100);
//                countdown.Signal();
//            });
//        }

//        countdown.Wait();
//        WriteLine();
//    }
//}









//////////////////////////////////////////////




//void MoneyTransfer(CancellationToken token)
//{
//    WriteLine(Thread.CurrentThread.ManagedThreadId);

//    for (int i = 0; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//        {
//            WriteLine("Cancelled");
//            return;
//        }

//        WriteLine("Take Money");
//        Thread.Sleep(2000);
//        WriteLine("Send Money");
//    }
//}





void MoneyTransfer(CancellationToken token)
{
    WriteLine(Thread.CurrentThread.ManagedThreadId);

    try
    {
        for (int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();

            WriteLine("Take Money");
            Thread.Sleep(2000);
            WriteLine("Send Money");
        }
    }
    catch (OperationCanceledException ex)
    {
        WriteLine($"catch -> {ex.Message}");
    }
}





using var cts = new CancellationTokenSource();

ThreadPool.QueueUserWorkItem(_ =>
{
    MoneyTransfer(cts.Token);
});


ReadLine();
cts.Cancel();


while (true)
{

}


StringBuilder sb = new();

string x = "";

sb.AppendLine($"{x[0] ^ 212321312}");