using Digi.Core.Entities;
using Digi.Core.Intefaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;

namespace Digi.Infra.CustomMiddleware
{
    public class DatabaseBuildMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseBuildMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IQueryTamer _queryT)
        {
            if (_queryT.Count() == 0)
            {

                var t1 = new Tamer("Takeru Takaish", "Takeru é um personagem do anime e mangá Digimon Adventure e Digimon Adventure 02." +
                    " Ele é o irmão mais novo de Yamato “Matt” Ishida. Ele é uma parceria com Patamon, e incorpora a característica da Esperança.");
                _queryT.Add(t1);

                var t2 = new Tamer("Mimi Tachikawa", "Mimi é um personagem do anime e mangá Digimon Adventure e Digimon Adventure 02." +
                    " Mimi tem sido descrito como uma “menina feminino” -spoiled, ditzy, vão, e uma menina certinha que se queixa muito," +
                    " mas também é sensível, artística, doce e carinho. Ela sempre fala de compras e moda.");
                _queryT.Add(t2);

                var t3 = new Tamer("6 documents", "6 documents?");
                _queryT.Add(t3);
            }
            await _next(context);
        }
    }
    public static class ResquestDatabaseBuildMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestDatabase(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseBuildMiddleware>();
        }
    }
}