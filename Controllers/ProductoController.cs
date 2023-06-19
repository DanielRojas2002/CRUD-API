
using CRUD.Models;
using CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CRUD.Controllers
{
    public class ProductoController : Controller
    {
        
        

       

        public async Task<IActionResult> Index()
        {
         

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5125/"); // Reemplaza con la URL de tu API

                var response = await client.GetAsync("api/producto/lista"); // Llama a la acción "Lista" de tu API

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponsecs>(data);

                    if (result != null && result.lista != null)
                    {
                        var listaProductos = JsonConvert.DeserializeObject<List<Producto>>(result.lista.ToString());
                        return View(listaProductos);
                    }
                }

                // Maneja el caso de error en la respuesta de la API
                // ...
            }

            return View();
        }


        public async Task<IActionResult> Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Producto modelo)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5125/"); // Reemplaza con la URL de tu API


               

                var json = JsonConvert.SerializeObject(modelo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/Producto/Guardar", content);
             
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponsecs>(data);

                    // Procesa la respuesta de la API y realiza las acciones necesarias

                    return RedirectToAction("Index");
                }

                // Maneja el caso de error en la respuesta de la API
                // ...
            }

            return View(modelo);
        }



        public async Task<IActionResult> Editar(int IdProducto)
        {


            using (var client = new HttpClient())
          
            {
               client.BaseAddress = new Uri("http://localhost:5125/"); // Reemplaza con la URL de tu API

               var response = await client.GetAsync("api/Producto/Obtener/"+ Convert.ToString(IdProducto)); // Llama a la acción "Lista" de tu API

                //var builder = new UriBuilder("api/Producto/Obtener");
                //builder.Query = $"IdProducto={idproducto}";

                //var response = await client.GetAsync(builder.Uri);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponsecs>(data);

                    if (result != null && result.lista != null)
                    {
                        var productoobjeto = JsonConvert.DeserializeObject<Producto>(result.lista.ToString());

                        Producto producto = new Producto()
                        {
                            IdProducto = productoobjeto.IdProducto,
                            Nombre= productoobjeto.Nombre,
                            Categoria = productoobjeto.Categoria,
                            Precio = productoobjeto.Precio,
                            CodigoBarra = productoobjeto.CodigoBarra,
                            Marca = productoobjeto.Marca

                        };
                        return View(producto);
                    }
                }

                // Maneja el caso de error en la respuesta de la API
                // ...
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Editar(Producto modelo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5125/"); // Reemplaza con la URL de tu API

                var json = JsonConvert.SerializeObject(modelo);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync("api/Producto/Editar", content);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponsecs>(data);

                    // Procesa la respuesta de la API y realiza las acciones necesarias

                    return RedirectToAction("Index");
                }

                // Maneja el caso de error en la respuesta de la API
                // ...
            }

            return View(modelo);
        }


        public async Task<IActionResult> Eliminar(int IdProducto)
        {


            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri("http://localhost:5125/"); // Reemplaza con la URL de tu API

                var response = await client.GetAsync("api/Producto/Obtener/" + Convert.ToString(IdProducto)); // Llama a la acción "Lista" de tu API

                //var builder = new UriBuilder("api/Producto/Obtener");
                //builder.Query = $"IdProducto={idproducto}";

                //var response = await client.GetAsync(builder.Uri);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponsecs>(data);

                    if (result != null && result.lista != null)
                    {
                        var productoobjeto = JsonConvert.DeserializeObject<Producto>(result.lista.ToString());

                        Producto producto = new Producto()
                        {
                            IdProducto = productoobjeto.IdProducto,
                            Nombre = productoobjeto.Nombre,
                            Categoria = productoobjeto.Categoria,
                            Precio = productoobjeto.Precio,
                            CodigoBarra = productoobjeto.CodigoBarra,
                            Marca = productoobjeto.Marca

                        };
                        return View(producto);
                    }
                }

                // Maneja el caso de error en la respuesta de la API
                // ...
            }

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Eliminar(Producto modelo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5125/"); // Reemplaza con la URL de tu API

                var response = await client.DeleteAsync($"api/Producto/Eliminar/{modelo.IdProducto}");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponsecs>(data);

                    // Procesa la respuesta de la API y realiza las acciones necesarias

                    return RedirectToAction("Index");
                }

                // Maneja el caso de error en la respuesta de la API
                // ...
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error en la solicitud" });
        }



       


    }
}
