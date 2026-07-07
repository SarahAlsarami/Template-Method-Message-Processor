using System;

public abstract class MessageProcessor
{
    // Template Method
    // لا يُعاد تعريفه أبداً
    public void Process()
    {
        PrepareGreeting();
        BuildContent();
        AddOfficialSignature();
        Send();
        LogOperation();
    }

    // هذه الخطوة فقط تختلف من ابن لابن
    protected abstract void BuildContent();

    private void PrepareGreeting()
    {
        Console.WriteLine("Dear Customer,");
    }

    private void AddOfficialSignature()
    {
        Console.WriteLine("Support Team");
    }

    private void Send()
    {
        Console.WriteLine("Message has been sent.");
    }

    private void LogOperation()
    {
        Console.WriteLine("Operation has been logged.");
        Console.WriteLine("-----------------------------");
    }
}

public class ApprovalProcessor : MessageProcessor
{
    protected override void BuildContent()
    {
        Console.WriteLine("Your request has been APPROVED!");
    }
}

public class RejectionProcessor : MessageProcessor
{
    private readonly string _reason;

    public RejectionProcessor(string reason)
    {
        _reason = reason;
    }

    protected override void BuildContent()
    {
        Console.WriteLine($"Rejected. Reason: {_reason}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MessageProcessor processor;

        Console.WriteLine("Approval Message:");
        processor = new ApprovalProcessor();
        processor.Process();

        Console.WriteLine("Rejection Message:");
        processor = new RejectionProcessor("Product is not available");
        processor.Process();
    }
}