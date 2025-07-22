using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Interfaces.Services.Sw_Parametro;
using Api.Domain.Interfaces.Services.Uf;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Services.UserCompleto;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddTransient<IMunicipioService, MunicipioService>();
            serviceCollection.AddTransient<ICepService, CepService>();

            serviceCollection.AddTransient<IUserCompletoService, UserCompletoService>();

            serviceCollection.AddTransient<ISw_ParametroService, Sw_ParametroService>();


            serviceCollection.AddTransient<IMetadataService, MetadataService>();

        }
    }
}
