using Kemono.Api;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;


var api = new KemonoApi();
//var creators = await api.GetAllCreatorsAsync();

//var creator = creators.Skip(50).First();

//Console.WriteLine("Id: " + creator.Id);
//Console.WriteLine("Name: " + creator.Name);
//Console.WriteLine("Service: " + creator.Service);
//Console.WriteLine("Indexed: " + creator.Indexed);
//Console.WriteLine("Updated: " + creator.Updated);
//Console.WriteLine("Favorited: " + creator.Favorited);


var posts = await api.GetRecentPostsAsync("sgrui");
var post = posts.First();

Console.WriteLine(JsonSerializer.Serialize(post, options: new JsonSerializerOptions()
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
}));