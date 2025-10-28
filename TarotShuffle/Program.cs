// See https://aka.ms/new-console-template for more information
using TarotShuffle;

var majorArcana = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "MajorArcana.json"));
var minorArcana = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "MinorArcana.json"));
var cfgFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "config.toml"));
var facilier = new Facilier(majorArcana, minorArcana);

facilier.Begin();