using CowsayProgram;

Console.Write("🐮 Moo! Tell me what you want to say: ");
string? input = Console.ReadLine();

if (!string.IsNullOrEmpty(input))
{
    Cowsay cowsay = new();
    cowsay.Reply += OnReply;
    cowsay.Say(input);
}

static void OnReply(object? sender, string reply)
{
    Console.WriteLine(reply);
}
