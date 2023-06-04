using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Configuration;
using N5.CHALLENGE.APPLICATION.Interfaces;

namespace N5.CHALLENGE.APPLICATION.AppServices
{
    public class ElasticSearchAppService : IElasticSearchAppService
    {
        private readonly IConfiguration _configuration;

        public ElasticSearchAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ElasticsearchClient GetClient()
        {
            ElasticsearchClientSettings settings = new ElasticsearchClientSettings(_configuration["elastic-search:CloudId"], new ApiKey(_configuration["elastic-search:ApiKey"]))
                .DefaultIndex("permisos");

            return new ElasticsearchClient(settings);
        }
    }
}
