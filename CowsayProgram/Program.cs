using CowsayProgram;

Console.Write("🐮 Moo! Tell me what you want to say: ");
string? input = Console.ReadLine();

input ??= "";

Cowsay cowsay = new();
cowsay.Reply += (sender, reply) => Console.WriteLine(reply);
cowsay.Say(input);

