using CowsayProgram;

Cowsay cowsay = new();

cowsay.Reply += OnReply;

cowsay.Say("hello world");


static void OnReply(object? sender, string reply)
{
    Console.WriteLine(reply);
}