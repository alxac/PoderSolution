using Data.Contexto;
using Data.Implementacao;
using Data.Repositorio;
using Dominio.Interface;
using Dominio.Mapper;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Servico.Servicos;

namespace AnelApi
{
    public class ConfigureService
    {
        public static void ConfigDependencias(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepositorio<>), typeof(BaseRepositorio<>));
            serviceCollection.AddTransient<IAnelServico, AnelServicos>();
            serviceCollection.AddScoped<IAnelRepositorio, AnelRepositorio>();

            serviceCollection.AddSingleton(ConfigureIMapper.GetMapper());

            serviceCollection.AddDbContext<DBContexto>(options => options.UseSqlServer("Data Source=ALEX_122024\\SQLEXPRESS;Initial Catalog=ANEL_TESTE;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
        }
    }
}
