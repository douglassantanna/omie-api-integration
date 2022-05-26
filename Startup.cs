using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using omie_api_integration.ColetasOnline.CTR.SolicitarCtr;
using omie_api_integration.ColetasOnline.EnviarCacambaLocal;
using omie_api_integration.ColetasOnline.Prefeitura;
using omie_api_integration.ColetasOnline.RetirarCacamba;
using omie_api_integration.Omie.OrdemServico.Faturar;
using omie_api_integration.Omie.OrdemServico.Listar;
using omie_poc.Omie.Conta;
using omie_poc.Omie.OrdemServico.Incluir;

namespace omie_poc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IOrdemDeServico, OrdensDeServico>((x) =>
            {
                x.BaseAddress = new Uri("https://app.omie.com.br/api/v1/servicos/os/");
            });
            services.AddHttpClient<IListarOS, ListarOSs>((x) =>
            {
                x.BaseAddress = new Uri("https://app.omie.com.br/api/v1/servicos/os/");
            });
            services.AddHttpClient<IContas, Contas>((x) =>
            {
                x.BaseAddress = new Uri("https://app.omie.com.br/api/v1/crm/contas/");
            });
            services.AddHttpClient<IFaturarOS, FaturarOSs>((x) =>
            {
                x.BaseAddress = new Uri("https://app.omie.com.br/api/v1/servicos/osp/");
            });
            services.AddScoped<IListarPrefeitura, ListarPrefeituras>();
            services.AddScoped<ISolicitarCTR, SolicitarCTRs>();
            services.AddScoped<IEnviarCacambaLocal, EnviarCacambasLocal>();
            services.AddScoped<IRetirarCacamba, RetirarCacambas>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "omie_poc", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "omie_poc v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
