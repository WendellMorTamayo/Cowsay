﻿using CowsayProgram;

Console.Write("🐮 Moo! Tell me what you want to say: ");
string? input = Console.ReadLine();
input ??= "";

Cowsay cowsay = new();
Subscriber subscriber = new(cowsay);

cowsay.Say(input);