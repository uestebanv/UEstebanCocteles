using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PL.Models;

namespace PL.Controllers
{
    public class CoctelesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public CoctelesController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }


        public ActionResult GetAllCocteles()
        {
            Coctel coctel = new Coctel();

            try
            {
                using (var client = new HttpClient())
                {
                    string urlApi = _configuration["urlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.GetAsync("json/v1/1/search.php?s=");
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var  readTask = result.Content.ReadAsStringAsync();
                        
                        dynamic resultJSON = JObject.Parse(readTask.Result.ToString());
                        readTask.Wait();

                        coctel.Cocteles = new List<object>();

                        foreach (var resultItem in resultJSON.drinks)
                        {
                            Coctel coctelItem = new Coctel();
                            coctelItem.IdCoctel = resultItem.idDrink;
                            coctelItem.Name = resultItem.strDrink;
                            coctelItem.Preparacion = resultItem.strInstructions;
                            coctelItem.Image = resultItem.strDrinkThumb;
                            coctelItem.Ingredientes = new Ingredientes();
                            coctelItem.Ingredientes.Ingrediente1 = resultItem.strIngredient1;
                            coctelItem.Ingredientes.Ingrediente2 = resultItem.strIngredient2;
                            coctelItem.Ingredientes.Ingrediente3 = resultItem.strIngredient3;
                            coctelItem.Ingredientes.Ingrediente4 = resultItem.strIngredient4;
                            coctelItem.Ingredientes.Ingrediente5 = resultItem.strIngredient5;
                            coctelItem.Ingredientes.Ingrediente6 = resultItem.strIngredient6;
                            coctelItem.Ingredientes.Ingrediente7 = resultItem.strIngredient7;
                            coctelItem.Ingredientes.Ingrediente8 = resultItem.strIngredient8;
                            coctelItem.Ingredientes.Ingrediente9 = resultItem.strIngredient9;
                            coctelItem.Ingredientes.Ingrediente10 = resultItem.strIngredient10;
                            coctelItem.Ingredientes.Ingrediente11 = resultItem.strIngredient11;
                            coctelItem.Ingredientes.Ingrediente12 = resultItem.strIngredient12;
                            coctelItem.Ingredientes.Ingrediente13 = resultItem.strIngredient13;
                            coctelItem.Ingredientes.Ingrediente14 = resultItem.strIngredient14;
                            coctelItem.Ingredientes.Ingrediente15 = resultItem.strIngredient15;
                            coctelItem.Ingredientes.Cantidad1 = resultItem.strMeasure1;
                            coctelItem.Ingredientes.Cantidad2 = resultItem.strMeasure2;
                            coctelItem.Ingredientes.Cantidad3 = resultItem.strMeasure3;
                            coctelItem.Ingredientes.Cantidad4 = resultItem.strMeasure4;
                            coctelItem.Ingredientes.Cantidad5 = resultItem.strMeasure5;
                            coctelItem.Ingredientes.Cantidad6 = resultItem.strMeasure6;
                            coctelItem.Ingredientes.Cantidad7 = resultItem.strMeasure7;
                            coctelItem.Ingredientes.Cantidad8 = resultItem.strMeasure8;
                            coctelItem.Ingredientes.Cantidad9 = resultItem.strMeasure9;
                            coctelItem.Ingredientes.Cantidad10 = resultItem.strMeasure10;
                            coctelItem.Ingredientes.Cantidad11 = resultItem.strMeasure11;
                            coctelItem.Ingredientes.Cantidad12 = resultItem.strMeasure12;
                            coctelItem.Ingredientes.Cantidad13 = resultItem.strMeasure13;
                            coctelItem.Ingredientes.Cantidad14 = resultItem.strMeasure14;
                            coctelItem.Ingredientes.Cantidad15 = resultItem.strMeasure15;


                            coctel.Cocteles.Add(coctelItem);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
             
            }
            return View(coctel);
        }

        [HttpPost]
        public ActionResult GetAllCocteles(Coctel coctel)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    string urlApi = _configuration["urlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.GetAsync("json/v1/1/search.php?s=" + coctel.buscar);
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();

                        dynamic resultJSON = JObject.Parse(readTask.Result.ToString());
                        readTask.Wait();

                        coctel.Cocteles = new List<object>();

                        foreach (var resultItem in resultJSON.drinks)
                        {
                            Coctel coctelItem = new Coctel();
                            coctelItem.IdCoctel = resultItem.idDrink;
                            coctelItem.Name = resultItem.strDrink;
                            coctelItem.Preparacion = resultItem.strInstructions;
                            coctelItem.Image = resultItem.strDrinkThumb;
                            coctelItem.Ingredientes = new Ingredientes();
                            coctelItem.Ingredientes.Ingrediente1 = resultItem.strIngredient1;
                            coctelItem.Ingredientes.Ingrediente2 = resultItem.strIngredient2;
                            coctelItem.Ingredientes.Ingrediente3 = resultItem.strIngredient3;
                            coctelItem.Ingredientes.Ingrediente4 = resultItem.strIngredient4;
                            coctelItem.Ingredientes.Ingrediente5 = resultItem.strIngredient5;
                            coctelItem.Ingredientes.Ingrediente6 = resultItem.strIngredient6;
                            coctelItem.Ingredientes.Ingrediente7 = resultItem.strIngredient7;
                            coctelItem.Ingredientes.Ingrediente8 = resultItem.strIngredient8;
                            coctelItem.Ingredientes.Ingrediente9 = resultItem.strIngredient9;
                            coctelItem.Ingredientes.Ingrediente10 = resultItem.strIngredient10;
                            coctelItem.Ingredientes.Ingrediente11 = resultItem.strIngredient11;
                            coctelItem.Ingredientes.Ingrediente12 = resultItem.strIngredient12;
                            coctelItem.Ingredientes.Ingrediente13 = resultItem.strIngredient13;
                            coctelItem.Ingredientes.Ingrediente14 = resultItem.strIngredient14;
                            coctelItem.Ingredientes.Ingrediente15 = resultItem.strIngredient15;
                            coctelItem.Ingredientes.Cantidad1 = resultItem.strMeasure1;
                            coctelItem.Ingredientes.Cantidad2 = resultItem.strMeasure2;
                            coctelItem.Ingredientes.Cantidad3 = resultItem.strMeasure3;
                            coctelItem.Ingredientes.Cantidad4 = resultItem.strMeasure4;
                            coctelItem.Ingredientes.Cantidad5 = resultItem.strMeasure5;
                            coctelItem.Ingredientes.Cantidad6 = resultItem.strMeasure6;
                            coctelItem.Ingredientes.Cantidad7 = resultItem.strMeasure7;
                            coctelItem.Ingredientes.Cantidad8 = resultItem.strMeasure8;
                            coctelItem.Ingredientes.Cantidad9 = resultItem.strMeasure9;
                            coctelItem.Ingredientes.Cantidad10 = resultItem.strMeasure10;
                            coctelItem.Ingredientes.Cantidad11 = resultItem.strMeasure11;
                            coctelItem.Ingredientes.Cantidad12 = resultItem.strMeasure12;
                            coctelItem.Ingredientes.Cantidad13 = resultItem.strMeasure13;
                            coctelItem.Ingredientes.Cantidad14 = resultItem.strMeasure14;
                            coctelItem.Ingredientes.Cantidad15 = resultItem.strMeasure15;


                            coctel.Cocteles.Add(coctelItem);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                coctel.Exception = ex;
            }
            return View(coctel);
        }
    }
}
