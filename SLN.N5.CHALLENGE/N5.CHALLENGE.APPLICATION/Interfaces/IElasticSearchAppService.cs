using Elastic.Clients.Elasticsearch;

namespace N5.CHALLENGE.APPLICATION.Interfaces
{
    public interface IElasticSearchAppService
    {
        ElasticsearchClient GetClient();
    }
}
